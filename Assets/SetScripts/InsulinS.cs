using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.InteropServices;



public class InsulinS : MonoBehaviour    
{
    [DllImport("__Internal")]
    public static extern void ApplyMeetReceptor(int insulinId, int receptorId);

    [SerializeField] Transform createPlase;
    public GameObject insulinSyringe;
    public Transform instPos;    
    public Transform pancreasPos;    
    public GameObject insulin;
    public Text insulinText;
    public GameObject insulinViwText;

    public List<GameObject> bloodList = new List<GameObject>();
    public List<GameObject> muscleList = new List<GameObject>();
    public List<GameObject> liverleList = new List<GameObject>();
    public List<GameObject> pancreasList = new List<GameObject>();


    float insulinPosX;
    float insulinPosY;
    RaycastHit hit;
    public int insulinAmount;
    public int id;  // Web ID

    bool sliderF;
    public Slider insulinFill;
    public GameObject insulinSlider;

    public string newInsulinPlace;
    public string oldInsulinPlace;

    private void Awake()
    {
        insulinAmount = 0;
        sliderF = false;
        insulinSlider.SetActive(false);
        insulinViwText.SetActive(false);
        insulinSyringe.SetActive(false);
    }

    void Start()
    {
        //InstantiateInsulin();      
        //insulinViwText.SetActive(true);
        //insulinSyringe.SetActive(true);
        //insulinSlider.SetActive(true);
    }

    void Update()
    {
        PancreasInsulin();
        

        if (insulinAmount != bloodList.Count)
        {
            insulinAmount = bloodList.Count;
            SetInsulinVal();
            insulinText.text = (insulinAmount * 2).ToString();
        }
        SliderAnim();
        ClickingInsulinSyringe();
    }

    
        

    private void PancreasInsulin()
    {
        if (FindObjectOfType<PancreasS>().pancreasActive == true)
        {
            if (pancreasList.Count < 4)
            {
                float PosX = Random.Range(1.5f, 6f);
                float PosY = Random.Range(3.5f, 9f);

                GameObject insul = Instantiate(insulin, new Vector3(PosX, PosY, -0.5f), insulin.transform.rotation);
                insul.transform.parent = createPlase;
                insul.AddComponent<MoleculeMove>();
                insul.GetComponent<MoleculeMove>().PancreasCorutine();
                insul.AddComponent<InsulinRecFinder>();
                pancreasList.Add(insul);
            }
        }        
    }

