using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChannalS : MonoBehaviour
{
    int id;
    int channalCount;
    int activeCount;
    public List<GameObject> channalsList = new List<GameObject>();


    private void Awake()
    {
        foreach (GameObject i in channalsList)
        {
            i.gameObject.SetActive(false);
        }

    }
    void Start()
    {
        
    }
    void Update()
    {
        if(channalCount <= 10)
        {
            activeCount = 0;
            for (int i = 0; i < channalCount; i++)
            {
                GameObject swichOn = channalsList[activeCount];
                swichOn.SetActive(true);
                activeCount++;
            }
        }
        else
        {
            channalCount = 10;
        }       
    }
    public void AddChannals(int id)
    {
        this.id = id;
        channalCount++;
    }
}
