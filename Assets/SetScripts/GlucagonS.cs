using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GlucagonS : MonoBehaviour
{
    public List<GameObject> bloodListG = new List<GameObject>();
    public List<GameObject> muscleList = new List<GameObject>();
    public List<GameObject> liverleList = new List<GameObject>();
    public List<GameObject> pancreasList = new List<GameObject>();

    [SerializeField] Transform createPlase;
    public GameObject GlucagonSyringe;
    public GameObject glucagon;
    public Transform instPos;

    bool sliderF = false;
    public GameObject glucagonSlider;
    public Slider glucagonFill;

    public Text glucagonText;
    public GameObject glucagonViwText;

    float glucagoPosX;
    float glucagoPosy;
   

    int id; // Web ID

    public int glucagonAmount;
    RaycastHit hit;

    public string newGlucagonPlace;
    public string oldGlucagonPlace;

    //public class ChangeGlucLocationData
    //{
    //    public string oldPlace;
    //    public string newPlace;
    //    public static ChangeGlucLocationData CreateFromJSON(string jsonString)
    //    {
    //        ChangeGlucLocationData locationData = JsonUtility.FromJson<ChangeGlucLocationData>(jsonString);
    //        return locationData;
    //    }
    //}
    private void Awake()
    {
        glucagonAmount = 0;
        glucagonSlider.SetActive(false);
        glucagonViwText.SetActive(false);
        GlucagonSyringe.SetActive(false);
    }

    void Start()
    {
        //glucagonSlider.SetActive(true);
       // glucagonViwText.SetActive(true);
        //GlucagonSyringe.SetActive(true);
        //InstantiateGlucagon();
        
    }

    void Update()
    {
        if(glucagonAmount != bloodListG.Count)
        {
            glucagonAmount = bloodListG.Count;
            SetGlucagoVal();
            glucagonText.text = glucagonAmount.ToString();  
        }
        
        SliderAnim();
        
        ClickingGlucagonSyringe();
    }

    private void ChooseGlucagonIndex(List<GameObject> oldListName, List<GameObject> newListName,int num)
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
    public void GlucagonTransformPlace(string jsonData)  // Send To Web
    {
        SugarS.ChangeLocationData data = SugarS.ChangeLocationData.CreateFromJSON(jsonData);
        oldGlucagonPlace = data.oldPlace;
        newGlucagonPlace = data.newPlace;

        Debug.Log("----------GlucagonTransformPlace----------");

        if (oldGlucagonPlace == "Blood" && newGlucagonPlace == "Muscle Cells ")
        {
            ToMus(bloodListG);
        }
        if (oldGlucagonPlace == "Liver Cells" && newGlucagonPlace == "Muscle Cells ")
        {
            ToMus(liverleList);
        }
        if (oldGlucagonPlace == "Pancreas Cells" && newGlucagonPlace == "Muscle Cells ")
        {
            ToMus(pancreasList);
        }
        if (oldGlucagonPlace == "Blood" && newGlucagonPlace == "Liver Cells")
        {
            ToLiver(bloodListG);
        }
        if (oldGlucagonPlace == "Muscle Cells " && newGlucagonPlace == "Liver Cells")
        {
            ToLiver(muscleList);
        }
        if (oldGlucagonPlace == "Pancreas Cells" && newGlucagonPlace == "Liver Cells")
        {
            ToLiver(pancreasList);
        }
        if (oldGlucagonPlace == "Liver Cells" && newGlucagonPlace == "Blood")
        {
            ToBlood(liverleList);
        }
        if (oldGlucagonPlace == "Muscle Cells " && newGlucagonPlace == "Blood")
        {
            ToBlood(muscleList);
        }
        if (oldGlucagonPlace == "Pancreas Cells" && newGlucagonPlace == "Blood")
        {
            ToBlood(pancreasList);
        }
        if (oldGlucagonPlace == "Blood" && newGlucagonPlace == "Pancreas Cells")
        {
            ToPancreas(bloodListG);
        }
        if (oldGlucagonPlace == "Muscle Cells " && newGlucagonPlace == "Pancreas Cells")
        {
            ToPancreas(muscleList);
        }
        if (oldGlucagonPlace == "Liver Cells" && newGlucagonPlace == "Pancreas Cells")
        {
            ToPancreas(liverleList);
        }
    }

    private void ToMus(List<GameObject> from)
    {
        if (from.Count != 0)
        {
            ChooseGlucagonIndex(from, muscleList,1);
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
            ChooseGlucagonIndex(from, bloodListG,1);
            foreach (GameObject i in bloodListG)
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
            ChooseGlucagonIndex(from, liverleList,1);
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
            ChooseGlucagonIndex(from, pancreasList,1);
            foreach (GameObject i in pancreasList)
            {
                i.GetComponent<MoleculeMove>().StopCor();
                i.GetComponent<MoleculeMove>().PancreasCorutine();
            }
        }
    }
    private void ClickingGlucagonSyringe()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.gameObject.tag == "GlucagonSyringe")
                {
                    sliderF = true;
                }
            }
        }
    }
    private void SliderAnim()
    {
        if (sliderF == true )
        {
            glucagonFill.value -= 1 * Time.deltaTime;
            if (glucagonFill.value == 0f)
            {
                int glucV = 0;
                while(glucV < 2)
                {
                    GameObject gluc = Instantiate(glucagon, instPos.position, transform.rotation);
                    gluc.AddComponent<MoleculeMove>();
                    bloodListG.Add(gluc);
                    gluc.transform.parent = createPlase;
                    glucV++;
                }                     
                sliderF = false;
            }
        }
        else if (sliderF == false)
        {
            glucagonFill.value += 1 * Time.deltaTime;
        }
    }

    public void InstantiateGlucagon()
    {
        int glucagonAmount = 0;

        while (glucagonAmount < 5)
        {
            RundomPoint();
            GameObject gluc = Instantiate(glucagon, new Vector3(glucagoPosX, glucagoPosy, -0.5f), glucagon.transform.rotation);
            gluc.transform.parent = createPlase;
            gluc.AddComponent<MoleculeMove>();
            bloodListG.Add(gluc);
            glucagonAmount++;
        }
    }

    private void SetGlucagoVal()  //Send To WEb
    {
        if (!Application.isEditor)
        {
            BloodS bl = GetComponent<BloodS>();
            bl.SetGlucagonLevel(glucagonAmount);  // Change multiplication
        }
    }
    private void RundomPoint()
    {
        glucagoPosX = Random.Range(-23f, 16.5f);
        glucagoPosy = Random.Range(0.6f, 2f);
    }

    public void ResetGlucagonSimulation()
    {
        glucagonAmount = 0;
        glucagonSlider.SetActive(false);
        glucagonViwText.SetActive(false);
        GlucagonSyringe.SetActive(false);
        foreach (GameObject i in bloodListG)
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
        bloodListG.Clear();
        muscleList.Clear();
        liverleList.Clear();
        pancreasList.Clear();
    }
    public void AddGlucagon(int id)
    {
        this.id = id;
        GlucagonSyringe.SetActive(true);
        glucagonViwText.SetActive(true);
        glucagonSlider.SetActive(true);
        InstantiateGlucagon();
    }
}
