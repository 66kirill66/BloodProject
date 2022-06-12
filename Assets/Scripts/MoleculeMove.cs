using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoleculeMove : MonoBehaviour
{
    float speed;
    float PosX;
    float PosY;



    public bool blood = true;
    public bool toBoy = false;
    public bool toMus = false;
    public bool liver = false;
    public bool pancreas = false;

    void Start()
    {           
        speed = 0.2f;
        StartCoroutine(MoveInBloodRange());             
    }

    private void Update()
    {       
        if(toBoy == true)
        {
            StartCoroutine(MoveToBoy());
        }        
    }
    

    private IEnumerator MoveInBloodRange()
    {
        liver = false;
        toMus = false;
        toBoy = false;
        while (blood == true)
        {
            RundomPointBlood();
            Vector3 startPos = transform.position;
            Vector3 endPos = new Vector3(PosX, PosY, -0.5f);
            float travel = 0;
            while (travel < 1f)
            {
                travel += Time.deltaTime * speed;
                transform.position = Vector3.Lerp(startPos, endPos, travel);
                yield return new WaitForEndOfFrame();
            }
        }       
    }
    private IEnumerator CorutinerundoPointInMus()
    {
        liver = false;
        blood = false;
        toBoy = false;
        while (toMus == true)
        {
            RundomPointMus();
            Vector3 startPos = transform.position;
            Vector3 endPos = new Vector3(PosX, PosY, -0.5f);
            float travel = 0;
            while (travel < 1f)
            {
                travel += Time.deltaTime * 0.2f;
                transform.position = Vector3.Lerp(startPos, endPos, travel);
                yield return new WaitForEndOfFrame();
            }
        }
    }
    private IEnumerator CorutineToLiver()
    {
        toMus = false;
        blood = false;
        toBoy = false;
        while (liver == true)
        {
            RundomPointInLiver();
            Vector3 startPos = transform.position;
            Vector3 endPos = new Vector3(PosX, PosY, -0.5f);
            float travel = 0;
            while (travel < 1f)
            {
                travel += Time.deltaTime * 0.2f;
                transform.position = Vector3.Lerp(startPos, endPos, travel);
                yield return new WaitForEndOfFrame();
            }
        }        
    }  
    private IEnumerator MoveToBoy()
    {
        toMus = false;
        blood = false;
        liver = false;
        Vector3 startPos = transform.position;
        Vector3 endPos = new Vector3(20f, -5f, -0.5f);
        float travel = 0;
        while (travel < 1f)
        {
            travel += Time.deltaTime * speed;
            transform.position = Vector3.Lerp(startPos, endPos, travel);
            yield return new WaitForEndOfFrame();
        }
    }
    private IEnumerator CorutineToPancreas()
    {
        toMus = false;
        blood = false;
        toBoy = false;        
        while (pancreas == true)
        {
            RundomPointPancreas();
            Vector3 startPos = transform.position;
            Vector3 endPos = new Vector3(PosX, PosY, -0.5f);
            float travel = 0;
            while (travel < 1f)
            {
                travel += Time.deltaTime * 0.2f;
                transform.position = Vector3.Lerp(startPos, endPos, travel);
                yield return new WaitForEndOfFrame();
            }
        }
    }

    // Rundom Points
    private void RundomPointMus()
    {
        PosX = Random.Range(-7f, 17f);
        PosY = Random.Range(-1f, -7.5f);
    }  
    private void RundomPointBlood()
    {
        PosX = Random.Range(-23f, 23);
        PosY = Random.Range(-0.11f, 1.3f);
    }
    private void RundomPointInLiver()
    {
        PosX = Random.Range(-22f, -8.3f);
        PosY = Random.Range(-6.3f, -2f);
    }
    private void RundomPointPancreas()
    {
        PosX = Random.Range(-15.5f, -10f);
        PosY = Random.Range(2f, 6f);
    }
     // Start Corutine
    public void MoveToBoyStart()
    {
        toBoy = true;      
    }
    public void BloodCorutine()
    {
        blood = true;
        StartCoroutine(MoveInBloodRange());
    }
    public void MusculeCorutine()
    {       
        toMus = true;
        StartCoroutine(CorutinerundoPointInMus());
    }   
    public void LiverCorutine()
    {        
        liver = true;
        StartCoroutine(CorutineToLiver());
    }
    public void PancreasCorutine()
    {
        pancreas = true;
        StartCoroutine(CorutineToPancreas());
    }
    // Stop Corutine
    public void StopCor()
    {
        StopAllCoroutines();
    }
}
