using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlucagonReceptorS : MonoBehaviour
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
        //AddGlucagonReceptor(1);
        //AddGlucagonReceptor(2);
        //AddGlucagonReceptor(3);
        //AddGlucagonReceptor(4);
        //AddGlucagonReceptor(4);
        //AddGlucagonReceptor(4);
        //AddGlucagonReceptor(4);
        //AddGlucagonReceptor(4);
        //AddGlucagonReceptor(6);
        //AddGlucagonReceptor(6);
    }

    void Update()
    {

    }
    private void InstInsulinRec()
    {
        GameObject receptor = Instantiate(receptorPrifab, new Vector3(creatPlace.position.x + ofset, creatPlace.position.y, -0.5f), receptorPrifab.transform.rotation);
        receptor.gameObject.AddComponent<GlucagonReceptorLogic>();
        receptor.GetComponent<DataScript>().id = this.id;
        receptorList.Add(receptor);
        ofset += 2f;
    }

    public void OnReleasesSignalMoleculeToWeb(int id)   // web
    {
        foreach (GameObject i in receptorList)
        {
            receptorId = i.GetComponent<DataScript>().id;
            if (id == receptorId)
            {
                if (i.GetComponent<GlucagonReceptorLogic>().isFree == false && i.GetComponent<GlucagonReceptorLogic>().signalM == true)
                {
                    i.GetComponent<GlucagonReceptorLogic>().mol.AddComponent<SignalMolMove>().movingPlace ="Liver";
                    i.GetComponent<GlucagonReceptorLogic>().signalM = false;
                    i.GetComponent<GlucagonReceptorLogic>().reliseSignalM = true;
                    FindObjectOfType<SignalMoleculeToS>().SetSignalToAttached(false);
                }
                else return;
            }
        }
    }
    public void ResetGlucagonReceptorSimulation()
    {
        ofset = 0.3f;
        currentRecep = 0;
        foreach (GameObject i in receptorList)
        {
            Destroy(i);
        }
        receptorList.Clear();
    }
    public void AddGlucagonReceptor(int id) // web
    {
        if (currentRecep < 10)
        {
            this.id = id;
            InstInsulinRec();
            currentRecep++;
        }
    }
}
