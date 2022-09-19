using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsulinRecFinder : MonoBehaviour
{
    float speed;
    public bool free = true;
    Transform targetReceptor;
    float moveRange = 3f;
    float timer = 4;
    bool startFind = false;


    void Start()
    {       
        moveRange = 2f;
        speed = 1f;
    }

    void Update()
    {
        if(timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            startFind = true;
        }
        
    }
    private void FixedUpdate()
    {
        if(startFind == true)
        {
            FindReceptor();
            if (targetReceptor)
            {
                Invoke("GoToReceptor", 0.5f);
            }
            else { return; }
        }      
    }
    private void FindReceptor()   // Find Receptor
    {
        if (free == true)
        {
            var sceneReceptor = FindObjectsOfType<InsulinReceptorLogic>(); //  Find Receptor  script in scene
            if (sceneReceptor.Length == 0) { return; }   // if  Receptor count = 0 return.

            Transform closestReceptor = sceneReceptor[0].transform;   // Receptor [index 0] position            
            foreach (InsulinReceptorLogic other in sceneReceptor)
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
        Vector3 target = new Vector3(targetReceptor.transform.position.x + 0.1f, targetReceptor.transform.position.y + 1.2f, targetReceptor.transform.position.z);
        float distanceToRec = Vector3.Distance(targetReceptor.position, transform.position);
        if (distanceToRec <= moveRange && targetReceptor.GetComponent<InsulinReceptorLogic>().isFree == true)
        {
            free = false;
            MoleculeMove m = GetComponent<MoleculeMove>();
            Destroy(m);
            targetReceptor.GetComponent<InsulinReceptorLogic>().isFree = false;          
            StartCoroutine(CorutineReceptor(target));
            StartCoroutine(InsulAnimationOnMeet(gameObject));           
        }
        else
        {
            return;
        }
    }
    
    private IEnumerator CorutineReceptor(Vector3 end)
    {
        Vector3 startPos = transform.position;
        Vector3 endPos = end;
        float travel = 0;
        while (travel < 1f)
        {
            travel += Time.deltaTime * speed;
            transform.position = Vector3.Lerp(startPos, new Vector3(endPos.x - 0.1f, endPos.y , endPos.z), travel);
            yield return new WaitForEndOfFrame();
        }
    }
    private void OnDrawGizmos()  // DrawWireSphere Distance
    {        
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(transform.position, moveRange);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "InsulinReceptor") //Receptor
        {
            ParticleSystem ps = gameObject.GetComponentInChildren<ParticleSystem>();
            ps.Play();
            InsulinS ins = FindObjectOfType<InsulinS>();
            int insulP = ins.bloodList.IndexOf(gameObject);
            ins.bloodList.RemoveAt(insulP);
            Destroy(gameObject,2);
        }
    }
    IEnumerator InsulAnimationOnMeet(GameObject obj)
    {
        
        gameObject.transform.localScale = new Vector3(obj.transform.localScale.x + 7, obj.transform.localScale.y + 5, obj.transform.localScale.z + 5);
        yield return new WaitForSeconds(2);
        gameObject.transform.localScale = new Vector3(obj.transform.localScale.x - 7, obj.transform.localScale.y - 5, obj.transform.localScale.z - 5);
       
    }
}
