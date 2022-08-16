using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public class SignalMoleculeToS : MonoBehaviour
{
    [DllImport("__Internal")]
    public static extern void CreateRequestNewSignalMTo(int receptorId);

    //[DllImport("__Internal")]
    //public static extern void ApplyMeetChannel(int signalId, int channelId);



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
        //SignallAdd(4);
        //SignallAdd(4);


    }
    public void CreateNewSignalMTo(int receptorId)   // send receptor Id 
    {
        Debug.Log(receptorId);
        if (!Application.isEditor)
        {
            CreateRequestNewSignalMTo(receptorId);
        }
    }

    //public void SignalMeetChannel(int signal, int chanId)   // Send To WEB
    //{
    //    if (!Application.isEditor)
    //    {
    //       // ApplyMeetChannel(signal, chanId);
    //    }
    //}

    private void SignallAdd(int id)
    {
        GameObject sig = Instantiate(signalM, place.transform.position, signalM.transform.rotation);
        signalMList.Add(sig);
        sig.AddComponent<DataScript>().id = id;
        sig.AddComponent<SignalToGoToReceptor>();
    }

    public void ResetSignalMToSimulation()
    {
        foreach (GameObject i in signalMList)
        {
            Destroy(i);
        }
        signalMList.Clear();
    }

    public void AddSignalMoleculeTo(string json)
    {
        SignalMData data = SignalMData.CreateFromJSON(json);
        if (data.receptorId != -1)
        {
            foreach (GameObject i in FindObjectOfType<GlucagonReceptorS>().receptorList)
            {
                if (data.receptorId == i.GetComponent<DataScript>().id)
                {
                    i.GetComponent<GlucagonReceptorLogic>().signalM = true;
                    GameObject sig = Instantiate(signalM, i.transform.position, signalM.transform.rotation);
                    i.GetComponent<GlucagonReceptorLogic>().mol = sig;
                    signalMList.Add(sig);
                    sig.AddComponent<DataScript>().id = data.id;
                }
            }
        }
        if (data.receptorId == -1 && signalMList.Count < 10)  // 10 signals max (Plethora logics)
        {
            GameObject sig = Instantiate(signalM, place.position, signalM.transform.rotation);
            signalMList.Add(sig);
            sig.AddComponent<DataScript>().id = data.id;
            sig.AddComponent<SignalToGoToReceptor>();
        }
    }
}
