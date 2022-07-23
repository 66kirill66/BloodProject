using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ReceptorFinder : MonoBehaviour
{
    
    public bool isFree = true;
    public bool signalM = false;
    public bool reliseSignalM = false;
    public GameObject mol;
    Collider boxColl;

    int recID;
    public string json;


    private void Start()
    {

        recID = GetComponent<DataScript>().id;
        //SignalMoleculeS.SignalMData mData = new SignalMoleculeS.SignalMData(0, recID);
        //json = mData.ToJsonString();
        //Debug.Log("++++++++++++++++++++++++++");
        //Debug.Log(json);



        boxColl = GetComponent<BoxCollider>();
    }
    private void Update()
    {       
        
    }
   
    private void ActiveTrue()
    {
        foreach (Transform i in transform)
        {
            i.GetComponent<MeshRenderer>().enabled = true;
        }
        if (reliseSignalM == true)
        {            
           // Debug.Log("++++++++++++ 1 ++++++++++++++");
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
        FindObjectOfType<InsulinS>().InsulinMeetReseptor(GetComponent<DataScript>().id);
        Invoke("ActiveTrue", 2);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Insulin" && isFree == false)
        {           
            boxColl.enabled = false;
            StartCoroutine(InculAnimationOnMeet(gameObject));       
            Invoke("ActiveFalse", 2);          
        }
    }
    IEnumerator InculAnimationOnMeet(GameObject obj)
    {      
        gameObject.transform.localScale = new Vector3(obj.transform.localScale.x + 1f, obj.transform.localScale.y , obj.transform.localScale.z);
        yield return new WaitForSeconds(1);
        gameObject.transform.localScale = new Vector3(obj.transform.localScale.x - 1f, obj.transform.localScale.y, obj.transform.localScale.z);
        
    }
}
