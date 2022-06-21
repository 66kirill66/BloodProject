using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReceptorFinder : MonoBehaviour
{

    public bool isFree = true;
    public bool signalM = false;
    public GameObject mol;
    public GameObject prifabSignalMolecule;
    int newSignalId = 0;
    int oldSignalId = 0;
    Collider boxColl;

    private void Start()
    {
        boxColl = GetComponent<BoxCollider>();
        prifabSignalMolecule = FindObjectOfType<SignalMoleculeS>().signalM;
    }
    private void Update()
    {       
        if (newSignalId != oldSignalId)
        {
            oldSignalId = newSignalId;
            GameObject newSignal = Instantiate(prifabSignalMolecule, transform.position, transform.rotation);
            newSignal.AddComponent<DataScript>().id = newSignalId;
            signalM = true;
        }
    }
   
    private void ActiveTrue()
    {
        gameObject.SetActive(true);
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
          //  FindObjectOfType<SignalMoleculeS>().CreateNewSignalM(newSignalId);
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
