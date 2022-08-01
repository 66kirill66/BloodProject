using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiverS : MonoBehaviour
{
    public GameObject liverSprite;
    public GameObject liverText;

    int id;
    // Start is called before the first frame update
    private void Awake()
    {
        liverSprite.SetActive(false);
        liverText.SetActive(false);
    }
    void Start()
    {
        //liverSprite.SetActive(true);
        //liverText.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ResetLiverSimulation()
    {
        liverSprite.SetActive(false);
        liverText.SetActive(false);
    }
    public void Addliver(int id)
    {
        this.id = id;
        liverSprite.SetActive(true);
        liverText.SetActive(true);
    }
}
