using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public class ChannalS : MonoBehaviour
{
    [DllImport("__Internal")]
    public static extern void SetChannelLocation(string value, int channelId);

    
    int channalCountMus;
    int channalCountLiver;
    [SerializeField] GameObject channelPrifab;

    [SerializeField] List<Transform> channelTransformMus = new List<Transform>();
    [SerializeField] List<GameObject> channelNewTransformMus = new List<GameObject>();
    private List<GameObject> channalsListMus = new List<GameObject>();
    private List<GameObject> channalsListCellMembrane = new List<GameObject>();   
    
    [SerializeField] List<Transform> channelTransformLiver = new List<Transform>();
    [SerializeField] List<GameObject> channelNewTransformLiver = new List<GameObject>();
    private List<GameObject> channalsListLiver = new List<GameObject>();
    private List<GameObject> channalsListLiverCells = new List<GameObject>();
    string newChannelPlace;
    string oldChannelPlace;
    GameObject channelToMove;
    GameObject pos;

    RaycastHit hit;

    public class ChannalData
    {
        public int id;
        public string oldPlace;
        public string newPlace;
        public string property;
        public static ChannalData CreateFromJSON(string jsonString)
        {
            ChannalData dataChannel = JsonUtility.FromJson<ChannalData>(jsonString);
            return dataChannel;
        }
        public string ToJsonString()
        {
            return JsonUtility.ToJson(this);
        }
    }
    void Start()
    {
        //AddChannalsChekMus(1);
        //AddChannalsChekMus(2);
        //AddChannalsChekMus(3);
        //AddChannalsChekMus(4);
        //AddChannalsChekMus(4);
        //AddChannalsChekMus(4);
        //AddChannalsChekMus(4);
        //AddChannalsChekMus(4);
        //AddChannalsChekMus(4);
        //AddChannalsChekMus(4);
        //AddChannalsChekMus(4);
        //AddChannalsChekMus(4);
        //AddChannalsChekMus(4);
        //AddChannalsChekMus(4);
        //AddChannalsChekMus(4);


        //AddChannalsChekLiver(2);
        //AddChannalsChekLiver(2);
        //AddChannalsChekLiver(2);
        //AddChannalsChekLiver(2);
        //AddChannalsChekLiver(2);
        //AddChannalsChekLiver(2);
        //AddChannalsChekLiver(2);
        //AddChannalsChekLiver(2);
        //AddChannalsChekLiver(2);
        //AddChannalsChekLiver(2);
        //AddChannalsChekLiver(2);
        //AddChannalsChekLiver(2);

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
                if (hit.transform.gameObject.tag == "Channel")
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

        foreach (GameObject i in channalsListCellMembrane)
        {
            if(channalsListCellMembrane.Count != 0)
            {
                if (i.GetComponent<ChanneLogic>().haveSugar == true)
                {
                    Destroy(i.GetComponent<ChanneLogic>().sugarObj);
                }
                Destroy(i);
            }           
        }
        channalsListCellMembrane.Clear();

        foreach (GameObject i in channalsListLiver)
        {
            if (channalsListLiver.Count != 0)
            {              
                Destroy(i);
            }
        }
        channalsListLiver.Clear();

        foreach (GameObject i in channalsListLiverCells)
        {
            if (i.GetComponent<ChanneLogic>().haveSugar == true)
            {
                Destroy(i.GetComponent<ChanneLogic>().sugarObj);
            }
            Destroy(i);
        }
        channalsListLiverCells.Clear();

        channalCountMus = 0;
        channalCountLiver = 0;

        var ChannelNewPlaceReset = FindObjectsOfType<ChannelNewPlace>();
        foreach (ChannelNewPlace i in ChannelNewPlaceReset)
        {
            i.isFree = true;
        }
    }

    private void AddChannalsChekMus(int id)
    {
        if (channalCountMus <= 9)
        {
            GameObject p = Instantiate(channelPrifab, channelTransformMus[channalCountMus].position, channelTransformMus[channalCountMus].rotation);
            p.GetComponent<DataScript>().id = id;
            p.AddComponent<ChanneLogic>();
            channalsListMus.Add(p);
            channalCountMus++;
        }
    }
    private void AddChannalsChekLiver(int id)
    {
        if (channalCountLiver <= 9)
        {
            GameObject p = Instantiate(channelPrifab, channelTransformLiver[channalCountLiver].position, channelTransformLiver[channalCountLiver].rotation);
            p.GetComponent<DataScript>().id = id;
            p.AddComponent<ChanneLogic>();
            channalsListLiver.Add(p);
            channalCountLiver++;
        }
    }

    public void SugarGoThrough(int id)   // web  id = Channel id
    {
       if(channalsListCellMembrane.Count != 0)
        {
            foreach (GameObject i in channalsListCellMembrane)
            {
                int channalId = i.GetComponent<DataScript>().id;
                if (id == channalId)
                {
                    i.GetComponent<ChanneLogic>().SugarMoveDown();
                }
            }
        }   
       if(channalsListLiverCells.Count != 0)
        {
            foreach (GameObject i in channalsListLiverCells)
            {
                int channalId = i.GetComponent<DataScript>().id;
                if (id == channalId)
                {
                    i.GetComponent<ChanneLogic>().SugarMoveUp();
                }
            }
        }
    }
    public void SetChangeChannelLocation(string value,int chanelId) // send To web
    {
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
                ReturnChannalToNewPlace(id, channalsListMus);
                ToMembrane(channelToMove);
                SetChangeChannelLocation(newChannelPlace, id);
            }                  
        }
        if (oldChannelPlace == "Cell Membrane" && newChannelPlace == "Muscle Cells ")
        {
            if(channalsListCellMembrane.Count != 0)
            {
                ReturnChannalOldPlace(id, channalsListCellMembrane);
                ToMus(channelToMove);
                SetChangeChannelLocation(newChannelPlace, id);
            }           
        }
        if (oldChannelPlace == "Liver Cells" && newChannelPlace == "Cell")
        {
            if (channalsListLiver.Count != 0)
            {               
                ReturnChannalToNewPlace(id, channalsListLiver);
                ToCell(channelToMove);
                SetChangeChannelLocation(newChannelPlace, id);
            }
        }
        if (oldChannelPlace == "Cell" && newChannelPlace == "Liver Cells")
        {
            if(channalsListLiverCells.Count != 0)
            {
                ReturnChannalOldPlace(id, channalsListLiverCells);
                ToLiver(channelToMove);
                SetChangeChannelLocation(newChannelPlace, id);
            }
        }
    }
    private GameObject ReturnChannalToNewPlace(int channelId , List<GameObject> channelList)
    {
        if(channelList.Count != 0)
        {
            foreach (GameObject i in channelList)
            {
                if (i.GetComponent<DataScript>().id == channelId && i.GetComponent<ChanneLogic>().isOldPlace == true)
                {
                    //i.GetComponent<ChanneLogic>().isOldPlace = false;
                    channelToMove = i;
                    break;
                }             
            }
        }       
        return channelToMove;
    }
    private GameObject ReturnChannalOldPlace(int channelId, List<GameObject> channelList)
    {
        if (channelList.Count != 0)
        {
            foreach (GameObject i in channelList)
            {               
                if (i.GetComponent<DataScript>().id == channelId)
                {                  
                    channelToMove = i;
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
        channalsListCellMembrane.Remove(channel);
        channalsListMus.Add(channel);
    }
    private void ToLiver(GameObject channel)
    {
        channel.GetComponent<ChanneLogic>().isOldPlace = true;
        channel.GetComponent<ChanneLogic>().changePlace = false;
        channel.GetComponent<ChanneLogic>().newChannelTransform.GetComponent<ChannelNewPlace>().isFree = true; ;
        channalsListLiverCells.Remove(channel);
        channalsListLiver.Add(channel);
    }
    private void ToMembrane(GameObject channel)
    {
        if(channel.GetComponent<ChanneLogic>().isOldPlace == true)
        {
            NewTransformToChannel(channelNewTransformMus); // new
            channel.GetComponent<ChanneLogic>().newChannelTransform = pos;
            channel.GetComponent<ChanneLogic>().isOldPlace = false;
            channel.GetComponent<ChanneLogic>().changePlace = true;
            channalsListMus.Remove(channel);
            channalsListCellMembrane.Add(channel);
        }
        
    }

    private void ToCell(GameObject channel)
    {
        if (channel.GetComponent<ChanneLogic>().isOldPlace == true)
        {
            NewTransformToChannel(channelNewTransformLiver); // new
            channel.GetComponent<ChanneLogic>().newChannelTransform = pos;
            channel.GetComponent<ChanneLogic>().isOldPlace = false;
            channel.GetComponent<ChanneLogic>().changePlace = true;
            channalsListLiver.Remove(channel);
            channalsListLiverCells.Add(channel);
        }
    }
    public GameObject NewTransformToChannel(List<GameObject> transformList)
    {       
        foreach (GameObject i in transformList)
        {
            if (i.GetComponent<ChannelNewPlace>().isFree == true ) // new posValue == i.channelPlase
            {
                i.GetComponent<ChannelNewPlace>().isFree = false;
                pos = i;
                break;
            }
        }
        return pos;
    }

    public void AddChannals(string dataJSON)
    {
        ChannalData data = ChannalData.CreateFromJSON(dataJSON);

        if (channalCountMus <= 9 && FindObjectOfType<MusculeS>().IsActive == true && data.property == "Muscle Cells ") //
        {
           
            GameObject channel = Instantiate(channelPrifab, channelTransformMus[channalCountMus].position, channelTransformMus[channalCountMus].rotation);
            channel.GetComponent<DataScript>().id = data.id;
            channel.AddComponent<ChanneLogic>();
            channel.GetComponent<ChanneLogic>().chLocation = "Muscle";
            channalsListMus.Add(channel);
            Debug.Log("---------------" + data.property);
            channalCountMus++;
        }
        if (channalCountLiver <= 9 && FindObjectOfType<MusculeS>().IsActive == true && data.property == "Liver Cells") //
        {          
            GameObject channel = Instantiate(channelPrifab, channelTransformLiver[channalCountLiver].position, channelTransformLiver[channalCountLiver].rotation);
            channel.GetComponent<DataScript>().id = data.id;
            channel.AddComponent<ChanneLogic>();
            channel.GetComponent<ChanneLogic>().chLocation = "Liver";
            channalsListLiver.Add(channel);
            Debug.Log("---------------" + data.property) ;
            channalCountLiver++;
        }
    }
}
