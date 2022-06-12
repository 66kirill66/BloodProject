using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReceptorFinder : MonoBehaviour
{
    public bool isFree = true;
    private void Start()
    {
       
    }
    private void Update()
    {
        
    }
 
    private void AcriveTrue()
    {
        gameObject.SetActive(true);
        isFree = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Insulin")
        {
            gameObject.SetActive(false);
            Invoke("AcriveTrue", 1);
        }
    }
}
