using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;
using UnityEngine.UI;

public class InternalFunc : MonoBehaviour
{

    [SerializeField] GameObject liverText;
    [SerializeField] GameObject MusculeText;
    [SerializeField] GameObject pancreasText;
    

    [DllImport("__Internal")]
    public static extern void callTNITfunction();  // globals.init function

    void Start()
    {
        if (!Application.isEditor)
        {           
            callTNITfunction();           
        }

        ////This checks if your computer's operating system is in the Hebrew language
        //if (Application.systemLanguage == SystemLanguage.Hebrew)
        //{
        //    //Outputs into console that the system is Hebrew
        //    Debug.Log("This system is in Hebrew. "+ Application.systemLanguage);
        //}

    }

    void Update()
    {
        
    }
    public void SetLanguage(string lang)
    {
        Debug.Log("----------" + lang + "----------");
        if(lang == "he" || lang == "HE")
        {
            liverText.GetComponent<RTLTMPro.RTLTextMeshPro>().text  = "כבד";
            pancreasText.GetComponent<RTLTMPro.RTLTextMeshPro>().text = "לבלב";
            MusculeText.GetComponent<RTLTMPro.RTLTextMeshPro>().text = "שריר";

        }
        if (lang == "en" || lang == "EN")
        {
            liverText.GetComponent<RTLTMPro.RTLTextMeshPro>().text = "liver";
            pancreasText.GetComponent<RTLTMPro.RTLTextMeshPro>().text = "Pancreas";
            MusculeText.GetComponent<RTLTMPro.RTLTextMeshPro>().text = "Muscule";
        }
        else { return; }
    }
    
}
