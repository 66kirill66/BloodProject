using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReceptorFinder : MonoBehaviour
{

    //  public bool isFree = true; 



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Signal")
        {
            ReceptorFinder rec = GetComponent<ReceptorFinder>();
            Destroy(rec);
        }
    }
}
