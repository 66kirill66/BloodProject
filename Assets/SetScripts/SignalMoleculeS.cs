using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignalMoleculeS : MonoBehaviour
{
    int id; // Create Id
    public List<GameObject> signalMList = new List<GameObject>();
    public GameObject signalM;
    [SerializeField] Transform place;
    int sigCount;
    bool addScipt = false; // Rundom Move
    InsulinReceptorS receptor;



    void Start()
    {   
        receptor = GetComponent<InsulinReceptorS>();
        //AddSignalMolecule(1);
        //AddSignalMolecule(1);
        //AddSignalMolecule(1);
        //AddSignalMolecule(1);
    }

    void Update()
    {
        
        Invoke("GoToChannal", 0.2f);
    }


    private void GoToChannal()
    {
        if(receptor.receptorList.Count > signalMList.Count)
        {
            int num = 0;
            for (int i = 0; i < sigCount; i++)
            {                
                signalMList[num].transform.position = receptor.receptorList[num].transform.position;
                receptor.receptorList[num].GetComponent<ReceptorFinder>().mol = signalMList[num];
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
                receptor.receptorList[num].GetComponent<ReceptorFinder>().mol = signalMList[num];
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
}
