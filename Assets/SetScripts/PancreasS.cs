using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PancreasS : MonoBehaviour
{
    public GameObject pancreasSprite;
    public GameObject pancreasText;
    int id;
    public bool pancreasActive;

    private void Awake()
    {
        pancreasSprite.SetActive(false);
        pancreasText.SetActive(false);
    }
    void Start()
    {
      // pancreasSprite.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ResetPancreasSimulation()
    {
        pancreasSprite.SetActive(false);
        pancreasText.SetActive(false);
        pancreasActive = false;
    }
    public void AddPancreas(int id)
    {
        this.id = id;
        pancreasSprite.SetActive(true);       
        pancreasText.SetActive(true);
        pancreasActive = true;
    }
}
