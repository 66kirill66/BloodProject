using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChannalS : MonoBehaviour
{
    int channalCount;
    [SerializeField] GameObject channelPrifab;

    public List<GameObject> channalsListMus = new List<GameObject>();
    public List<GameObject> channalsListMusCells = new List<GameObject>();

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

        //if (Input.GetMouseButtonDown(0))
        //{
        //    ToMembrane();
        //}
        //if (Input.GetMouseButtonDown(1))
        //{
        //    ToMus();
        //}
    }
    public void ResetChannelSimulation()
    {
        foreach (GameObject i in channalsListMus)
        {
            if(channalsListMus.Count != 0)
            {
                Destroy(i);
            }           
        }
        channalsListMus.Clear();
        foreach (GameObject i in channalsListMusCells)
        {
            if(channalsListMusCells.Count != 0)
            {
                if (i.GetComponent<ChanneLogic>().haveSugar == true)
                {
                    Destroy(i.GetComponent<ChanneLogic>().sugarObj);
                }
                Destroy(i);
            }           
        }       
        channalsListMusCells.Clear();
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
            channalsListMus.Add(p);
            channalCount++;
        }
    }

    public void SugarGoThrough(int id)   // web  id = Channel id
    {
       // Debug.Log("--------SugarMove------------");
        foreach (GameObject i in channalsListMusCells)
        {
            int channalId = i.GetComponent<DataScript>().id;
            if (id == channalId)
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
        if (oldChannelPlace == "Cell Membrane" && newChannelPlace == "Muscle Cells ")
        {
            ToMus();
        }
    }

    private void ToMembrane()
    {
        if(channalsListMus.Count != 0)
        {
            NewTransformToChannel();
            GameObject first = channalsListMus[0];
            first.GetComponent<ChanneLogic>().isOldPlace = false;
            first.GetComponent<ChanneLogic>().changePlace = true;
            first.GetComponent<ChanneLogic>().newChannelTransform = pos;
            channalsListMus.Remove(first);
            channalsListMusCells.Add(first);
        }        
    }
    private void ToMus()
    {
        if (channalsListMusCells.Count != 0)
        {
            GameObject first = channalsListMusCells[0];
            first.GetComponent<ChanneLogic>().isOldPlace = true;
            first.GetComponent<ChanneLogic>().changePlace = false;
            first.GetComponent<ChanneLogic>().newChannelTransform.GetComponent<ChannelNewPlace>().isFree = true; ;
            channalsListMusCells.Remove(first);
            channalsListMus.Add(first);           
        }        
    }

    public GameObject NewTransformToChannel()
    {
        var newPos = FindObjectsOfType<ChannelNewPlace>();
        foreach (ChannelNewPlace i in newPos)
        {
            if (i.isFree == true)
            {
                i.isFree = false;
                pos = i.gameObject;
                break;
            }
        }        
        return pos;
    }
    public void AddChannals(string dataJSON)
    {
        ChannalData data = ChannalData.CreateFromJSON(dataJSON);
        
        if (channalCount <= 9)
        {
            GameObject channel = Instantiate(channelPrifab, channelTransform[channalCount].position, channelTransform[channalCount].rotation);
            channel.GetComponent<DataScript>().id = data.channalID;
            channel.AddComponent<ChanneLogic>();
            channalsListMus.Add(channel);
            channalCount++;
        }         
    }
}
