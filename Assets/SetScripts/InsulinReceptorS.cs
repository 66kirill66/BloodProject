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
        //AddInsulinReceptor(2);
        //AddInsulinReceptor(3);
        //AddInsulinReceptor(4);
        //AddInsulinReceptor(4);
        //AddInsulinReceptor(4);
        //AddInsulinReceptor(4);
        //AddInsulinReceptor(4);
        //AddInsulinReceptor(6);
        //AddInsulinReceptor(6);

    }

    void Update()
    {
        
    }
    private void InstInsulinRec()
    {
        GameObject receptor = Instantiate(receptorPrifab, new Vector3(creatPlace.position.x - ofset, creatPlace.position.y, -0.5f), receptorPrifab.transform.rotation);
        receptor.gameObject.AddComponent<InsulinReceptorLogic>();       
        receptor.GetComponent<DataScript>().id = this.id;
        receptorList.Add(receptor);
        ofset += 2f;
    }

    public void OnReleasesSignalMoleculeWeb(int id)   // web
    {
        foreach(GameObject i in receptorList)
        {
            receptorId = i.GetComponent<DataScript>().id;
            if (id == receptorId)
            {
                if (i.GetComponent<InsulinReceptorLogic>().isFree == false && i.GetComponent<InsulinReceptorLogic>().signalM == true)
                {
                    i.GetComponent<InsulinReceptorLogic>().mol.AddComponent<SignalMolMove>().movingPlace ="Mus";                  
                    i.GetComponent<InsulinReceptorLogic>().signalM = false;
                    i.GetComponent<InsulinReceptorLogic>().reliseSignalM = true;
                    FindObjectOfType<SignalMoleculeS>().SetSignalAttached(false); // , id send to web
                }
                else return;
            }           
        }       
    }
    public void ResetInsulinReceptorSimulation()
    {
        ofset = 0.3f;
        currentRecep = 0;
        foreach (GameObject i in receptorList)
        {
            Destroy(i);
        }
        receptorList.Clear();
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
