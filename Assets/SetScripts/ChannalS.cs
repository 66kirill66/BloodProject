using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChannalS : MonoBehaviour
{
    int channalCount;
    int activeCount;

   // public GameObject channelP;

    public List<GameObject> channalsList = new List<GameObject>();

    string newChannelPlace;
    string oldChannelPlace;

    public class ChannalData
    {
        public int channalID;
        public string oldPlace;
        public string newPlace;
        public static ChannalData CreateFromJSON(string jsonString)
        {
            ChannalData dataChannel = JsonUtility.FromJson<ChannalData>(jsonString);
            return dataChannel;
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

        //AddChannalsChek(1);
        //AddChannalsChek(2);
        //AddChannalsChek(3);
        //AddChannalsChek(4);
        //AddChannalsChek(4);
        //AddChannalsChek(4);
        //AddChannalsChek(4);
        //AddChannalsChek(4);
        //AddChannalsChek(4);
        //AddChannalsChek(4);



    }
    void Update()
    {
        
    }

    private void AddChannalsChek(int id)
    {
        channalCount++;
        if (channalCount <= 10)
        {
            GameObject swichOn = channalsList[activeCount];
            swichOn.SetActive(true);
            swichOn.GetComponent<DataScript>().id = id;
            activeCount++;
        }
        else
        {
            channalCount = 10;
        }
    }

    public void SugarGoThrough(int id)   // web  id = Channel id
    {
        Debug.Log("-------SugarGoThrough-------");
        foreach (GameObject i in channalsList)
        {
            int channelId = i.GetComponent<DataScript>().id;
            if (id == channelId)
            {
                i.GetComponent<ChanneLogic>().SugarMove();
            }
        }
    }

    // web
    public void ChannelTransformPlace(string json)
    {
        ChannalData data = ChannalData.CreateFromJSON(json);
        newChannelPlace = data.newPlace;
        oldChannelPlace = data.oldPlace;


        if (oldChannelPlace == "Muscle Cells " && newChannelPlace == "Cell Membrane")
        {          
            ToMembrane();
        }
    }
   
    private void ToMembrane()
    {
        var oldPos = FindObjectsOfType<ChanneLogic>();
        foreach (ChanneLogic i in oldPos)
        {
            if (i.isOldPlace == false)
            {
                i.changePlase = true;
            }
        }
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
