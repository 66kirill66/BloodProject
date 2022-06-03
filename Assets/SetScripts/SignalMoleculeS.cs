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
    bool addScipt = false;
    //int resNum;



     InsulinReceptorS receptor;

    void Start()
    {
        //sigCount = 2;
        carrentCount = 0;
        receptor = GetComponent<InsulinReceptorS>();
        
    }

    void Update()
    {
        if(sigCount > 10 && carrentCount < sigCount)
        {
            sigCount = 10;
            InstSignalM();      
        }
        else if(sigCount <= 10 && carrentCount < sigCount)
        {
            InstSignalM();
        }
        Invoke("GoToChannal", 0.1f);     // GoToChannal();
    }
    

    private void GoToChannal()
    {
        if(receptor.receptorList.Count > signalMList.Count)
        {
            foreach (GameObject i in receptor.receptorList)
            {
                int num = 0;
                for (int j = 0; j < sigCount; j++)
                {
                    signalMList[num].transform.position = receptor.receptorList[num].transform.position;
                    num++;
                }                
            }
        }
        else if(receptor.receptorList.Count <= signalMList.Count && addScipt == false)
        {
            foreach (GameObject i in receptor.receptorList)
            {
                int num = 0;
                for (int j = 0; j < receptor.receptorList.Count; j++)
                {
                    signalMList[num].transform.position = receptor.receptorList[num].transform.position;
                    num++;
                }
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
            lest.AddComponent<SignalFinder>();
            count++;
        }
        addScipt = true;
    }

    public void InstSignalM()
    {
        for (int i = 0; i < sigCount; i++)
        {
            GameObject sig = Instantiate(signalM, place.position, transform.rotation);
            signalMList.Add(sig);
            carrentCount++;
        }        
    }
    public void AddSignalMolecule(int id)
    {
        this.id = id;
        sigCount++;      
    }
}
