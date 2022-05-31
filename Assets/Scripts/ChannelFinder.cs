using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChannelFinder : MonoBehaviour
{
    public bool isFree = true;
    void Start()
    {
        
    }
  
    void Update()
    {
        
    }
    public bool BusyCheck()
    {
        return isFree;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Signal")
        {
            isFree = false;         
        }
    }

   
}
