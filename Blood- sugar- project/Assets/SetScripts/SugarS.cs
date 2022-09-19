﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.InteropServices;


public class SugarS : MonoBehaviour
{
    [DllImport("__Internal")]
    public static extern void SugarMeetChannal(int sugrId, int channelId);
    [DllImport("__Internal")]
    public static extern void SugarMeetInsulinRec(int sugrId, int receptorId);
    [DllImport("__Internal")]
    public static extern void SugarMeetGlucagonRec(int sugrId, int receptorId);


    public  List<GameObject> bloodList = new List<GameObject>();
    public  List<GameObject> muscleList = new List<GameObject>();
    public  List<GameObject> liverleList = new List<GameObject>();
    public  List<GameObject> pancreasList = new List<GameObject>();
    public  List<GameObject> energeList = new List<GameObject>();
    [SerializeField] Transform createPlase;
    public GameObject person;
    public GameObject sugar;
    public Transform instPos;
    public Text sugarText;
    public GameObject sugarViwText;
    public int sugarAmount;
    public int sugarNumber; // energy Channel
    public int sugarNumberInMus; 

    public int addSugarPerson;
    float sugarPosX;
    float sugarPosY;
    [SerializeField] Mesh energy;
    bool sugarActive;


    int id;   // Web ID
    RaycastHit hit;

    public string newSugarPlace;
    public string oldSugarPlace;

    public class ChangeLocationData
    {
        public string oldPlace;
        public string newPlace;

        public static ChangeLocationData CreateFromJSON(string jsonString)
        {
            ChangeLocationData locationData = JsonUtility.FromJson<ChangeLocationData>(jsonString);
            return locationData;
        }
    }
    private void Awake()
    {
        sugarAmount = 0;
        sugarViwText.SetActive(false);
        person.SetActive(false);
        sugarActive = false;
    }

    void Start()
    {
        addSugarPerson = 0;
        sugarNumberInMus = 0;
        //person.SetActive(true);
        //sugarViwText.SetActive(true);
        //InstantiateSugar();

    }

    void Update()
    {
        ClickingOnPerson();
        SugarInMus();
       

        if (sugarAmount != bloodList.Count)
        {
            sugarAmount = bloodList.Count;
            SetSugarAmount();
            sugarText.text = (sugarAmount * 3).ToString();
        }

        //if (Input.GetMouseButtonDown(0))
        //{
        //    ToLiver(bloodList);
        //}

    }

    public void ChecNumberToEnergy()
    {
        if (sugarNumber >= 4)  //After the transition of sugar into the muscle 
        {
            sugarNumber -= 3;
            Invoke("Energy", 7);
        }
    }

    public void ResetSugarSimulation()
    {
        sugarAmount = 0;
        sugarNumber = 0;
        addSugarPerson = 0;
        sugarViwText.SetActive(false);
        person.SetActive(false);
        foreach(GameObject i in bloodList)
        {
            Destroy(i);
        }
        foreach (GameObject i in muscleList)
        {
            Destroy(i);
        }
        foreach (GameObject i in liverleList)
        {
            Destroy(i);
        }
        foreach (GameObject i in pancreasList)
        {
            Destroy(i);
        }
        foreach (GameObject i in energeList)
        {
            Destroy(i);
        }
        energeList.Clear();
        bloodList.Clear();
        muscleList.Clear();
        liverleList.Clear();
        pancreasList.Clear();
        sugarNumberInMus = 0;
    }

    public void BloodChangeSugarLevel(int value)
    {       
        sugarText.text = value.ToString();
    }

    private void Energy()
    {
        if (muscleList.Count != 0)
        {
            for (int i = 0; i < 3; i++)
            {
                GameObject first = muscleList[0];               
                first.gameObject.tag = "Untagged";
                first.GetComponent<MoleculeMove>().StopCor();
                first.GetComponent<MoleculeMove>().MoveToBoyStart();
                first.GetComponent<MeshRenderer>().material.color = Color.red;  // Change Energy Color
                first.GetComponent<MeshFilter>().mesh = energy;
                first.transform.localScale = new Vector3(20, 20, 20); // Move To boy Vector
                Destroy(first, 3);
                muscleList.Remove(first);
                energeList.Add(first);
            }
        }
        else { return; }
    }

