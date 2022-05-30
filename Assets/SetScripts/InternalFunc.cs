using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public class InternalFunc : MonoBehaviour
{

    [DllImport("__Internal")]
    public static extern void callTNITfunction();  // globals.init function
   
    void Start()
    {
        if (!Application.isEditor)
        {
            callTNITfunction();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
