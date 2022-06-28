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
    public List<GameObject> insulinList = new List<GameObject>();

    float insulinPosX;
    float insulinPosY;
    RaycastHit hit;
    public int insulinAmount;
    public int id;  // Web ID

    bool sliderF;
    public Slider insulinFill;
    public GameObject insulinSlider;



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
        InstantiateInsulin();

       // insulinViwText.SetActive(true);
        //insulinSyringe.SetActive(true);
        //insulinSlider.SetActive(true);
    }

    void Update()
    {
        if(insulinAmount != insulinList.Count)
        {
            insulinAmount = insulinList.Count;
            SetInsulinVal();
            insulinText.text = (insulinAmount * 2).ToString();
        }     
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
                    insul.AddComponent<InsulinRecFinder>();                    
                    insul.transform.parent = createPlase;
                    insulinList.Add(insul);
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
    public void InsulinMeetReseptor(int id)   // Send To WEB
    {
        if (!Application.isEditor)
        {
            ApplyMeetReceptor(this.id,id) ;
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
