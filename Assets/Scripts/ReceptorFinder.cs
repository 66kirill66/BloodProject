using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReceptorFinder : MonoBehaviour
{
    public bool isFree = true;
    public bool signalM = false;

    private void Start()
    {
       
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
        Invoke("ActiveTrue", 2);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Insulin")
        {
            Invoke("ActiveFalse", 1);                     
        }
    }

}
