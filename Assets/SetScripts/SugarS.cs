using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.InteropServices;


public class SugarS : MonoBehaviour
{
    [DllImport("__Internal")]
    public static extern void SugarMeetChannel(int sugrId, int channelId);


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
            ChangeLocationData locationData = JsonUtility.FromJson<ChangeLocationData>(jsonString);
            return locationData;
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

        if (sugarNumber >= 4)
        {
            sugarNumber -= 3;
            Invoke("Energy", 3f);
        }

        if (Input.GetMouseButtonDown(0))
        {
            ToMus(bloodList);
        }

        ClickingOnPerson();
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
        bloodList.Clear();
        muscleList.Clear();
        liverleList.Clear();
        pancreasList.Clear();
    }

    private void Energy()
    {
        if (muscleList.Count != 0)
        {
            for (int i = 0; i < 3; i++)
            {
                GameObject first = muscleList[0];
                muscleList.Remove(first);
                first.GetComponent<MoleculeMove>().StopCor();
                first.GetComponent<MoleculeMove>().MoveToBoyStart();
                first.GetComponent<MeshRenderer>().material.color = Color.red;  // Change Energy Color
                first.GetComponent<MeshFilter>().mesh = energy;
                first.transform.localScale = new Vector3(20, 20, 20);
                Destroy(first, 3);
            }
        }
    }

    public void SugarMeetChannelSend(int channelId)  // web
    {
        if (!Application.isEditor)
        {
            int sugarId = this.id;
            SugarMeetChannel(sugarId, channelId);
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
    
    public void SugarTransformPlace(string jsonData)  // Send To Web
    {
        ChangeLocationData data = ChangeLocationData.CreateFromJSON(jsonData);
        oldSugarPlace = data.oldPlace;
        newSugarPlace = data.newPlace;

        Debug.Log("----------SugarTransformPlace----------");

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
        if(from.Count != 0)
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
    public void ChangeToEnergy()  // Check New Metod up...
    {
        if(muscleList.Count != 0)
        {
            for (int i = 0; i < 3; i++)
            {
                GameObject lest = muscleList[muscleList.Count - 1];
                lest.GetComponent<MoleculeMove>().StopCor();
                lest.GetComponent<MoleculeMove>().MoveToBoyStart();
                lest.GetComponent<MeshRenderer>().material.color = Color.red;  // Change Energy Color
                lest.GetComponent<MeshFilter>().mesh = energy;
                lest.transform.localScale = new Vector3(20, 20, 20);               
                Destroy(lest, 3);
                muscleList.Remove(lest);
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
       sugarPosX = Random.Range(-23f, 16.5f);
       sugarPosY = Random.Range(0.6f, 2f);
    }
    public void AddSugar(int id)  // web
    {
        this.id = id;
        person.SetActive(true);
        sugarViwText.SetActive(true);
        InstantiateSugar();
    }  
}
