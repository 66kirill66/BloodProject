using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChannelOldPlace : MonoBehaviour
{
    public bool isOld = true;
    public bool changePlase = false;
    public GameObject newChannelTransform;

    public GameObject sugarObj;
    public bool haveSugar;
    int channelId;
    void Start()
    {
        changePlase = true;   // Check
        channelId = GetComponent<DataScript>().id;
    }


    void Update()
    {
        
       
        if (isOld == false && changePlase == true && newChannelTransform != null)
        {
            Invoke("SetPositionRotation", 1);
        }
    }
    private void SetPositionRotation()
    {
        Transform pos = newChannelTransform.gameObject.transform;
        transform.position = Vector3.Lerp(transform.position, pos.gameObject.transform.position, 1 * Time.deltaTime);
        transform.rotation = Quaternion.Euler(pos.rotation.x, pos.rotation.y, 100 );
        gameObject.tag = "Untagged";
        Invoke("ColliderOn",3);
    }

    private void ColliderOn()
    {
        GetComponent<CapsuleCollider>().enabled = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Sugar" && haveSugar == false)
        {
            sugarObj = other.gameObject;
            haveSugar = true;            
            sugarObj.GetComponent<MoleculeMove>().StopCor();
            sugarObj.transform.position = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);
            FindObjectOfType<SugarS>().SugarOnMeetChannel(channelId);
            FindObjectOfType<SugarS>().bloodList.Remove(other.gameObject);


        }
    }
    public void SugarMove()
    {
        Debug.Log("--------SugarMove---------");
        sugarObj.GetComponent<MoleculeMove>().MusculeCorutine();
        haveSugar = false;
    }
}
