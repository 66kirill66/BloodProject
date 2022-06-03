using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignalMoleculeS : MonoBehaviour
{
    int id;
    public List<GameObject> signalMList = new List<GameObject>();
    [SerializeField] GameObject signalM;
    [SerializeField] Transform place;
    public int sigCount;
    int carrentCount;
    bool inst = false;

    void Start()
    {
        carrentCount = 0;
    }

    void Update()
    {
        if (sigCount > carrentCount && inst == false)
        {
            StartCoroutine(SignalInstant());
        }
    }

    IEnumerator SignalInstant()
    {
        inst = true;
        carrentCount++;
        GameObject sig = Instantiate(signalM, place.position, transform.rotation);
        sig.gameObject.AddComponent<SignalFinder>();
        signalMList.Add(sig);
        yield return new WaitForSeconds(4);
        inst = false;
    }
    
    public void AddSignalMolecule(int id)
    {
        this.id = id;
        sigCount++;      
    }
}
