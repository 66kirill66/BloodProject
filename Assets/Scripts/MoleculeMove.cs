using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoleculeMove : MonoBehaviour
{
    float speed;
    float PosX;
    float PosY;

    float PosXM;
    float PosYM;

    float PosXL;
    float PosYL;


    public bool blood = true;
    public bool toBoy = false;
    public bool toMus = false;
    public bool liver = false;

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
            RundomPoint();
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
            Vector3 endPos = new Vector3(PosXM, PosYM, -0.5f);
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
            Vector3 endPos = new Vector3(PosXL, PosYL, -0.5f);
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
        Vector3 endPos = new Vector3(13f, -3f, -0.5f);
        float travel = 0;
        while (travel < 1f)
        {
            travel += Time.deltaTime * speed;
            transform.position = Vector3.Lerp(startPos, endPos, travel);
            yield return new WaitForEndOfFrame();
        }
    }
    
    


    private void RundomPointMus()
    {
        PosXM = Random.Range(-4f, 10f);
        PosYM = Random.Range(-1f, -5.5f);
    }
    
    private void RundomPoint()
    {
        PosX = Random.Range(-17f, 17);
        PosY = Random.Range(0, 1.2f);
    }
    private void RundomPointInLiver()
    {
        PosXL = Random.Range(-16f, -5f);
        PosYL = Random.Range(-4.5f, -1f);
    }
    public void BloodCorutine()
    {
        blood = true;
        StartCoroutine(MoveInBloodRange());
    }
    
    public void MoveToBoyStart()
    {
        toBoy = true;      
    }
    public void MusculeCorutine()
    {
        StartCoroutine(CorutinerundoPointInMus());
        toMus = true;
    }
    
    public void LiverCorutine()
    {        
        liver = true;
        StartCoroutine(CorutineToLiver());
    }
    public void StopCor()
    {
        StopAllCoroutines();
    }
}
