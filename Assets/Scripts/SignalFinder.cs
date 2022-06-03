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

    Transform targetReceptor;
    float moveRange = 2.5f;

    void Start()
    {
        speed = 0.4f;
        StartCoroutine(CorutinerundoPointInMus());
    }

    void Update()
    {
        //FindReceptor();
        //if (targetReceptor)
        //{
        //    GoToReceptor();
        //}
        //else { return; }
    }
    private void FixedUpdate()
    {
        FindReceptor();
        if (targetReceptor)
        {
            GoToReceptor();
        }
        else { return; }
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

    private IEnumerator CorutineReceptor( Vector3 end)
    {
        Vector3 startPos = transform.position;
        Vector3 endPos = end;
        float travel = 0;
        while (travel < 1f)
        {
            travel += Time.deltaTime * speed;
            transform.position = Vector3.Lerp(startPos,new Vector3( endPos.x-0.1f, endPos.y, endPos.z), travel);
            yield return new WaitForEndOfFrame();
        }
    }


    private void FindReceptor()   // Find Receptor
    {
        if(free == true)
        {           
            var sceneReceptor = FindObjectsOfType<ReceptorFinder>(); //  Find Receptor Helth script in scene
            if (sceneReceptor.Length == 0) { return; }   // if  Receptor count = 0 return.

            Transform closestReceptor = sceneReceptor[0].transform;   // Receptor [index 0] position            
            foreach (ReceptorFinder other in sceneReceptor)
            {             
                closestReceptor = GetClosest(closestReceptor, other.transform);   //  'GetClosest' update                 
            }          
            targetReceptor = closestReceptor;
        }       
    }
    private Transform GetClosest(Transform transformA, Transform transformB)
    {
        var distToA = Vector3.Distance(transform.position, transformA.position);   // closestReceptor
        var distToB = Vector3.Distance(transform.position, transformB.position);   //  other.transform
        if (distToA < distToB)
        {
            return transformA;
        }
        return transformB;
    }
    private void GoToReceptor()
    {
        Vector3 target = new Vector3(targetReceptor.transform.position.x, targetReceptor.transform.position.y - 0.5f, targetReceptor.transform.position.z);
        float distanceToRec = Vector3.Distance(targetReceptor.position, transform.position);
        if (distanceToRec <= moveRange)
        {
            free = false;
            mus = false;
           // StopCoroutine(CorutinerundoPointInMus());
            StartCoroutine(CorutineReceptor(target));           
        }
        else
        {
            return;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(transform.position, moveRange);
    }
    private void RundomPointMus()
    {
        PosX = Random.Range(-7f, 17f);
        PosY = Random.Range(-1f, -7.5f);
    }    
}
