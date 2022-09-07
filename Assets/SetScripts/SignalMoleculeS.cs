using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public class SignalMoleculeS : MonoBehaviour
{
    [DllImport("__Internal")]
    public static extern void SetSignalAttachedToReceptor(bool val,int signalId);

    [DllImport("__Internal")]
    public static extern void CreateRequestNewSignalM(int receptorId);

    [DllImport("__Internal")]
    public static extern void ApplyMeetChannel(int signalId, int channelId);

    [DllImport("__Internal")]
    public static extern void SetSignalLevel(int signalId);
    
    public List<GameObject> signalMList = new List<GameObject>();
    public GameObject signalM;
    [SerializeField] Transform place;

    public class SignalMData
    {
        public int id;
        public int receptorId;
        public SignalMData(int id, int receptorId)
        {
            this.id = id;
            this.receptorId = receptorId;
        }
        public static SignalMData CreateFromJSON(string json)
        {
            SignalMData sigData = JsonUtility.FromJson<SignalMData>(json);
            return sigData;
        }
        public string ToJsonString()
        {
            return JsonUtility.ToJson(this);
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
    public void SetSignalAttached(bool val, int signalId)   
    {
        if (!Application.isEditor)
        {
            SetSignalAttachedToReceptor(val, signalId);
        }
    }

    public void CreateNewSignalM(int receptorId)   // send receptor Id 
    {       
        Debug.Log(receptorId);
        if (!Application.isEditor)
        {
            CreateRequestNewSignalM(receptorId);
        }      
    }

    public void SignalMeetChannel(int signal,int chanId)   // Send To WEB (in SignalMolMove)
    {
        if (!Application.isEditor)
        {
            ApplyMeetChannel(signal, chanId);
        }
    }
    public void SetSignalLevelWeb(int signalId)   // Send To WEB (in SignalMolMove)
    {
        if (!Application.isEditor)
        {
            SetSignalLevel(signalId);
        }
    }
    private void SignallAdd(int id)  // chek
    {       
        GameObject sig = Instantiate(signalM, place.transform.position, signalM.transform.rotation);
        signalMList.Add(sig);
        sig.AddComponent<DataScript>().id = id;
        sig.AddComponent<SignalGoToReceptor>();
    }

    public void ResetSignalMSimulation()
    {       
        foreach (GameObject i in signalMList)
        {
            Destroy(i);
        }
        signalMList.Clear();
    }

    public void AddSignalMolecule(string json)   
    {
        SignalMData data = SignalMData.CreateFromJSON(json);
        if (data.receptorId != -1)
        {
            foreach (GameObject i in FindObjectOfType<InsulinReceptorS>().receptorList)
            {
                if (data.receptorId == i.GetComponent<DataScript>().id)
                {
                    i.GetComponent<InsulinReceptorLogic>().signalM = true;                   
                    GameObject sig = Instantiate(signalM, i.transform.position, signalM.transform.rotation);
                    i.GetComponent<InsulinReceptorLogic>().mol = sig;
                    signalMList.Add(sig);
                    sig.AddComponent<DataScript>().id = data.id;
                    SetSignalAttached(true, data.id);
                }
            }
        }
        if (data.receptorId == -1 && signalMList.Count < 10 && FindObjectOfType<MusculeS>().IsActive == true)  // 10 signals max (Plethora logics)  // new FindObjectOfType<MusculeS>().IsActive == true
        {
            GameObject sig = Instantiate(signalM, place.position, signalM.transform.rotation);
            signalMList.Add(sig);
            sig.AddComponent<DataScript>().id = data.id;
            sig.AddComponent<SignalGoToReceptor>();
        }
    }
}
