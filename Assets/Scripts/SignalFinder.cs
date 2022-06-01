using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignalFinder : MonoBehaviour
{

    float speed;
    float PosX;
    float PosY;
    bool free = true;
    public bool mus = true;

    Transform targetMembrane;
    float moveRange = 5;

    void Start()
    {
        speed = 0.5f;
        StartCoroutine(CorutinerundoPointInMus());
    }

    void Update()
    {
        FindMembrane();
        if (targetMembrane)
        {
            GoToMembrane();
        }       
    }
    private IEnumerator CorutinerundoPointInMus()
    {       
        while (mus == true)
        {
            RundomPointMus();
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

    private IEnumerator CorutineMembrane( Vector3 end)
    {
        Vector3 startPos = transform.position;
        Vector3 endPos = end;
        float travel = 0;
        while (travel < 1f)
        {
            travel += Time.deltaTime * speed;
            transform.position = Vector3.Lerp(startPos, endPos, travel);
            yield return new WaitForEndOfFrame();
        }
    }


    private void FindMembrane()   // Find Membrane
    {
        if(free == true)
        {
            
            var sceneMembrane = FindObjectsOfType<MembraneFinder>(); //  Find Membrane Helth script in scene
            if (sceneMembrane.Length == 0) { return; }   // if  Membrane count = 0 return.

            Transform closestEnemy = sceneMembrane[0].transform;   // Membrane [index 0] position

            foreach (MembraneFinder other in sceneMembrane)
            {
                closestEnemy = GetClosest(closestEnemy, other.transform);   //  'GetClosest' update 
            }
            targetMembrane = closestEnemy;
        }       
    }
    private Transform GetClosest(Transform transformA, Transform transformB)
    {
        var distToA = Vector3.Distance(transform.position, transformA.position);   // closestMembrane
        var distToB = Vector3.Distance(transform.position, transformB.position);   //  other.transform
        if (distToA < distToB)
        {
            return transformA;
        }
        return transformB;
    }
    private void GoToMembrane()
    {
        Vector3 target = new Vector3(targetMembrane.transform.position.x, targetMembrane.transform.position.y - 0.5f, targetMembrane.transform.position.z);
        float distanceToMemb = Vector3.Distance(targetMembrane.transform.position, transform.position);
        if (distanceToMemb <= moveRange)
        {
            StartCoroutine(CorutineMembrane(target));
            free = false;
        }
        else
        {
            return;
        }
    }
    private void RundomPointMus()
    {
        PosX = Random.Range(-4f, 10f);
        PosY = Random.Range(-1f, -5.5f);
    }    
}
