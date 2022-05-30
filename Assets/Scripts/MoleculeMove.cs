using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoleculeMove : MonoBehaviour
{
    float speed;
    float PosX;
    float PosXM;
    float PosYM;
    float PosY;

    bool blood = true;
    bool toMus = false;  
    bool toBoy = false;
    bool corMus = false;

    void Start()
    {           
        speed = 0.2f;
        StartCoroutine(MoveInBloodRange());
       
    }

    private void Update()
    {
        RundomPointMus();
        if (toMus == true)
        {
            StartCoroutine(MoveToMus());
        }   
        
        if(toMus == false && toBoy == true)
        {
            StartCoroutine(MoveToBoy());
        }
        if (toMus == false && corMus == true)
        {
            StartCoroutine(CorutineEndPointInMus());
        }
    }
    

    private IEnumerator MoveInBloodRange()
    {
        while(blood == true)
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
    private IEnumerator MoveToMus()
    {
        toMus = false;
        Vector3 startPos = transform.position;
        Vector3 endPos = new Vector3(4f, -3f, -0.5f);
        float travel = 0;
        while (travel < 1f)
        {
            travel += Time.deltaTime * speed;
            transform.position = Vector3.Lerp(startPos, endPos, travel);
            yield return new WaitForEndOfFrame();
        }       
    }
    private IEnumerator MoveToBoy()
    {
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
    private IEnumerator CorutineEndPointInMus()
    {
        corMus = false;
        Vector3 startPos = transform.position;
        Vector3 endPos = new Vector3(PosXM, PosYM, -0.5f);
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
    public void StopLoopBlood()
    {
        blood = false;
        toMus = true;
    }   
    public void MoveToBoyStart()
    {
        toMus = false;
        toBoy = true;    
    }
    public void RandomEndPointInMus()
    {
        corMus = true;
    }
}