    public void SugarMeetChannalSend(int channelId)  // web
    {
        if (!Application.isEditor)
        {
            int sugarId = this.id;
            SugarMeetChannal(sugarId, channelId);
        }        
    }
    public void SugarMeetInsulinReceptor(int receptorId)  // web
    {
        if (!Application.isEditor)
        {
            int sugarId = this.id;
            SugarMeetInsulinRec(sugarId, receptorId);
        }
    }
    public void SugarMeetGlucagonReceptor(int receptorId)  // web
    {
        if (!Application.isEditor)
        {
            int sugarId = this.id;
            SugarMeetGlucagonRec(sugarId, receptorId);
        }
    }

    private void ClickingOnPerson()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.gameObject.tag == "Person" && addSugarPerson < 28)
                {                   
                    person.gameObject.GetComponent<Animator>().SetTrigger("Eat");     // Animation Have Event To Create Sugar               
                }               
            }
        }
    }
    private void SugarInMus()  // Plethora logic
    {
        if (FindObjectOfType<MusculeS>().IsActive == true && sugarActive == true)
        {
            InstantiateSugarInMus();
        }
    }
    private void InstantiateSugarInMus()
    {       
        while (sugarNumberInMus < 16)
        {
            RundomPointMus();
            GameObject sug = Instantiate(sugar, new Vector3(sugarPosX, sugarPosY, -0.5f), sugar.transform.rotation);
            sug.transform.parent = createPlase;
            muscleList.Add(sug);
            sug.AddComponent<MoleculeMove>().StopCor();
            sug.GetComponent<MoleculeMove>().MusculeCorutine();
            sugarNumberInMus++;
        }
    }
    private void RundomPointMus()
    {
        sugarPosX = Random.Range(1f, 14f);
        sugarPosY = Random.Range(-1f, -4.6f);
    }
    public void InstantiateSugar()
    {
        int sugarInst = 0;

        while (sugarInst < 33)
        {            
            StartRundomPoint();
            GameObject sug = Instantiate(sugar, new Vector3(sugarPosX, sugarPosY, -0.5f), sugar.transform.rotation);
            sug.transform.parent = createPlase;
            bloodList.Add(sug);
            sug.AddComponent<MoleculeMove>();
            sugarInst++;   
        }
    }
    private void ChooseSugarIndex(List<GameObject> oldListName,List<GameObject>newListName)
    {
        // translates 4 objects from old to new. ( Plethora logics)
        for (int i = 0; i < 4; i++ )
        {
            if(oldListName.Count != 0)
            {
                GameObject first = oldListName[0];
                newListName.Add(first);
                oldListName.Remove(first);
            }            
        }     
    }
    
    public void SugarTransformPlace(string jsonData)  // Get From Web
    {
        ChangeLocationData data = ChangeLocationData.CreateFromJSON(jsonData);
        oldSugarPlace = data.oldPlace;
        newSugarPlace = data.newPlace;

        if (oldSugarPlace == "Blood" && newSugarPlace == "Muscle Cells ")
        {           
            ToMus(bloodList);
        }
        if (oldSugarPlace == "Liver Cells" && newSugarPlace == "Muscle Cells ")
        {
            ToMus(liverleList);
        }
        if (oldSugarPlace == "Pancreas Cells" && newSugarPlace == "Muscle Cells ")
        {
            ToMus(pancreasList);
        }
        if (oldSugarPlace == "Blood" && newSugarPlace == "Liver Cells")
        {           
            ToLiver(bloodList);
        }
        if (oldSugarPlace == "Muscle Cells " && newSugarPlace == "Liver Cells")
        {
            ToLiver(muscleList);
        }
        if (oldSugarPlace == "Pancreas Cells" && newSugarPlace == "Liver Cells")
        {
            ToLiver(pancreasList);
        }
        if (oldSugarPlace == "Liver Cells" && newSugarPlace == "Blood")
        {            
            ToBlood(liverleList);
        }
        if (oldSugarPlace == "Muscle Cells " && newSugarPlace == "Blood")
        {           
            ToBlood(muscleList);
        }
        if (oldSugarPlace == "Pancreas Cells" && newSugarPlace == "Blood")
        {           
            ToBlood(pancreasList);
        }
        if (oldSugarPlace == "Blood" && newSugarPlace == "Pancreas Cells" )
        {            
            ToPancreas(bloodList);
        }
        if (oldSugarPlace == "Muscle Cells " && newSugarPlace == "Pancreas Cells" )
        {
            ToPancreas(muscleList);
        }
        if (oldSugarPlace == "Liver Cells" && newSugarPlace == "Pancreas Cells" )
        {
            ToPancreas(liverleList);
        }          
    }
   
    private void ToMus(List<GameObject> from)
    {
        if(FindObjectOfType<MusculeS>().IsActive == true)
        {
            if (from.Count != 0)
            {
                ChooseSugarIndex(from, muscleList);
                foreach (GameObject i in muscleList)
                {
                    i.GetComponent<MoleculeMove>().StopCor();
                    i.GetComponent<MoleculeMove>().MusculeCorutine();
                }
                Invoke("Energy", 5);
            }
        }        
    }
    
    private void ToBlood(List<GameObject> from)
    {
        if (from.Count != 0)
        {
            ChooseSugarIndex(from, bloodList);
            foreach (GameObject i in bloodList)
            {
                i.gameObject.GetComponent<MoleculeMove>().StopCor();
                i.gameObject.GetComponent<MoleculeMove>().BloodCorutine();
            }
        }              
    }
    private void ToLiver(List<GameObject> from)
    {
        if (from.Count != 0)
        {
            ChooseSugarIndex(from, liverleList);
            foreach (GameObject i in liverleList)
            {
                i.gameObject.GetComponent<MoleculeMove>().StopCor();
                i.gameObject.GetComponent<MoleculeMove>().LiverCorutine();
            }
            Invoke("EnergyInLiver",5);
        }
    }
    private void EnergyInLiver() // new
    {
        // plethora logic 3 sugar go to energy and 1 go to Sugarstorage
        if (liverleList.Count != 0)
        {
            for (int i = 0; i < 1; i++)
            {               
                GameObject first = liverleList[0];
                first.gameObject.tag = "Untagged";
                first.GetComponent<MoleculeMove>().StopCor();
                first.GetComponent<MoleculeMove>().MoveToBoyStart();
                first.GetComponent<MeshRenderer>().material.color = Color.red;  // Change Energy Color
                first.GetComponent<MeshFilter>().mesh = energy;
                first.transform.localScale = new Vector3(20, 20, 20); // Move To boy Vector
                Destroy(first, 6);
                liverleList.Remove(first);
                energeList.Add(first);
            }
            liverleList[0].gameObject.GetComponent<MoleculeMove>().FindSugarStorage();
            liverleList.Remove(liverleList[0].gameObject);
        }
        else { return; }
    }
    private void ToPancreas(List<GameObject> from)
    {
        if (from.Count != 0)
        {
            ChooseSugarIndex(from, pancreasList);
            foreach (GameObject i in pancreasList)
            {
                i.gameObject.GetComponent<MoleculeMove>().StopCor();
                i.gameObject.GetComponent<MoleculeMove>().PancreasCorutine();
            }
        }
    }    
    private void SetSugarAmount()  // send to Web
    {
        if (!Application.isEditor)
        {
            BloodS bl = GetComponent<BloodS>();
            bl.SetSugarLevel(sugarAmount * 3);
        }
    }
    private void StartRundomPoint()
    {
       sugarPosX = Random.Range(-23f, 16.5f);
       sugarPosY = Random.Range(0.6f, 2f);
    }
    public void AddSugar(int id)  // web
    {
        this.id = id;
        person.SetActive(true);
        sugarViwText.SetActive(true);
        sugarActive = true;
        InstantiateSugar();
    }  
}