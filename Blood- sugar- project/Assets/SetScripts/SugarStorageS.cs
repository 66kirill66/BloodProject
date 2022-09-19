using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public class SugarStorageS : MonoBehaviour
{
    [DllImport("__Internal")]
    public static extern void SetStorageLevel(int storageId);
    [DllImport("__Internal")]
    public static extern void CreateRequestNewStorage(int storagePlace);

    [SerializeField] GameObject storagPrifab;
    [SerializeField] List<Transform> storageTransforms = new List<Transform>();
    public List<GameObject> storageList = new List<GameObject>();
    int transformNum = 0;

    public class StorageData
    {
        public int id;
        public int storagePlaceCount;
        public static StorageData CreateFromJSON(string json)
        {
            StorageData storageData = JsonUtility.FromJson<StorageData>(json);
            return storageData;
        }
    }
        // Start is called before the first frame update
        void Start()
    {
        //AddSugarStorage(1);
        //AddSugarStorage(2);
        //AddSugarStorage(3);
        //AddSugarStorage(4);
        //AddSugarStorage(5);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CreateNewStorage(int storagePlace)   // send receptor Id 
    {
        if (!Application.isEditor)
        {
            CreateRequestNewStorage(storagePlace);
        }
    }
    public void SetStorageLevelWeb(int storageId)   // Send To WEB 
    {
        if (!Application.isEditor)
        {
            SetStorageLevel(storageId);
        }
    }
    public void ResetSugarStorageSimulation()
    {
        foreach (GameObject i in storageList)
        {
            Destroy(i);
        }
        storageList.Clear();
        transformNum = 0;
    }

    public void StorageBroke(int storageId)
    {
        foreach(GameObject i in storageList)
        {
            if(i.GetComponent<DataScript>().id == storageId)
            {
                i.GetComponent<StorageLogic>().isBroke = true;
                i.GetComponent<StorageLogic>().SetStorageLevel();
            }
        }
    }

    public void AddSugarStorage(int id) // check
    {
        GameObject storage = Instantiate(storagPrifab, storageTransforms[transformNum].position, storagPrifab.transform.rotation);
        storage.AddComponent<DataScript>().id = id;
        storageList.Add(storage);
        transformNum++;
    }
    public void AddSugarStorage(string json)
    {
        StorageData data = StorageData.CreateFromJSON(json);
        if (data.storagePlaceCount != -1)
        {
            GameObject storage = Instantiate(storagPrifab, storageTransforms[data.storagePlaceCount].position, storagPrifab.transform.rotation);
            storage.AddComponent<DataScript>().id = data.id;
            storageList.Add(storage);
        }
        if (data.storagePlaceCount == -1 && storageList.Count <= 5) 
        {
            GameObject storage = Instantiate(storagPrifab, storageTransforms[transformNum].position, storagPrifab.transform.rotation);
            storage.AddComponent<DataScript>().id = data.id;
            storageList.Add(storage);
            transformNum++;
        }
    }
}
