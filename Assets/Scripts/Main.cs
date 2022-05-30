using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{
    [SerializeField] GameObject checkerColor;  // Buttone


    private void Start()
    {       
       
    }
    void Update()
    {
              
             
    }
    
     
    public void Calculate()  // Button
    {       
        StartCoroutine(ChekBlood());
    }
    IEnumerator ChekBlood()  // Button
    {
        checkerColor.GetComponent<MeshRenderer>().material.color = Color.red;
        yield return new WaitForSeconds(1);
        checkerColor.GetComponent<MeshRenderer>().material.color = Color.white;
    }
}
