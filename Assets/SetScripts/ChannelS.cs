using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChannelS : MonoBehaviour
{
    public GameObject channelPrifab;
    public List<GameObject> channelList = new List<GameObject>();
    [SerializeField] GameObject creatPlace;

  
    float ofset;
    int id;

    void Start()
    {
        ofset = 0.2f;
        AddChannel(4);
        AddChannel(4);
        AddChannel(4);


    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void CheckP()
    {
           
    }
    
    
    public void AddChannel(int id)
    {
        this.id = id;
        GameObject ch = Instantiate(channelPrifab, new Vector3(creatPlace.transform.position.x - ofset, creatPlace.transform.position.y, -0.5f),channelPrifab.transform.rotation);
        channelList.Add(ch);
        CheckP();
        ofset += 1;
    }    
}
