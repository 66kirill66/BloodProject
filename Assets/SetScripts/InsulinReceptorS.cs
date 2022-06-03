using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsulinReceptorS : MonoBehaviour
{
    [SerializeField] GameObject receptorPrifab;
    [SerializeField] Transform creatPlace;
    public List<GameObject> receptorList = new List<GameObject>();


    int courentRecep;
    int reseptor = 0;
    float ofset;

    int id;

    void Start()
    {
        ofset = 0.3f;
    }

    void Update()
    {
        if (courentRecep <= 10 && courentRecep > reseptor)
        {            
            for (int i = 0; i < courentRecep; i++)
            {
                InstInsulinRec();
            }
        }
        else if(courentRecep > 10)
        {
            courentRecep = 10;
        }
    }
    private void InstInsulinRec()
    {
        GameObject receptor = Instantiate(receptorPrifab, new Vector3(creatPlace.position.x - ofset, creatPlace.position.y, -0.5f), receptorPrifab.transform.rotation);
        //receptor.gameObject.AddComponent<ReceptorFinder>();
        receptorList.Add(receptor);
        ofset += 1.5f;
        reseptor++;
    }

    public void AddInsulinReceptor(int id)
    {
        this.id = id;
        courentRecep++;
    }    
}
