using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsulinReceptorS : MonoBehaviour
{
    public GameObject receptorPrifab;
    public List<GameObject> receptorList = new List<GameObject>();
    [SerializeField] Transform creatPlace;

    int receptorCount;

    float ofset;
    int id;
    bool create;

    void Start()
    {
        ofset = 0.3f;
  

    }

    void Update()
    {
        if (receptorCount <= 10 && create == false)
        {            
            for (int i = 0; i < receptorCount; i++)
            {

                InstInsulinRec();
            }
            create = true;
        }
        else if(receptorCount > 10)
        {
            receptorCount = 10;
        }
    }
    private void InstInsulinRec()
    {
        GameObject receptor = Instantiate(receptorPrifab, new Vector3(creatPlace.position.x - ofset, creatPlace.position.y, -0.5f), receptorPrifab.transform.rotation);
        //receptor.gameObject.AddComponent<ReceptorFinder>();
        receptorList.Add(receptor);
        ofset += 1.5f;
    }

    public void AddInsulinReceptor(int id)
    {
        this.id = id;
        receptorCount++;
    }    
}
