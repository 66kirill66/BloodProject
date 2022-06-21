using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsulinReceptorS : MonoBehaviour
{
    [SerializeField] GameObject receptorPrifab;
    [SerializeField] Transform creatPlace;
    public List<GameObject> receptorList = new List<GameObject>();    
    int currentRecep;
    float ofset;
    public int id; // Create Id
    int receptorId;


    void Start()
    {
        ofset = 0.3f;
        //AddInsulinReceptor(1);
        //AddInsulinReceptor(1);
        //AddInsulinReceptor(1);
        //AddInsulinReceptor(1);
    }

    void Update()
    {
        
    }
    private void InstInsulinRec()
    {
        GameObject receptor = Instantiate(receptorPrifab, new Vector3(creatPlace.position.x - ofset, creatPlace.position.y, -0.5f), receptorPrifab.transform.rotation);
        receptor.gameObject.AddComponent<ReceptorFinder>();       
        receptor.GetComponent<DataScript>().id = this.id;
        receptorList.Add(receptor);
        ofset += 1.5f;
    }

    public void OnReleasesSignalMoleculeWeb(int id)   // web
    {
        foreach(GameObject i in receptorList)
        {
            receptorId = i.GetComponent<DataScript>().id;
            if (id == receptorId)
            {
                if (i.GetComponent<ReceptorFinder>().isFree == false && i.GetComponent<ReceptorFinder>().signalM == true)
                {
                    i.GetComponent<ReceptorFinder>().mol.AddComponent<SignalMolMove>();
                    i.GetComponent<ReceptorFinder>().signalM = false;
                }
            }           
        }       
    }
    public void AddInsulinReceptor(int id) // web
    {
        if (currentRecep < 10)
        {
            this.id = id;
            InstInsulinRec();
            currentRecep++;
        }
    }   
}
