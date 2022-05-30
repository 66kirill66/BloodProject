using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SugarS : MonoBehaviour
{
    public  List<GameObject> blood = new List<GameObject>();
    public  List<GameObject> muscleList = new List<GameObject>();
    public  List<GameObject> sugarInmuscleL = new List<GameObject>();
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
        addSugarPerson = 0;
        //person.SetActive(true);
        //sugarViwText.SetActive(true);
        //InstantiateSugar();       
    }

    void Update()
    {       
        sugarText.text = (sugarAmount * 3).ToString();    //  Add Number to multiplication
        ClickingOnPerson();
        SugarTransToPoint(newSugarPlace);
       // SugarTransToPoint("Muscle Cells ");
        Energy();
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
                        blood.Add(sugarInst);
                        sugarInst.AddComponent<MoleculeMove>();
                        addSugarPerson++;                        
                        SetSugarAmountUP(1);           
                        sug++;                       
                    }
                    //ChooseSugarIndex(blood, muscleList);   // Check
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
            blood.Add(sug);
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
                first.GetComponent<MoleculeMove>().StopLoopBlood();
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
            ChooseSugarIndex(blood, muscleList);            
        }
        if (oldSugarPlace == "Blood" && newSugarPlace == "Liver Cells")
        {
            ChooseSugarIndex(blood, liverleList);
        }
        if (oldSugarPlace == "Liver Cells" && newSugarPlace == "Blood")
        {
            ChooseSugarIndex(liverleList ,blood);
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
                    i.GetComponent<MoleculeMove>().StopLoopBlood();
                }
                
                break;
            case "Liver Cells":
                


                break;
            case "Blood":
                foreach (GameObject i in liverleList)
                {
                    
                }
                break;
        }
    }
  
    public void Energy()
    {
        if (muscleList.Count >= 4)
        {
            GameObject first = muscleList[1];
            sugarInmuscleL.Add(first);
            muscleList.Remove(first);         
        }
        else if (muscleList.Count == 3)
        {
            Invoke("ChangeToEnergy", 2);           
        }        
    }

    private void ChangeToEnergy()
    {
        foreach (GameObject i in muscleList)
        {
            i.gameObject.GetComponent<MeshRenderer>().material.color = Color.blue;
            i.gameObject.GetComponent<MeshFilter>().mesh = energy;
            i.transform.localScale = new Vector3(20, 20, 20);
            i.gameObject.GetComponent<MoleculeMove>().MoveToBoyStart();
            Destroy(i, 3);
        }
        GameObject lest = sugarInmuscleL[sugarInmuscleL.Count - 1];
        lest.GetComponent<MoleculeMove>().RandomEndPointInMus();
        muscleList.Clear();
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
