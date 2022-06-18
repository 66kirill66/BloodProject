using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GlucagonS : MonoBehaviour
{
    public List<GameObject> glucagonList = new List<GameObject>();
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
       // InstantiateGlucagon();
    }

    void Update()
    {
        if(glucagonAmount != glucagonList.Count)
        {
            glucagonAmount = glucagonList.Count;
            SetGlucagoVal();
            glucagonText.text = glucagonAmount.ToString();  
        }
        
        SliderAnim();
        
        ClickingGlucagonSyringe();
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
                    glucagonList.Add(gluc);
                    gluc.transform.parent = createPlase;
                    //SetGlucagoVal();
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
            glucagonList.Add(gluc);
            glucagonAmount++;
            //SetGlucagoVal();
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
        glucagoPosX = Random.Range(-17f, 17);
        glucagoPosy = Random.Range(0, 1.5f);
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
