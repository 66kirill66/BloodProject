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
    //json
    ReceptorId receptorId = new ReceptorId();
    public string json;

    [Serializable]
    public class ReceptorId
    {
        public int id;
    }
   

    private void Start()
    {       
        // json
        int recId = GetComponent<DataScript>().id;
        receptorId.id = recId;
        json = JsonUtility.ToJson(receptorId);        
        Debug.Log(json);

        boxColl = GetComponent<BoxCollider>();
    }
    private void Update()
    {       
        
    }
   
    private void ActiveTrue()
    {
        gameObject.SetActive(true);
        if(reliseSignalM == true)
        {
            //json
            FindObjectOfType<SignalMoleculeS>().CreateNewSignalM(json);
            reliseSignalM = false;
        }
        isFree = true;
        boxColl.enabled = true;       
    }
    private void ActiveFalse()
    {      
        gameObject.SetActive(false);
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
