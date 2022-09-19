using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public class EnzymeS : MonoBehaviour
{
    [DllImport("__Internal")]
    public static extern void EnzimeMeetStorage(int enzimeId,int storagelId);

    [DllImport("__Internal")]
    public static extern void EnzimeMeetSignalTo(int enzimeId, int signalToId);

    [DllImport("__Internal")]
    public static extern void SetEnzimeLevel(int enzimeId);

    [DllImport("__Internal")]
    public static extern void SetEnzimePropertyState(string value, int enzimeId);

    public List<GameObject> enzimeList = new List<GameObject>();
    [SerializeField] Transform createPlace;
    [SerializeField] GameObject enzimePrifab;

    RaycastHit hit;

    public class EnzimeData
    {
        public int id;
        public string newProperty;
        public string oldProperty;
        public static EnzimeData CreateFromJSON(string jsonString)
        {
            EnzimeData dataEnzimel = JsonUtility.FromJson<EnzimeData>(jsonString);
            return dataEnzimel;
        }
    }

    void Start()
    {
        //AddEnzime(1);
        //AddEnzime(1);
        //AddEnzime(1);
        //AddEnzime(1);
    }
    void Update()
    {
        ClickingOnEntity();
    }
    private void ClickingOnEntity()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.gameObject.tag == "Enzime")
                {
                    int id = hit.transform.GetComponent<DataScript>().id;
                    if (!Application.isEditor)
                    {
                        BloodS.ClickFunc(id);
                    }
                }
            }
        }
    }
    public void ResetEnzimeSimulation()
    {
        foreach (GameObject i in enzimeList)
        {
            Destroy(i);
        }
        enzimeList.Clear();
    }
    
    public void SetEnzimeLevelDelete(int enzimeId)   // Send To WEB 
    {
        if (!Application.isEditor)
        {
            SetEnzimeLevel(enzimeId);
        }
    }
    public void EnzimeMeetStorageSend(int enzimeId, int storagelId)  // web
    {
        if (!Application.isEditor)
        {
            EnzimeMeetStorage(enzimeId, storagelId);
        }
    }
    public void EnzimeMeetSignalToSend(int enzimeId, int signalToId)  // web
    {
        if (!Application.isEditor)
        {
            EnzimeMeetSignalTo(enzimeId, signalToId);
        }
    }
    public void AddEnzime(string dataJSON)
    {
        EnzimeData data = EnzimeData.CreateFromJSON(dataJSON);
        GameObject enzime = Instantiate(enzimePrifab, createPlace.transform.position, enzimePrifab.transform.rotation);
        enzimeList.Add(enzime);
        enzime.AddComponent<DataScript>().id = data.id;
        enzime.AddComponent<EnzimeLogic>().movingPlace = "Liver";
        enzime.GetComponent<EnzimeLogic>().enzimePropertyValue = data.newProperty;
    }
}
