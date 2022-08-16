using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChannalS : MonoBehaviour
{
    int channalCount;
    [SerializeField] GameObject channelPrifab;

    public List<GameObject> channalsList = new List<GameObject>();

    [SerializeField] List<Transform> channelTransform = new List<Transform>();


    string newChannelPlace;
    string oldChannelPlace;

    GameObject pos;
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
        //AddChannalsChek(4);
        //AddChannalsChek(4);
        //AddChannalsChek(4);
        //AddChannalsChek(4);
        //AddChannalsChek(4);
    }
    void Update()
    {
        

    }
    public void ResetChannelSimulation()
    {
        foreach (GameObject i in channalsList)
        {
            if(i.GetComponent<ChanneLogic>().haveSugar == true)
            {
                Destroy(i.GetComponent<ChanneLogic>().sugarObj);
            }
            Destroy(i);
        }
        channalsList.Clear();
        channalCount = 0;

        var ChannelNewPlaceReset = FindObjectsOfType<ChannelNewPlace>();
        foreach (ChannelNewPlace i in ChannelNewPlaceReset)
        {
            i.isFree = true;
        }
    }

    private void AddChannalsChek(int id)
    {
        if (channalCount <= 9)
        {
            GameObject p = Instantiate(channelPrifab, channelTransform[channalCount].position, channelTransform[channalCount].rotation);
            p.GetComponent<DataScript>().id = id;
            p.AddComponent<ChanneLogic>();
            channalsList.Add(p);
            channalCount++;

        }
    }

    public void SugarGoThrough(int id)   // web  id = Channel id
    {
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
            if (i.isOldPlace == false && i.changePlase == false)
            {
                i.GetComponent<CapsuleCollider>().enabled = false;
                i.changePlase = true;              
            }
            //else
            //{
            //   // NewTransformToChannel();
            //    var Channals = FindObjectsOfType<ChanneLogic>();
            //    foreach (ChanneLogic j in Channals)
            //    {
            //        if (j.GetComponent<ChanneLogic>().newChannelTransform != null) { return; }
            //        else
            //        {
            //            j.GetComponent<ChanneLogic>().newChannelTransform = pos;
            //            j.GetComponent<ChanneLogic>().isOldPlace = false;
            //            j.changePlase = true;
            //            break;
            //        }
            //    }
            //}
        }
    }

    public void AddChannals(string dataJSON)
    {
        ChannalData data = ChannalData.CreateFromJSON(dataJSON);
        
        if (channalCount <= 9)
        {
            GameObject p = Instantiate(channelPrifab, channelTransform[channalCount].position, channelTransform[channalCount].rotation);
            p.GetComponent<DataScript>().id = data.channalID;
            p.AddComponent<ChanneLogic>();
            channalsList.Add(p);
            channalCount++;
        }         
    }
}