    private void ClickingInsulinSyringe()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.gameObject.tag == "InsulinSyringe")
                {                   
                    sliderF = true;
                }               
            }
        }
    }
    private void SliderAnim()
    {
        if(sliderF == true)
        {          
            insulinFill.value -= 1 * Time.deltaTime;
            if (insulinFill.value == 0)
            {               
                int supp = 0;   // supplement
                while (supp < 2)
                {
                    GameObject insul = Instantiate(insulin, instPos.position, transform.rotation);
                    insul.AddComponent<MoleculeMove>();
                    insul.AddComponent<InsulinRecFinder>();                    
                    insul.transform.parent = createPlase;
                    bloodList.Add(insul);
                    supp++;
                }               
                sliderF = false;
            }
        }
        else if(sliderF == false)
        {
            insulinFill.value += 1 * Time.deltaTime;
        }                   
    }

    public void InstantiateInsulin()
    {
        int insulinInst = 0;
        while (insulinInst < 12)
        {
            RundomPoint();
            GameObject insul = Instantiate(insulin, new Vector3(insulinPosX, insulinPosY, -0.5f), insulin.transform.rotation);
            insul.transform.parent = createPlase;
            insul.AddComponent<MoleculeMove>();
            insul.AddComponent<InsulinRecFinder>();
            bloodList.Add(insul);
            insulinInst++;
        }
    } 

    private void RundomPoint()   
    {
        insulinPosX = Random.Range(-17f, 17);
        insulinPosY = Random.Range(0, 1.5f);
    }

    public void BloodChangeGlucagonLevel(int value)
    {
        int difference;
        if (insulinAmount *2 != value)
        {
            if (value > insulinAmount * 2)
            {
                difference = value - insulinAmount * 2;
                Debug.Log(difference);
            }
            else if (value < insulinAmount * 2)
            {
                difference = insulinAmount * 2 - value;
                if (difference >= 10)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        if (bloodList.Count != 0)
                        {
                            GameObject ins = bloodList[0];
                            bloodList.Remove(ins);
                            Destroy(ins);
                        }
                    }
                }
                Debug.Log(difference);
            }
        }
        else if (value == 0)
        {
            foreach (GameObject i in bloodList)
            {
                Destroy(i);
            }
            bloodList.Clear();
            insulinAmount = 0;
        }
        insulinText.text = value.ToString();
    }

    private void SetInsulinVal()   // Send To WEB
    {
        if (!Application.isEditor)
        {
            BloodS bl = GetComponent<BloodS>();
            bl.SetInsulinLevel(insulinAmount * 2);
        }
    }
    public void InsulinMeetReseptor(int id)   // Send To WEB
    {
        if (!Application.isEditor)
        {
            ApplyMeetReceptor(this.id,id) ;
        }
    }

    public void ResetInsulinSimulation()
    {
        insulinAmount = 0;
        sliderF = false;
        insulinSlider.SetActive(false);
        insulinViwText.SetActive(false);
        insulinSyringe.SetActive(false);
        foreach (GameObject i in bloodList)
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

    public void AddInsulin(int id)   // Init func
    {
        this.id = id;
        insulinSyringe.SetActive(true);
        insulinViwText.SetActive(true);
        insulinSlider.SetActive(true);
        InstantiateInsulin();
    }

    private void ChooseInsulinIndex(List<GameObject> oldListName, List<GameObject> newListName, int num)
    {
        for (int i = 0; i < num; i++)
        {
            if (oldListName.Count != 0)
            {
                GameObject first = oldListName[0];
                newListName.Add(first);
                oldListName.Remove(first);
            }
        }
    }
    public void InsulinTransformPlace(string jsonData)  // Send To Web
    {
        SugarS.ChangeLocationData data = SugarS.ChangeLocationData.CreateFromJSON(jsonData);
        oldInsulinPlace = data.oldPlace;
        newInsulinPlace = data.newPlace;
        Debug.Log("----------InsulinTransformPlace----------");

        if (oldInsulinPlace == "Blood" && newInsulinPlace == "Muscle Cells ")
        {
            ToMus(bloodList);
        }
        if (oldInsulinPlace == "Liver Cells" && newInsulinPlace == "Muscle Cells ")
        {
            ToMus(liverleList);
        }
        if (oldInsulinPlace == "Pancreas Cells" && newInsulinPlace == "Muscle Cells ")
        {
            ToMus(pancreasList);
        }
        if (oldInsulinPlace == "Blood" && newInsulinPlace == "Liver Cells")
        {           
            ToLiver(bloodList);
        }
        if (oldInsulinPlace == "Muscle Cells " && newInsulinPlace == "Liver Cells")
        {
            ToLiver(muscleList);
        }
        if (oldInsulinPlace == "Pancreas Cells" && newInsulinPlace == "Liver Cells")
        {
            ToLiver(pancreasList);
        }
        if (oldInsulinPlace == "Liver Cells" && newInsulinPlace == "Blood")
        {
            ToBlood(liverleList);
        }
        if (oldInsulinPlace == "Muscle Cells " && newInsulinPlace == "Blood")
        {
            ToBlood(muscleList);
        }
        if (oldInsulinPlace == "Pancreas Cells" && newInsulinPlace == "Blood")
        {
            ToBlood(pancreasList);
        }
        if (oldInsulinPlace == "Blood" && newInsulinPlace == "Pancreas Cells")
        {
            ToPancreas(bloodList);
        }
        if (oldInsulinPlace == "Muscle Cells " && newInsulinPlace == "Pancreas Cells")
        {
            ToPancreas(muscleList);
        }
        if (oldInsulinPlace == "Liver Cells" && newInsulinPlace == "Pancreas Cells")
        {
            ToPancreas(liverleList);
        }
    }

    private void ToMus(List<GameObject> from)
    {
        if (from.Count != 0)
        {
            ChooseInsulinIndex(from, muscleList, 2);
            foreach (GameObject i in muscleList)
            {
                i.GetComponent<MoleculeMove>().StopCor();
                i.GetComponent<MoleculeMove>().MusculeCorutine();
            }
        }
    }

    private void ToBlood(List<GameObject> from)
    {
        if (from.Count != 0)
        {
            ChooseInsulinIndex(from, bloodList, 2);
            foreach (GameObject i in bloodList)
            {
                i.GetComponent<MoleculeMove>().StopCor();
                i.GetComponent<MoleculeMove>().BloodCorutine();
            }
        }
    }
    private void ToLiver(List<GameObject> from)
    {
        if (from.Count != 0)
        {
            ChooseInsulinIndex(from, liverleList, 2);
            foreach (GameObject i in liverleList)
            {
                i.GetComponent<MoleculeMove>().StopCor();
                i.GetComponent<MoleculeMove>().LiverCorutine();
            }
        }
    }
    private void ToPancreas(List<GameObject> from)
    {
        if (from.Count != 0)
        {
            ChooseInsulinIndex(from, pancreasList, 2);
            foreach (GameObject i in pancreasList)
            {
                i.GetComponent<MoleculeMove>().StopCor();
                i.GetComponent<MoleculeMove>().PancreasCorutine();
            }
        }
    }
}
