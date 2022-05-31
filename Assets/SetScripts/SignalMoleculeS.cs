using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignalMoleculeS : MonoBehaviour
{
    int id;
    public List<GameObject> sinnalMList = new List<GameObject>();
    [SerializeField] GameObject signalM;
    [SerializeField] Transform place;

    void Start()
    {
       // InvokeRepeating("AddSignalMolecule", 3, 4);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddSignalMolecule(int id)
    {
        this.id = id;
        GameObject sig = Instantiate(signalM,place.position,transform.rotation);
        sig.gameObject.AddComponent<SignalFinder>();
        sinnalMList.Add(sig);
    }
}
