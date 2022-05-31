using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChannelS : MonoBehaviour
{
    public GameObject channelPrifab;
    public List<GameObject> channelList = new List<GameObject>();
    [SerializeField] Transform creatPlace;

    float ofset;
    int id;

    

    void Start()
    {
        ofset = 0.2f;
        //AddChannel(4);
        //AddChannel(4);
        //AddChannel(4);
        //AddChannel(4);
        //AddChannel(4);
        //AddChannel(4);
        //AddChannel(4);
        //AddChannel(4);
        //AddChannel(4);
        //AddChannel(4);

    }

    void Update()
    {
        
    }
       
    public void AddChannel(int id)
    {
        this.id = id;
        GameObject chan = Instantiate(channelPrifab, new Vector3(creatPlace.transform.position.x - ofset, creatPlace.transform.position.y,-0.5f),channelPrifab.transform.rotation);
        chan.gameObject.AddComponent<ChannelFinder>();
        channelList.Add(chan);
        ofset += 1.5f;
    }    
}
