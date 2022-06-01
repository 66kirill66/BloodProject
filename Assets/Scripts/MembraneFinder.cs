using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MembraneFinder : MonoBehaviour
{

    public bool isFree = true; 

    

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Signal")
        {
            MembraneFinder mem = GetComponent<MembraneFinder>();
            Destroy(mem);
        }
    }  
}
