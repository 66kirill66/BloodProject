﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignalMolMove : MonoBehaviour
{
    float PosX;
    float PosY;
    bool toMus;
    bool toLiver;
    public string movingPlace;
    SignalMoleculeS signalS;
    int signalId;

    void Start()
    {
        signalId = GetComponent<DataScript>().id;
        if (movingPlace == "Mus")
        {
            StartCoroutine(CorutinerundoPointInMus());
        }
        else if(movingPlace == "Liver") // new Chek
        {
            StartCoroutine(CorutinerundoPointInLiver());
        }
        signalS = FindObjectOfType<SignalMoleculeS>();
        
    }
    private void RundomPointMus()
    {
        PosX = Random.Range(1f, 14f);
        PosY = Random.Range(-1f, -4.6f);
    }
    private void RundomPointLiver()
    {
        PosX = Random.Range(-23f, -6f);
        PosY = Random.Range(-7.5f, 0);
    }
    private IEnumerator CorutinerundoPointInMus()
    {
        toLiver = false;
        toMus = true;
        while (toMus == true)
        {
            RundomPointMus();
            Vector3 startPos = transform.position;
            Vector3 endPos = new Vector3(PosX, PosY, -0.5f);
            float travel = 0;
            while (travel < 1f)
            {
                travel += Time.deltaTime * 0.2f;
                transform.position = Vector3.Lerp(startPos, endPos, travel);
                yield return new WaitForEndOfFrame();
            }
        }
    }
    private IEnumerator CorutinerundoPointInLiver()
    {
        toMus = false;
        toLiver = true;
        while (toLiver == true)
        {
            RundomPointLiver();
            Vector3 startPos = transform.position;
            Vector3 endPos = new Vector3(PosX, PosY, -0.5f);
            float travel = 0;
            while (travel < 1f)
            {
                travel += Time.deltaTime * 0.2f;
                transform.position = Vector3.Lerp(startPos, endPos, travel);
                yield return new WaitForEndOfFrame();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {       
        if (other.gameObject.tag == "Channel" && other.gameObject.GetComponent<ChanneLogic>().changePlace == false)
        {
            toMus = false;
            toLiver = false; // new
            StopAllCoroutines();
            gameObject.GetComponent<SphereCollider>().enabled = false;
            other.GetComponent<CapsuleCollider>().enabled = false;
            transform.position = other.transform.position;
            ParticleSystem ps = gameObject.GetComponentInChildren<ParticleSystem>(); ps.Play();
           
            int channelId = other.GetComponentInParent<DataScript>().id;
            //send to Web
            signalS.SignalMeetChannel(signalId,channelId);
            Invoke("SignalDelite", 1);
        }
    }     
    private void SignalDelite()  // Invoke To fixed bug with Enzime... Delite Entity.
    {
        Destroy(gameObject);
        FindObjectOfType<SignalMoleculeS>().SetSignalLevelDelete(signalId);  // delete
    }
}
