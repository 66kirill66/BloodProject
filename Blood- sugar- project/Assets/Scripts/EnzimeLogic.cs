using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnzimeLogic : MonoBehaviour
{
    float PosX;
    float PosY;
    bool toMus;
    bool toLiver;
    public string movingPlace;
    int enzimeId;
    public string enzimePropertyValue;
   

    void Start()
    {
        enzimeId = GetComponent<DataScript>().id;
        if (movingPlace == "Mus")
        {
            StartCoroutine(CorutinerundoPointInMus());
        }
        else if (movingPlace == "Liver") 
        {
            StartCoroutine(CorutinerundoPointInLiver());
        }

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
        if (other.gameObject.tag == "Storage")
        {
            other.gameObject.GetComponent<StorageLogic>().collisionEnzime = gameObject;
            // other.gameObject.GetComponent<StorageLogic>().SetEnzimeAndStorage();
            // other.gameObject.GetComponent<StorageLogic>().isBroke = true; // Check
            int storageId = other.GetComponent<DataScript>().id;
            FindObjectOfType<EnzymeS>().EnzimeMeetStorageSend(enzimeId, storageId);
        }
        if(other.gameObject.tag == "SignalTo")
        {           
            int signalTo = other.GetComponent<DataScript>().id;
            FindObjectOfType<EnzymeS>().EnzimeMeetSignalToSend(enzimeId, signalTo);          
        }
    }
}
