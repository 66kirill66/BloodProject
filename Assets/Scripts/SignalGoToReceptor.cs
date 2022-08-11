using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignalGoToReceptor : MonoBehaviour
{
    public bool isFree;
    public bool haveReceptor;
    public int recId;
    InsulinReceptorS insulinReceptor;

    void Awake()
    {
        isFree = true;
        haveReceptor = false;
        insulinReceptor = FindObjectOfType<InsulinReceptorS>();
    }
    void Update()
    {
        if(isFree == true && haveReceptor == false)
        {           
            foreach(GameObject i in insulinReceptor.receptorList)
            {
                if(i.GetComponent<InsulinReceptorLogic>().signalM == false && insulinReceptor.receptorList != null)
                {
                    haveReceptor = true;
                    isFree = false;
                    transform.position = i.transform.position;
                    i.GetComponent<InsulinReceptorLogic>().signalM = true;
                    i.GetComponent<InsulinReceptorLogic>().mol = gameObject;
                    break;
                }               
            }
        }
        if (isFree == true && haveReceptor == false)
        {
            isFree = false;
            gameObject.AddComponent<SignalMolMove>().movingPlace = "Mus";
        }
    }    
}
