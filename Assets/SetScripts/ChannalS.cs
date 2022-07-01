using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChannalS : MonoBehaviour
{
    int channalCount;
    int activeCount;
    public GameObject channelTarget;
    public List<GameObject> channalsList = new List<GameObject>();

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
        channelTarget = null;
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

    // web
    public void ChannelTransformPlace(string json)
    {
        ChannalData data = ChannalData.CreateFromJSON(json);

        if(data.oldPlace == "Muscle Cells " && data.newPlace == "Cell Membrane")
        {
            StartCoroutine(LocationChange(channelTarget));
        }
    }

    private IEnumerator LocationChange(GameObject obj)
    {
        ChannelNewPlace[] newPos = FindObjectsOfType<ChannelNewPlace>();
        yield return new WaitForSeconds(2);
        foreach (ChannelNewPlace i in newPos)
        {
            if (i.isFree == true)
            {
                i.isFree = false;
                Debug.Log("Move");
                Transform pos = i.gameObject.transform;
                obj.transform.position = Vector3.Slerp(obj.transform.position, pos.transform.position, 3);
                obj.transform.rotation = Quaternion.Euler(pos.rotation.x, pos.rotation.y, 100);
                Destroy(gameObject);
                break;
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
