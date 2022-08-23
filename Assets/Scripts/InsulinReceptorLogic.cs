using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InsulinReceptorLogic : MonoBehaviour
{
    public bool isFree = true;
    public bool signalM = false;
    public bool reliseSignalM = false;
    public GameObject mol; //SignalMolecule
    Collider boxCollider;

    int recID;

    private void Start()
    {       
        recID = GetComponent<DataScript>().id;
        boxCollider = GetComponent<BoxCollider>();

    }
    private void Update()
    {
        if (reliseSignalM == true)
        {
            if (mol != null)
            {
                mol.GetComponent<MeshRenderer>().enabled = true;
            }
        }
    }   

    private void ActiveTrue()
    {
        if (mol != null)
        {
            mol.GetComponent<MeshRenderer>().enabled = true;
        }
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
        boxCollider.enabled = true;
        reliseSignalM = false;
    }
    public void ActiveFalse()
    {
        foreach(Transform i in transform)
        {
            i.GetComponent<MeshRenderer>().enabled = false;
        }
        if (mol != null)
        {
            mol.GetComponent<MeshRenderer>().enabled = false;
        }
        Invoke("ActiveTrue", 2);   // Time Invisible
    }
    private void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "Glucagon":
                FindObjectOfType<GlucagonS>().GlucagonMeetInsulunReceptor(recID);
                break;
            case "Sugar":
                FindObjectOfType<SugarS>().SugarMeetInsulinReceptor(recID);
                break;
            default:
                break;
        }
        if (isFree == false)
        {
            switch (other.gameObject.tag)
            {
                case "Insulin":
                    boxCollider.enabled = false;
                    StartCoroutine(InsulinAnimationOnMeet(gameObject));
                    FindObjectOfType<InsulinS>().InsulinMeetInsReceptor(GetComponent<DataScript>().id);
                    break;
                default:
                    break;
            }
        }
    }
    IEnumerator InsulinAnimationOnMeet(GameObject obj)
    {
        Invoke("ActiveFalse", 2);   // Time Invisible  
        gameObject.transform.localScale = new Vector3(obj.transform.localScale.x + 1f, obj.transform.localScale.y , obj.transform.localScale.z);
        yield return new WaitForSeconds(1);
        gameObject.transform.localScale = new Vector3(obj.transform.localScale.x - 1f, obj.transform.localScale.y, obj.transform.localScale.z);         
    }    
}
