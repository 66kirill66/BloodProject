﻿using System.Collections;
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
    public Vector3 StartTransform;
    public Quaternion channelStartTransform;
    public string chLocation;

    float timer = 4;
    void Start()
    {
        channelId = GetComponent<DataScript>().id;
        channelStartTransform = gameObject.transform.rotation;
        StartTransform = gameObject.transform.position;
    }

    void Update()
    {
        CollisionOn();

        if (isOldPlace == false && changePlace == true && newChannelTransform != null)
        {
            Invoke("SetPositionRotation",1);
        }
        else if (isOldPlace == true && changePlace == false && newChannelTransform != null)
        {
            Invoke("SetPositionRotationBack",1);
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
                timer = 4;
            }
        }
    }
    private void SetPositionRotation()
    {
        Transform pos = newChannelTransform.gameObject.transform;
        transform.position = Vector3.Lerp(transform.position, pos.gameObject.transform.position, 1 * Time.deltaTime);
        transform.rotation = Quaternion.Euler(pos.rotation.x, pos.rotation.y, 100 );
    }
    private void SetPositionRotationBack()
    {
        transform.position = Vector3.Lerp(transform.position, StartTransform, 1 * Time.deltaTime);
        transform.rotation = channelStartTransform;
    }

    private void OnTriggerEnter(Collider other)  // other = sugar
    {
        if (other.gameObject.tag == "Sugar" && haveSugar == false && changePlace == true && chLocation == "Muscle")
        {
            foreach (GameObject i in FindObjectOfType<SugarS>().bloodList)
            {
                if (other.gameObject == i)
                {
                    //  Debug.Log("-----------Sugar");
                    sugarObj = other.gameObject;
                    GetComponent<CapsuleCollider>().enabled = false;
                    FindObjectOfType<SugarS>().SugarMeetChannalSend(channelId);
                }
            }
        }
        if(other.gameObject.tag == "Sugar" && haveSugar == false && changePlace == true && chLocation == "Liver")
            {
            foreach (GameObject i in FindObjectOfType<SugarS>().liverleList)
            {
                if (other.gameObject == i)
                {
                    sugarObj = other.gameObject;
                    GetComponent<CapsuleCollider>().enabled = false;
                    FindObjectOfType<SugarS>().SugarMeetChannalSend(channelId);
                }
            }
        }
        if (other.gameObject.tag == "Insulin")
        {
            FindObjectOfType<InsulinS>().InsMeetChannal(channelId);
        }
        if (other.gameObject.tag == "Glucagon")
        {
            FindObjectOfType<GlucagonS>().GlucMeetChannal(channelId);
        }
    }
    public void SugarMoveDown()  // Aplly in ChannelS
    {
        haveSugar = true;       
        sugarObj.GetComponent<MoleculeMove>().StopCor();
        sugarObj.transform.position = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);               
        StartCoroutine(MoovingAnimationDown(sugarObj)); // sugarObj = sugar
        FindObjectOfType<SugarS>().sugarNumber++;
        FindObjectOfType<SugarS>().ChecNumberToEnergy();
    }
    public void SugarMoveUp()  // Aplly in ChannelS
    {
        haveSugar = true;
        sugarObj.GetComponent<MoleculeMove>().StopCor();
        sugarObj.transform.position = new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z);
        StartCoroutine(MoovingAnimationUp(sugarObj)); // sugarObj = sugar
    }

    IEnumerator MoovingAnimationDown(GameObject sug)  // sugar Move
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
            FindObjectOfType<SugarS>().muscleList.Add(sugarObj);
            FindObjectOfType<SugarS>().bloodList.Remove(sugarObj);
            sugarObj = null;
        }
    }
    IEnumerator MoovingAnimationUp(GameObject sug)  // sugar Move
    {
        while (haveSugar == true)
        {
            Vector3 startPos = sug.transform.position;
            Vector3 newPos = new Vector3(sug.transform.position.x, sug.transform.position.y + 5, sug.transform.position.z);
            float travel = 0;
            while (travel < 0.3f)
            {
                travel += Time.deltaTime * 0.1f;
                sug.transform.position = Vector3.Lerp(startPos, newPos, travel);
                yield return new WaitForEndOfFrame();
            }
            sugarObj.GetComponent<MoleculeMove>().BloodCorutine();
            haveSugar = false;
            FindObjectOfType<SugarS>().bloodList.Add(sugarObj);
            FindObjectOfType<SugarS>().liverleList.Remove(sugarObj);
            sugarObj = null;
        }
    }
}
