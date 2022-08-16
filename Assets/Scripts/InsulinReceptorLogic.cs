using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InsulinReceptorLogic : MonoBehaviour
{
    public float num = 3;
    public bool isFree = true;
    public bool signalM = false;
    public bool reliseSignalM = false;
    public GameObject mol;
    Collider boxColl;

    int recID;

    private void Start()
    {       
        recID = GetComponent<DataScript>().id;
        boxColl = GetComponent<BoxCollider>();

    }
    private void Update()
    {
        //CollisionOnStart();
    }

    private void CollisionOnStart()
    {
        if (num > 0)
        {
            boxColl.enabled = false;
            num -= 1 * Time.deltaTime;
            Debug.Log(num);
        }       
        else if (num < 0)
        {
            boxColl.enabled = true;
        }
    }

    private void ActiveTrue()
    {
        foreach (Transform i in transform)
        {
            i.GetComponent<MeshRenderer>().enabled = true;
        }
        if (reliseSignalM == true)
        {                       
            //send Id To Web
            FindObjectOfType<SignalMoleculeS>().CreateNewSignalM(recID); 
        }
        isFree = true;
        boxColl.enabled = true;
        reliseSignalM = false;
    }
    private void ActiveFalse()
    {
        foreach(Transform i in transform)
        {
            i.GetComponent<MeshRenderer>().enabled = false;
        }       
        // web          
        FindObjectOfType<InsulinS>().InsulinMeetInsReceptor(GetComponent<DataScript>().id);
        Invoke("ActiveTrue", 2);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(isFree == false)
        {
            switch (other.gameObject.tag)
            {
                case "Insulin":
                    boxColl.enabled = false;
                    StartCoroutine(InsulinAnimationOnMeet(gameObject));
                    Invoke("ActiveFalse", 2);
                    break;
                case "Glucagon":
                    
                    break;
                case "Sugar":
                    FindObjectOfType<SugarS>().SugarMeetInsulinReceptor(recID);
                    break;
                default:

                    break;
            }
        }       
        //if (other.gameObject.tag == "Insulin" && isFree == false)
        //{           
        //    boxColl.enabled = false;
        //    StartCoroutine(InsulinAnimationOnMeet(gameObject));       
        //    Invoke("ActiveFalse", 2);          
        //}
    }
    IEnumerator InsulinAnimationOnMeet(GameObject obj)
    {      
        gameObject.transform.localScale = new Vector3(obj.transform.localScale.x + 1f, obj.transform.localScale.y , obj.transform.localScale.z);
        yield return new WaitForSeconds(1);
        gameObject.transform.localScale = new Vector3(obj.transform.localScale.x - 1f, obj.transform.localScale.y, obj.transform.localScale.z);
        
    }    
}
