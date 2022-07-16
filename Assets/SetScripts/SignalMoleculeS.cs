using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public class SignalMoleculeS : MonoBehaviour
{
    [DllImport("__Internal")]
    public static extern void CreateRequestNewSignalM(string json);

    [DllImport("__Internal")]
    public static extern void ApplyMeetChannel(int signalId, int channelId);



    public List<GameObject> signalMList = new List<GameObject>();
    public GameObject signalM;
    [SerializeField] Transform place;
    public int sigCount;
    bool addScipt = false; // Rundom Move
    InsulinReceptorS receptor;

    public class SignalMData
    {
        public int id;
        public int receptorId;
        public static SignalMData CreateFromJSON(string json)
        {
            SignalMData sigData = JsonUtility.FromJson<SignalMData>(json);
            return sigData;
        }
    }
    
    void Start()
    {   
        //SignallAdd(1);
        //SignallAdd(2);
        //SignallAdd(3);
        //SignallAdd(4);
        //SignallAdd(5);
        //SignallAdd(6);
        //SignallAdd(1);
        //SignallAdd(2);
        //SignallAdd(3);
        //SignallAdd(4);
        //SignallAdd(5);
        //SignallAdd(6);
        //SignallAdd(1);
        //SignallAdd(2);
        //SignallAdd(3);
        //SignallAdd(4);
        //SignallAdd(5);
        //SignallAdd(6);


    }

    void Update()
    {
       
    }

    public void CreateNewSignalM(string json)   // send receptor Id 
    {
        if (!Application.isEditor)
        {
            CreateRequestNewSignalM(json);
        }      
    }

    public void SignalMeetChannel(int signal,int chanId)   // Send To WEB
    {
        if (!Application.isEditor)
        {
            ApplyMeetChannel(signal, chanId);
        }
    }

    private void SignallAdd(int id)
    {
        GameObject sig = Instantiate(signalM, place.position, signalM.transform.rotation);
        signalMList.Add(sig);
        sig.AddComponent<DataScript>().id = id;
        sig.AddComponent<SignalGoToReceptor>();
    }

    public void AddSignalMolecule(string json)   
    {
        SignalMData data = SignalMData.CreateFromJSON(json);
        if (data.receptorId != -1)
        {
            foreach (GameObject i in GetComponent<InsulinReceptorS>().receptorList)
            {
                if (data.receptorId == i.GetComponent<DataScript>().id)
                {
                    GameObject sig = Instantiate(signalM, i.transform.position, signalM.transform.rotation);
                    signalMList.Add(sig);
                    i.GetComponent<ReceptorFinder>().signalM = true;
                    sig.AddComponent<DataScript>().id = data.id;
                }
            }
        }
        if (data.receptorId == -1)  //sigCount < 10 && 
        {
            GameObject sig = Instantiate(signalM, place.position, signalM.transform.rotation);
            signalMList.Add(sig);
            sig.AddComponent<DataScript>().id = data.id;
            sig.AddComponent<SignalGoToReceptor>();
            // Invoke("GoToChannal", 0.2f);
            sigCount++;
        }
    }
}
