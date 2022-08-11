using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlucagonReceptorLogic : MonoBehaviour
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
            FindObjectOfType<SignalMoleculeToS>().CreateNewSignalMTo(recID);
        }
        isFree = true;
        boxColl.enabled = true;
        reliseSignalM = false;
    }
    private void ActiveFalse()
    {
        foreach (Transform i in transform)
        {
            i.GetComponent<MeshRenderer>().enabled = false;
        }
        // web          
        FindObjectOfType<GlucagonS>().GlucagonMeetGlucReceptor(GetComponent<DataScript>().id);
        Invoke("ActiveTrue", 2);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (isFree == false)
        {
            switch (other.gameObject.tag)
            {
                case "Insulin":

                    break;
                case "Glucagon":
                    boxColl.enabled = false;
                    StartCoroutine(GlucagonAnimationOnMeet(gameObject));
                    Invoke("ActiveFalse", 2);
                    break;
                case "Sugar":

                    break;
                default:

                    break;
            }
        }
        //if (other.gameObject.tag == "Glucagon" && isFree == false)
        //{
        //    boxColl.enabled = false;
        //    StartCoroutine(GlucagonAnimationOnMeet(gameObject));
        //    Invoke("ActiveFalse", 2);
        //}
    }
    IEnumerator GlucagonAnimationOnMeet(GameObject obj)
    {
        gameObject.transform.localScale = new Vector3(obj.transform.localScale.x + 1f, obj.transform.localScale.y, obj.transform.localScale.z);
        yield return new WaitForSeconds(1);
        gameObject.transform.localScale = new Vector3(obj.transform.localScale.x - 1f, obj.transform.localScale.y, obj.transform.localScale.z);
    }
}
