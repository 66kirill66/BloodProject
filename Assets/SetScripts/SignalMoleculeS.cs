using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignalMoleculeS : MonoBehaviour
{
    int id;
    public List<GameObject> signalMList = new List<GameObject>();
    [SerializeField] GameObject signalM;
    [SerializeField] Transform place;
    int sigCount;
    int carrentCount;
    bool addScipt = false; // Rundom Move
    InsulinReceptorS receptor;

    public class SignalMData
    {
        public int signalID;
        public static SignalMData CreateFromJSON(string jsonString)
        {
            SignalMData sigID = JsonUtility.FromJson<SignalMData>(jsonString);
            return sigID;
        }
    }

    void Start()
    {
        carrentCount = 0;       
        receptor = GetComponent<InsulinReceptorS>();
      
    }

    void Update()
    {
        //if(sigCount > 10 && carrentCount < sigCount)
        //{
        //    sigCount = 10;
        //    InstSignalM();      
        //}
        //else if(sigCount <= 10 && carrentCount < sigCount)
        //{
        //    InstSignalM();
        //}
        Invoke("GoToChannal", 0.2f);
    }


    private void GoToChannal()
    {
        if(receptor.receptorList.Count > signalMList.Count)
        {
            int num = 0;
            for (int j = 0; j < sigCount; j++)
            {
                signalMList[num].transform.position = receptor.receptorList[num].transform.position;
                num++;
            }
        }
        else if(receptor.receptorList.Count <= signalMList.Count && addScipt == false)
        {
            int num = 0;
            for (int j = 0; j < receptor.receptorList.Count; j++)
            {
                signalMList[num].transform.position = receptor.receptorList[num].transform.position;
                receptor.receptorList[num].GetComponent<ReceptorFinder>().signalM = true;
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


    //public void InstSignalM()
    //{
    //    for (int i = 0; i < sigCount; i++)
    //    {
    //        GameObject sig = Instantiate(signalM, place.position, signalM.transform.rotation);
    //        signalMList.Add(sig);
    //        sig.AddComponent<DataScript>().id = this.id;
    //        carrentCount++;
    //    }        
    //}
    public void InstSignalM()
    {
        GameObject sig = Instantiate(signalM, place.position, signalM.transform.rotation);
        signalMList.Add(sig);
        sig.AddComponent<DataScript>().id = this.id;
    }
    public void AddSignalMolecule(int id)
    {
        if(sigCount < 10)
        {
            this.id = id;           
            InstSignalM();
            sigCount++;
        }
        
    }
    //public void AddSignalMolecule(string dataJson)
    //{
    //    SignalMData data = SignalMData.CreateFromJSON(dataJson);
    //    this.id = data.signalID;
    //    sigCount++;
    //}
}
