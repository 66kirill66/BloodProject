using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MembraneS : MonoBehaviour
{
    public GameObject membranePrifab;
    public List<GameObject> membraneList = new List<GameObject>();
    [SerializeField] Transform creatPlace;

    float ofset;
    int id;

    void Start()
    {
        ofset = 0.2f;
        //AddMembrane(4);
        //AddMembrane(4);
        //AddMembrane(4);
        //AddMembrane(4);
        //AddMembrane(4);
        //AddMembrane(4);
        //AddMembrane(4);
        //AddMembrane(4);
        //AddMembrane(4);
        //AddMembrane(4);

    }

    void Update()
    {
        
    }
       
    public void AddMembrane(int id)
    {
        this.id = id;
        GameObject memb = Instantiate(membranePrifab, new Vector3(creatPlace.position.x - ofset, creatPlace.position.y,-0.5f),membranePrifab.transform.rotation);
        memb.gameObject.AddComponent<MembraneFinder>();       
        membraneList.Add(memb);
        ofset += 1.5f;
    }    
}
