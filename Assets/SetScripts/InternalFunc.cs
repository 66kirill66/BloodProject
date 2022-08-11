using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;
using UnityEngine.UI;

public class InternalFunc : MonoBehaviour
{

    [SerializeField] Text liverText;
    [SerializeField] Text MusculeText;
    [SerializeField] Text pancreasText;

    [DllImport("__Internal")]
    public static extern void callTNITfunction();  // globals.init function

    void Start()
    {       
        if (!Application.isEditor)
        {           
            callTNITfunction();           
        }      
    }

    void Update()
    {
        
    }
    public void SetLanguage(string lang)
    {
        Debug.Log("----------" + lang + "----------");
        if(lang == "HE")
        {
            liverText.text = "דבכ";
            pancreasText.text = "בלבל";
            MusculeText.text = "רירש";
        }
        else { return; }
    }
}
