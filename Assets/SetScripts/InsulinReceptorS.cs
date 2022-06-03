using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsulinReceptorS : MonoBehaviour
{
    public GameObject receptorPrifab;
    public List<GameObject> receptorList = new List<GameObject>();
    [SerializeField] Transform creatPlace;

    float ofset;
    int id;

    void Start()
    {
        ofset = 0.3f;
        //AddInsulinReceptor(4);
        //AddInsulinReceptor(4);
        //AddInsulinReceptor(4);
        //AddInsulinReceptor(4);
        //AddInsulinReceptor(4);
        //AddInsulinReceptor(4);
        //AddInsulinReceptor(4);
        //AddInsulinReceptor(4);
        //AddInsulinReceptor(4);
        //AddInsulinReceptor(4);
        //AddInsulinReceptor(4);
        //AddInsulinReceptor(4);

    }

    void Update()
    {
        
    }
       
    public void AddInsulinReceptor(int id)
    {
        this.id = id;
        GameObject receptor = Instantiate(receptorPrifab, new Vector3(creatPlace.position.x - ofset, creatPlace.position.y,-0.5f),receptorPrifab.transform.rotation);
        receptor.gameObject.AddComponent<ReceptorFinder>();       
        receptorList.Add(receptor);
        ofset += 1.5f;
    }    
}
