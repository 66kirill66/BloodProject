using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;


public class BloodS : MonoBehaviour
{

    [DllImport("__Internal")]
    public static extern void ClickFunc(int id);  // On Click

    [DllImport("__Internal")]
    public static extern void SetSugarLevelNew(int id, int value);

    [DllImport("__Internal")]
    public static extern void SetInsulinLevelNew(int id, int value);

    [DllImport("__Internal")]
    public static extern void SetGlucagonLevelNew(int id, int value);


    public GameObject bloodSprite;
    public GameObject glucometerSprite;
    public GameObject bloodVessel ;

    RaycastHit hit; 
    int id;  // Web ID
   
    private void Awake()
    {        
        //sprites
        glucometerSprite.SetActive(false);
        bloodSprite.SetActive(false);
        bloodVessel.SetActive(false);

    }
    void Start()
    {
        //bloodSprite.SetActive(true);
        //GlucometerSprite.SetActive(true);
       // bloodVessel.SetActive(true);
    }

    void Update()
    {    
        ClickingBlood();
    }  
    private void ClickingBlood()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.gameObject.tag == "Blood")
                {
                    if (!Application.isEditor)
                    {
                        ClickFunc(id);
                    }                  
                }
            }
        }
    }

    public void ResetBloodSimulation()
    {
        glucometerSprite.SetActive(false);
        bloodSprite.SetActive(false);
        bloodVessel.SetActive(false);
    }
    public void AddBlood(int id)
    {
        this.id = id;              
        bloodSprite.SetActive(true);
        glucometerSprite.SetActive(true);
        bloodVessel.SetActive(true);
    }

    public void SetSugarLevel(int newValue)
    {
        SetSugarLevelNew(this.id, newValue); 
    }
    public void SetInsulinLevel(int newValue)
    {
        SetInsulinLevelNew(this.id, newValue);
    }
    public void SetGlucagonLevel(int newValue)
    {
        SetGlucagonLevelNew(this.id, newValue);
    }

}
