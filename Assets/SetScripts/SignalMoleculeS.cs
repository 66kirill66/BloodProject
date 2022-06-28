using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public class SignalMoleculeS : MonoBehaviour
{
    [DllImport("__Internal")]
    public static extern void CreateRequestNewSignalM(string json);  

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
        receptor = GetComponent<InsulinReceptorS>();
        SignallAdd(1);
        SignallAdd(2);
        SignallAdd(3);
        SignallAdd(4);
        SignallAdd(5);
        SignallAdd(6);


    }

    void Update()
    {
        
       // Invoke("GoToChannal", 0.2f);
    }


    private void GoToChannal()
    {
        if(receptor.receptorList.Count > signalMList.Count)
        {
            int num = 0;
            for (int i = 0; i < sigCount; i++)
            {                
                signalMList[num].transform.position = receptor.receptorList[num].transform.position;
              //  receptor.receptorList[num].GetComponent<ReceptorFinder>().mol = signalMList[num];
                num++;
            }            
        }
        else if(receptor.receptorList.Count <= signalMList.Count && addScipt == false)
        {
            int num = 0;
            for (int i = 0; i < receptor.receptorList.Count; i++)
            {
                signalMList[num].transform.position = receptor.receptorList[num].transform.position;
                receptor.receptorList[num].GetComponent<ReceptorFinder>().signalM = true;
              //  receptor.receptorList[num].GetComponent<ReceptorFinder>().mol = signalMList[num];
                num++;
            }
            AddMovingScript();
        }       
    }

    private void AddMovingScript()
    {       
        int resNum = signalMList.Count - receptor.receptorList.Count;
        int count = 1;
        for (int i = 0; i < resNum; i++)
        {
            GameObject lest = signalMList[signalMList.Count - count];
            lest.AddComponent<SignalMolMove>();
            count++;
        }
        addScipt = true;
    }

    public void CreateNewSignalM(string json)   // send receptor Id 
    {
        if (!Application.isEditor)
        {
            CreateRequestNewSignalM(json);
        }      
    }

    private void SignallAdd(int id)
    {
        GameObject sig = Instantiate(signalM, place.position, signalM.transform.rotation);
        signalMList.Add(sig);
        sig.AddComponent<DataScript>().id = id;
    }

    public void AddSignalMolecule(string json)   
    {
        SignalMData data = SignalMData.CreateFromJSON(json);
       
        
        //if (data.receptorId != -1)
        //{
        //    foreach(GameObject i in GetComponent<InsulinReceptorS>().receptorList)
        //    {
        //        if(data.receptorId == i.GetComponent<DataScript>().id)
        //        {
        //            GameObject sig = Instantiate(signalM, i.transform.position, signalM.transform.rotation);
        //            signalMList.Add(sig);
        //            sig.AddComponent<DataScript>().id = data.id;
        //        }
        //    }          
        //}
        if (data.receptorId == -1)  //sigCount < 10 && 
        {

            GameObject sig = Instantiate(signalM, place.position, signalM.transform.rotation);
            signalMList.Add(sig);
            sig.AddComponent<DataScript>().id = data.id;
            // Invoke("GoToChannal", 0.2f);
            sigCount++;
        }

    }
}
