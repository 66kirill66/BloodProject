using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReceptorFinder : MonoBehaviour
{

    public bool isFree = true;
    public bool signalM = false;
    public GameObject mol;
    public GameObject prifabSignalMolecule;
    private void Start()
    {
        prifabSignalMolecule = FindObjectOfType<SignalMoleculeS>().signalM;
    }
    private void Update()
    {
       
    }
   
    private void ActiveTrue()
    {
        gameObject.SetActive(true);
        isFree = true;
    }
    private void ActiveFalse()
    {      
        gameObject.SetActive(false);
        Invoke("ActiveTrue", 3);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Insulin")
        {
            Invoke("ActiveFalse", 1);          
        }
    }
}
