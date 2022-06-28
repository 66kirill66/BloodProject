using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReceptorFinder : MonoBehaviour
{
    
    public bool isFree = true;
    public bool signalM = false;
    public GameObject mol;
    Collider boxColl;

   
    public string ReceptorDataId(int id)
    {
        return JsonUtility.ToJson(id);
    }

      

    private void Start()
    {
        boxColl = GetComponent<BoxCollider>();
    }
    private void Update()
    {       
        
    }
   
    private void ActiveTrue()
    {
        gameObject.SetActive(true);
        //json
        int recId = GetComponent<DataScript>().id;
        string data = ReceptorDataId(recId);
        FindObjectOfType<SignalMoleculeS>().CreateNewSignalM(data);
        Debug.Log(recId);
      
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
