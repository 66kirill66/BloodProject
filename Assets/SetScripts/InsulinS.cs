using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InsulinS : MonoBehaviour    
{
    [SerializeField] Transform createPlase;
    public GameObject insulinSyringe;
    public Transform instPos;    
    public Transform pancreasPos;    
    public GameObject insulin;
    public Text insulinText;
    public GameObject insulinViwText;
    public List<GameObject> insulinList = new List<GameObject>();

    float insulinPosX;
    float insulinPosY;

    RaycastHit hit;

    public int insulinAmount;
    public int oldInsulin;

    int id;  // Web ID

    bool sliderF;
    public Slider insulinFill;
    public GameObject insulinSlider;

    private void Awake()
    {
        sliderF = false;
        insulinSlider.SetActive(false);
        insulinViwText.SetActive(false);
        insulinSyringe.SetActive(false);
    }

    void Start()
    {
        
        InstantiateInsulin();
        //insulinViwText.SetActive(true);
        //insulinSyringe.SetActive(true);
        //insulinSlider.SetActive(true);

    }

    void Update()
    {
        insulinAmount = insulinList.Count;
        insulinText.text = (insulinAmount * 2).ToString();  //  Add Number to multiplication
        SliderAnim();       
        ClickingInsulinSyringe();      
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
                    insul.transform.parent = createPlase;
                    insulinList.Add(insul);
                    SetInsulinVal();
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
            insulinList.Add(insul);
            SetInsulinVal();
            insulinInst++;
        }
    } 

    private void RundomPoint()   
    {
        insulinPosX = Random.Range(-17f, 17);
        insulinPosY = Random.Range(0, 1.5f);
    }

    private void SetInsulinVal()   // Send To WEB
    {

        if (!Application.isEditor)
        {
            BloodS bl = GetComponent<BloodS>();
            bl.SetInsulinLevel(insulinAmount * 2);
        }
    }
    public void AddInsulin(int id)   // Init func
    {
        this.id = id;
        insulinSyringe.SetActive(true);
        insulinViwText.SetActive(true);
        insulinSlider.SetActive(true);
        InstantiateInsulin();
    }
}
