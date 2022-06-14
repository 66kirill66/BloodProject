using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SugarS : MonoBehaviour
{
    public  List<GameObject> bloodList = new List<GameObject>();
    public  List<GameObject> muscleList = new List<GameObject>();
    public  List<GameObject> liverleList = new List<GameObject>();
    public  List<GameObject> pancreasList = new List<GameObject>();
    [SerializeField] Transform createPlase;
    public GameObject person;
    public GameObject sugar;
    public Transform instPos;
    public Text sugarText;
    public GameObject sugarViwText;
    public int sugarAmount;
    public int sugarNumber;

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
        sugarAmount = 0;

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
        if(sugarAmount != bloodList.Count)
        {
            sugarAmount = bloodList.Count;
            SetSugarAmount();
            sugarText.text = (sugarAmount * 3).ToString();
        }

        

        ClickingOnPerson();

        //if (Input.GetMouseButtonDown(0))
        //{
            

        //}
        //else if (Input.GetMouseButtonDown(1))
        //{
        //    ToMus(bloodList);
        //}
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
                       // SetSugarAmount();           
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
            StartRundomPoint();
            GameObject sug = Instantiate(sugar, new Vector3(sugarPosX, sugarPosY, -0.5f), sugar.transform.rotation);
            sug.transform.parent = createPlase;
            bloodList.Add(sug);
           // SetSugarAmount();
            sug.AddComponent<MoleculeMove>();
            sugarInst++;   
        }
    }
    private void ChooseSugarIndex(List<GameObject> oldListName,List<GameObject>newListName)
    {       
       for(int i = 0; i < 4; i++ )
        {
            if(oldListName.Count != 0)
            {
                GameObject first = oldListName[0];
                newListName.Add(first);
                oldListName.Remove(first);
            }            
        }     
    }
    
    public void SugarTransformPlace(string jsonData)  // Send To Web
    {
        ChangeLocationData data = ChangeLocationData.CreateFromJSON(jsonData);
        oldSugarPlace = data.oldPlace;
        newSugarPlace = data.newPlace;

        if (oldSugarPlace == "Blood" && newSugarPlace == "Muscle Cells ")
        {           
            ToMus(bloodList);
           // SetSugarAmount();
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
            //SetSugarAmount();
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
           // SetSugarAmount();
        }
        if (oldSugarPlace == "Muscle Cells " && newSugarPlace == "Blood")
        {           
            ToBlood(muscleList);
            //SetSugarAmount();
        }
        if (oldSugarPlace == "Pancreas Cells" && newSugarPlace == "Blood")
        {           
            ToBlood(pancreasList);
            //SetSugarAmount();
        }
        if (oldSugarPlace == "Blood" && newSugarPlace == "Pancreas Cells" )
        {            
            ToPancreas(bloodList);
            //SetSugarAmount();
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

    private void ChangeToEnergy()
    {
        for (int i = 0; i < 3; i++)
        {
            GameObject lest = muscleList[muscleList.Count - 1];
            lest.gameObject.GetComponent<MeshRenderer>().material.color = Color.red;  // Change Energy Color
            lest.gameObject.GetComponent<MeshFilter>().mesh = energy;
            lest.transform.localScale = new Vector3(20, 20, 20);
            lest.gameObject.GetComponent<MoleculeMove>().StopCor();
            lest.gameObject.GetComponent<MoleculeMove>().MoveToBoyStart();
            Destroy(lest, 3);
            muscleList.Remove(lest);
        }      
    }
    private void ToMus(List<GameObject> from)
    {
        if(from.Count != 0)
        {
            ChooseSugarIndex(from, muscleList);
            foreach (GameObject i in muscleList)
            {
                i.gameObject.GetComponent<MoleculeMove>().StopCor();
                i.gameObject.GetComponent<MoleculeMove>().MusculeCorutine();
            }
            Invoke("ChangeToEnergy",5);
        }     
    }
    private void ToLiver(List<GameObject> from)
    {
        if(from.Count != 0)
        {
            ChooseSugarIndex(from, liverleList);
            foreach (GameObject i in liverleList)
            {
                i.gameObject.GetComponent<MoleculeMove>().StopCor();
                i.gameObject.GetComponent<MoleculeMove>().LiverCorutine();
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
