using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsulinReceptorS : MonoBehaviour
{
    [SerializeField] GameObject receptorPrifab;
    [SerializeField] Transform creatPlace;
    public List<GameObject> receptorList = new List<GameObject>();

    public class InsulinData
    {
        public int insulinRecId;

        public static InsulinData CreateFromJSON(string jsonString)
        {
            InsulinData recID = JsonUtility.FromJson<InsulinData>(jsonString);
            return recID;
        }
    }
    int currentRecep;
    float ofset;

    public int id;

    void Start()
    {
        ofset = 0.3f;
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

    public void AddInsulinReceptor(int id)  // work
    {
        if (currentRecep < 10)
        {
            this.id = id;
            InstInsulinRec();
            currentRecep++;
        }
    }
    //public void AddInsulinReceptor(string dataJSON)
    //{
    //    if (currentRecep < 10)
    //    {
    //        InsulinData data = InsulinData.CreateFromJSON(dataJSON);
    //        this.id = data.insulinRecId;
    //        InstInsulinRec();
    //        currentRecep++;
    //    }
    //}

}
