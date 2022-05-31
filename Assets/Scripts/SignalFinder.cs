using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignalFinder : MonoBehaviour
{
   public bool free = true;
    void Start()
    {


    }

    void Update()
    {             
        if(free == true)
        {
            var cH = FindObjectOfType<ChannelFinder>();
            if(cH.BusyCheck() == true)
            {
                transform.position = Vector3.Lerp(transform.position, cH.transform.position, 1);
                
            }
            free = false;
        }
    }

       
}
