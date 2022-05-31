using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignalFinder : MonoBehaviour
{
    bool isFind = false;
    float speed;
    float traval;
    void Start()
    {
        speed = 3f;
        traval += Time.deltaTime * speed;
        Find();
    }

    void Update()
    {             
            
    }

    private void Find()
    {
        var ch = FindObjectsOfType<ChannelFinder>();
        foreach(ChannelFinder i in ch)
        {
            bool free = i.GetComponent<ChannelFinder>().BusyCheck();
            if (free == true)
            {
                Vector3 channalT = i.transform.position;
                Vector3 startP = transform.position;
                transform.position = i.transform.position;
                //transform.position = Vector3.Lerp(startP, channalT, traval);
            }
            else
            {
                return;
            }
        }
        



    }
    //private void OnTriggerEnter(Collider other)
    //{
    //    if(other.gameObject.tag == "Channel")
    //    {
    //        isFind = true;
    //    }
    //}
}
