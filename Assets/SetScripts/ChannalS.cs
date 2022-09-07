using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public class ChannalS : MonoBehaviour
{
    [DllImport("__Internal")]
    public static extern void SetChannelLocation(string value, int channelId);

    
    int channalCount;
    [SerializeField] GameObject channelPrifab;
    public List<GameObject> channalsListMus = new List<GameObject>();
    public List<GameObject> channalsListMusCells = new List<GameObject>();
    [SerializeField] List<Transform> channelTransform = new List<Transform>();
    string newChannelPlace;
    string oldChannelPlace;
    GameObject channelToMove;
    GameObject pos;
    public class ChannalData
    {
        public int id;
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
       if(channalsListMusCells.Count != 0)
        {
            foreach (GameObject i in channalsListMusCells)
            {
                int channalId = i.GetComponent<DataScript>().id;
                if (id == channalId)
                {
                    i.GetComponent<ChanneLogic>().SugarMove();
                }
            }
        }      
    }
    public void SetChangeChannelLocation(string value,int chanelId)
    {
        Debug.Log("---------------" + value + "---------------");
        if (!Application.isEditor)
        {
            SetChannelLocation(value, chanelId);
        }
        
    }


    // web
    public void ChannelTransformPlace(string json)
    {
        ChannalData data = ChannalData.CreateFromJSON(json);
        newChannelPlace = data.newPlace;
        oldChannelPlace = data.oldPlace;
        int id = data.id;
        if (oldChannelPlace == "Muscle Cells " && newChannelPlace == "Cell Membrane")
        {
            if (channalsListMus.Count != 0)
            {
                SetChangeChannelLocation(newChannelPlace, id);
                ReturnChannal(id, channalsListMus);
                ToMembrane(channelToMove);
            }           
        }
        if (oldChannelPlace == "Cell Membrane" && newChannelPlace == "Muscle Cells ")
        {
            if(channalsListMusCells.Count != 0)
            {
                SetChangeChannelLocation(newChannelPlace, id);
                ReturnChannal(id, channalsListMusCells);
                ToMus(channelToMove);
            }           
        }
    }
    private GameObject ReturnChannal(int channelId , List<GameObject> channelList)
    {
        if(channelList.Count != 0)
        {
            foreach (GameObject i in channelList)
            {
                if (i.GetComponent<DataScript>().id == channelId)
                {
                    channelToMove = i.gameObject;
                    break;
                }              
            }
        }       
        return channelToMove;
    }
    private void ToMus(GameObject channel)
    {
        channel.GetComponent<ChanneLogic>().isOldPlace = true;
        channel.GetComponent<ChanneLogic>().changePlace = false;
        channel.GetComponent<ChanneLogic>().newChannelTransform.GetComponent<ChannelNewPlace>().isFree = true; ;
        channalsListMusCells.Remove(channel);
        channalsListMus.Add(channel);
    }
    private void ToMembrane(GameObject channel)
    {
        NewTransformToChannel();
        channel.GetComponent<ChanneLogic>().isOldPlace = false;
        channel.GetComponent<ChanneLogic>().changePlace = true;
        channel.GetComponent<ChanneLogic>().newChannelTransform = pos;
        channalsListMus.Remove(channel);
        channalsListMusCells.Add(channel);
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
        
        if (channalCount <= 9 && FindObjectOfType<MusculeS>().IsActive == true) // new FindObjectOfType<MusculeS>().IsActive == true
        {
            GameObject channel = Instantiate(channelPrifab, channelTransform[channalCount].position, channelTransform[channalCount].rotation);
            channel.GetComponent<DataScript>().id = data.id;
            channel.AddComponent<ChanneLogic>();
            channalsListMus.Add(channel);
            channalCount++;
        }         
    }
}
