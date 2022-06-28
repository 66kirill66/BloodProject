using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignalGoToReceptor : MonoBehaviour
{
    public bool isFree;
    public bool haveReceptor;
    InsulinReceptorS insulinReceptor;

    void Awake()
    {
        isFree = true;
        haveReceptor = false;
        insulinReceptor = FindObjectOfType<InsulinReceptorS>();

    }

    void Start()
    {
       
    }
      
    void Update()
    {
        if(isFree == true)
        {           
            foreach(GameObject i in insulinReceptor.receptorList)
            {
                if(i.GetComponent<ReceptorFinder>().signalM == false)
                {
                    haveReceptor = true;
                    isFree = false;
                    transform.position = i.transform.position;
                    i.GetComponent<ReceptorFinder>().signalM = true;
                    i.GetComponent<ReceptorFinder>().mol = gameObject;
                    break;
                }                
            }
        }
        if (isFree == true && haveReceptor == false)
        {
            isFree = false;
            gameObject.AddComponent<SignalMolMove>();            
        }

    }
}
