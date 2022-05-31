using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignalMoleculeS : MonoBehaviour
{
    int id;
    public List<GameObject> signalMList = new List<GameObject>();
    [SerializeField] GameObject signalM;
    [SerializeField] Transform place;

    void Start()
    {
        ChannelS ch = FindObjectOfType<ChannelS>();
        List<GameObject> list = ch.channelList;

       InvokeRepeating("AddSignalMolecule", 3, 4);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddSignalMolecule()
    {
       // this.id = id;
        GameObject sig = Instantiate(signalM,place.position,transform.rotation);
        sig.gameObject.AddComponent<SignalFinder>();
        signalMList.Add(sig);
    }
}
