using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChanneLogic : MonoBehaviour
{
    public bool isOldPlace = true;
    public bool changePlace = false;
    public GameObject newChannelTransform;
    public GameObject sugarObj;
    public bool haveSugar;
    int channelId;

    float timer = 3;
    void Start()
    {
       // changePlase = true;   // Check
        channelId = GetComponent<DataScript>().id;      
    }

    void Update()
    {
        CollisionOn();

        if (isOldPlace == false && changePlace == true && newChannelTransform != null)
        {
            Invoke("SetPositionRotation", 1);
        }
    }

    private void CollisionOn()
    {
        if(GetComponent<CapsuleCollider>().enabled == false)
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime;
            }
            else
            {
                GetComponent<CapsuleCollider>().enabled = true;
                timer = 3;
            }
        }
    }
    private void SetPositionRotation()
    {
        Transform pos = newChannelTransform.gameObject.transform;
        transform.position = Vector3.Lerp(transform.position, pos.gameObject.transform.position, 1 * Time.deltaTime);
        transform.rotation = Quaternion.Euler(pos.rotation.x, pos.rotation.y, 100 );
        gameObject.tag = "Untagged";  
    }

    private void OnTriggerEnter(Collider other)  // other = sugar
    {
        if (other.gameObject.tag == "Sugar" && haveSugar == false && changePlace == true)  //isOldPlace == false &&
        {
            sugarObj = other.gameObject;
            //haveSugar = true;
            // other.gameObject.tag = "Untagged";   // Change Tag and stop Collision With Channel
            // sugarObj.GetComponent<MoleculeMove>().StopCor();
            // sugarObj.transform.position = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);           
            FindObjectOfType<SugarS>().SugarMeetChannalSend(channelId);          
        }
        if (other.gameObject.tag == "Insulin")
        {
            FindObjectOfType<InsulinS>().InsMeetChannal(channelId);
        }
        if (other.gameObject.tag == "Glucagon")
        {
            FindObjectOfType<GlucagonS>().GlucMeetChannal(channelId);
        }
        else { return; }
    }
    public void SugarMove()  // Aplly in ChannelS
    {
        sugarObj.gameObject.tag = "Untagged";
        haveSugar = true;
        sugarObj.GetComponent<MoleculeMove>().StopCor();
        sugarObj.transform.position = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);
        FindObjectOfType<SugarS>().bloodList.Remove(sugarObj);       
        StartCoroutine(MoovingAnimation(sugarObj)); // sugarObj == sugar        
        FindObjectOfType<SugarS>().muscleList.Add(sugarObj);
        FindObjectOfType<SugarS>().sugarNumber++;
    }

    IEnumerator MoovingAnimation(GameObject sug)  // sugar Move
    {
        while (haveSugar == true)
        {
            Vector3 startPos = sug.transform.position;
            Vector3 newPos = new Vector3(sug.transform.position.x, sug.transform.position.y - 10, sug.transform.position.z);
            float travel = 0;
            while(travel < 0.3f)
            {
                travel += Time.deltaTime * 0.1f;
                sug.transform.position = Vector3.Lerp(startPos, newPos, travel);
                yield return new WaitForEndOfFrame();               
            }
            sugarObj.GetComponent<MoleculeMove>().MusculeCorutine();
            haveSugar = false;
            sugarObj = null;
        }
    }   
}
