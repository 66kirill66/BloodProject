using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusculeS : MonoBehaviour
{
    public GameObject musclesSprite;
    public GameObject musclesText;
    [SerializeField] GameObject runingChaild;
    int id;


    private void Awake()
    {
        runingChaild.SetActive(false);
        musclesSprite.SetActive(false);
        musclesText.SetActive(false);
    }
    void Start()
    {
       // musclesSprite.SetActive(true);
        //musclesText.SetActive(true);
        //runingChaild.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Addmuscles(int id)
    {
        this.id = id;
        musclesSprite.SetActive(true);
        musclesText.SetActive(true);
        runingChaild.SetActive(true);
    }
}
