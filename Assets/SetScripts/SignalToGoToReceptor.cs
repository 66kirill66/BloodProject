using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignalToGoToReceptor : MonoBehaviour
{
    public bool isFree;
    public bool haveReceptor;
    public int recId;
    GlucagonReceptorS insulinReceptor;

    void Awake()
    {
        isFree = true;
        haveReceptor = false;
        insulinReceptor = FindObjectOfType<GlucagonReceptorS>();
    }
    void Update()
    {
        if (isFree == true && haveReceptor == false)
        {
            foreach (GameObject i in insulinReceptor.receptorList)
            {
                if (i.GetComponent<GlucagonReceptorLogic>().signalM == false && insulinReceptor.receptorList != null)
                {
                    haveReceptor = true;
                    isFree = false;
                    transform.position = i.transform.position;
                    i.GetComponent<GlucagonReceptorLogic>().signalM = true;
                    i.GetComponent<GlucagonReceptorLogic>().mol = gameObject;
                    break;
                }               
            }
        }
        if (isFree == true && haveReceptor == false)
        {
            isFree = false;
            gameObject.AddComponent<SignalMolMove>().movingPlace = "Liver";
        }
    }
}
