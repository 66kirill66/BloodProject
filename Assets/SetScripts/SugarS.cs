using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SugarS : MonoBehaviour
{
    public  List<GameObject> bloodList = new List<GameObject>();
    public  List<GameObject> muscleList = new List<GameObject>();
    public  List<GameObject> liverleList = new List<GameObject>();
    [SerializeField] Transform createPlase;
    public GameObject person;
    public GameObject sugar;
    public Transform instPos;
    public Text sugarText;
    public GameObject sugarViwText;
    public int sugarAmount;
    //List<GameObject> newTransform  = new List<GameObject>();

    int addSugarPerson;
    float sugarPosX;
    float sugarPosY;
    [SerializeField] Mesh energy;

    int sugarNumMus = 4;
    public int countLiver;
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
            ChangeLocationData json = JsonUtility.FromJson<ChangeLocationData>(jsonString);
            return json;
        }
    }


    private void Awake()
    {      
        sugarViwText.SetActive(false);
        person.SetActive(false);        
    }

    void Start()
    {
        countLiver = liverleList.Count;
        addSugarPerson = 0;
        //person.SetActive(true);
        //sugarViwText.SetActive(true);
        InstantiateSugar();

        ChooseSugarIndex(bloodList, muscleList);
        ChooseSugarIndex(bloodList, liverleList);
    }

    void Update()
    {
        
        sugarText.text = (sugarAmount * 3).ToString();    //  Add Number to multiplication
        ClickingOnPerson();
        SugarTransToPoint(newSugarPlace);
        Energy();
        Liver();
        if (Input.GetMouseButtonDown(0))
        {
            
            BackToBlood(liverleList);
            ChooseSugarIndex(liverleList, bloodList);
        }        
    }
    

    private void ClickingOnPerson()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.gameObject.tag == "Sugar" && addSugarPerson < 28)
                {
                    int sug = 0;
                    person.gameObject.GetComponent<Animator>().SetTrigger("Eat");                 
                    while (sug < 2)
                    {                       
                        GameObject sugarInst = Instantiate(sugar, instPos.position, transform.rotation);
                        sugarInst.transform.parent = createPlase;
                        bloodList.Add(sugarInst);
                        sugarInst.AddComponent<MoleculeMove>();
                        addSugarPerson++;                        
                        SetSugarAmountUP(1);           
                        sug++;                       
                    }
                }               
            }
        }
    }

    public void InstantiateSugar()
    {
        int sugarInst = 0;

        while (sugarInst < 33)
        {            
            RundomPoint();
            GameObject sug = Instantiate(sugar, new Vector3(sugarPosX, sugarPosY, -0.5f), sugar.transform.rotation);
            sug.transform.parent = createPlase;
            bloodList.Add(sug);
            sug.AddComponent<MoleculeMove>();
            sugarInst++;   
            sugarAmount = sugarInst;
        }
    }
    private void ChooseSugarIndex(List<GameObject> oldListName,List<GameObject>newListName)
    {       
       for(int i = 0; i < 4; i++ )
        {
            if(oldListName != null)
            {
                GameObject first = oldListName[0];
                newListName.Add(first);
                oldListName.Remove(first);
            }            
        }     
    }
    
    public void SugarTransformPlace(string jsonData)
    {
        ChangeLocationData data = ChangeLocationData.CreateFromJSON(jsonData);
        oldSugarPlace = data.oldPlace;
        newSugarPlace = data.newPlace;

        if (oldSugarPlace == "Blood" && newSugarPlace == "Muscle Cells ")
        {
            SetSugarAmountDown(4);
            ChooseSugarIndex(bloodList, muscleList);            
        }
        if (oldSugarPlace == "Blood" && newSugarPlace == "Liver Cells")
        {
            SetSugarAmountDown(4);
            ChooseSugarIndex(bloodList, liverleList);
        }
        if (oldSugarPlace == "Liver Cells" && newSugarPlace == "Blood")
        {
            ChooseSugarIndex(liverleList ,bloodList);
        }
        if (oldSugarPlace == "Liver Cells" && newSugarPlace == "Muscle Cells ")
        {
            ChooseSugarIndex(liverleList, muscleList);
        }
        if (oldSugarPlace == "Muscle Cells " && newSugarPlace == "Liver Cells")
        {
            ChooseSugarIndex(muscleList,liverleList);
        }
        if (oldSugarPlace == "Muscle Cells " && newSugarPlace == "Blood")
        {
            ChooseSugarIndex(liverleList, muscleList);
        }       
    }

    public void SugarTransToPoint(string newNameP)
    {
        switch (newNameP)
        {
            case "Muscle Cells ":    
                foreach(GameObject i in muscleList)
                {
                  //  Invoke("RundomMusPoint", 0.5f);  // update
                }
                
                break;
            case "Liver Cells":
                foreach (GameObject i in liverleList)
                {
                  
                }
                break;
            case "Blood":
                foreach (GameObject i in bloodList)
                {
                    
                }
                break;
        }
    }

    private void Liver()
    {
        
        if(countLiver < liverleList.Count )
        {
            Invoke("RundomLiverPoint", 0.5f);    
        }
        
    }
    

    public void Energy()
    {
        if (muscleList.Count >= sugarNumMus)
        {
            ChangeToEnergy();
            sugarNumMus++;
        }        
    }

    private void ChangeToEnergy()
    {
        for (int i = 0; i < 3; i++)
        {
            GameObject lest = muscleList[muscleList.Count - 1];
            lest.gameObject.GetComponent<MeshRenderer>().material.color = Color.blue;
            lest.gameObject.GetComponent<MeshFilter>().mesh = energy;
            lest.transform.localScale = new Vector3(20, 20, 20);
            lest.gameObject.GetComponent<MoleculeMove>().MoveToBoyStart();
            Destroy(lest, 3);
            muscleList.Remove(lest);
            Invoke("RundomMusPoint", 0.5f); // onse
        }       
    }
    private void RundomMusPoint()
    {
        GameObject lest = muscleList[muscleList.Count - 1];
        lest.gameObject.GetComponent<MoleculeMove>().RandomPointInMus();
    }

    private void RundomLiverPoint()
    {
        countLiver = liverleList.Count;
        foreach (GameObject i in liverleList)
        {
            i.gameObject.GetComponent<MoleculeMove>().RandomPointInLiver();
        }
    }
    private void BackToBlood(List<GameObject> from)
    {
        foreach (GameObject i in from)
        {
            i.gameObject.GetComponent<MoleculeMove>().BloodLoopON();
        }
    }
    private void SetSugarAmountDown(int num)   // send to Web
    {
        sugarAmount -= num;
        if (!Application.isEditor)
        {
            BloodS bl = GetComponent<BloodS>();
            bl.SetSugarLevel(sugarAmount * 3);
        }
    }
    private void SetSugarAmountUP(int num)  // send to Web
    {
        sugarAmount += num;
        if (!Application.isEditor)
        {
            BloodS bl = GetComponent<BloodS>();
            bl.SetSugarLevel(sugarAmount * 3);
        }
    }
    private void RundomPoint()
    {
       sugarPosX = Random.Range(-17f, 17);
       sugarPosY = Random.Range(0, 1.5f);
    }
    public void AddSugar(int id)
    {
        this.id = id;
        person.SetActive(true);
        sugarViwText.SetActive(true);
        sugarViwText.SetActive(true);
        InstantiateSugar();
    }
}
