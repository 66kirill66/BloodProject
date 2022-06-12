using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChannalS : MonoBehaviour
{
    public int id;
    int channalCount;
    int activeCount;
    public List<GameObject> channalsList = new List<GameObject>();

    public class ChannalData
    {
        public int channalID;
        public static ChannalData CreateFromJSON(string jsonString)
        {
            ChannalData chanID = JsonUtility.FromJson<ChannalData>(jsonString);
            return chanID;
        }
    }

    private void Awake()
    {        
        foreach (GameObject i in channalsList)
        {
            i.gameObject.SetActive(false);
        }
        activeCount = 0;

    }
    void Start()
    {
        
    }
    void Update()
    {
        
    }
    public void AddChannals(string dataJSON)
    {
        ChannalData data = ChannalData.CreateFromJSON(dataJSON);
        channalCount++;
        if (channalCount <= 10)
        {
            GameObject swichOn = channalsList[activeCount];
            swichOn.SetActive(true);
            swichOn.GetComponent<DataScript>().id = data.channalID;
            activeCount++;
        }
        else
        {
            channalCount = 10;
        }       
    }
}
