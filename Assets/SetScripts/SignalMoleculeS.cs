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

    void Start()
    {
        carrentCount = 0;
       // sigCount = 10;
        StartCoroutine(SignalInstant());
    }

    void Update()
    {
        
    }
    IEnumerator SignalInstant()
    {
        while(sigCount > carrentCount)
        {
            carrentCount++;
            GameObject sig = Instantiate(signalM, place.position, transform.rotation);
            sig.gameObject.AddComponent<SignalFinder>();
            signalMList.Add(sig);
            yield return new WaitForSeconds(3);
        }
        
    }
    

    public void AddSignalMolecule(int id)
    {
        this.id = id;
        sigCount++;      
    }
}
