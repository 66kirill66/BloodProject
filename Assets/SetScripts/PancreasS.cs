using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PancreasS : MonoBehaviour
{
    public GameObject pancreasSprite;
    int id;

    private void Awake()
    {
        pancreasSprite.SetActive(false);
        
    }
    void Start()
    {
       // pancreasSprite.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void AddPancreas(int id)
    {
        this.id = id;
        pancreasSprite.SetActive(true);
        
    }
}
