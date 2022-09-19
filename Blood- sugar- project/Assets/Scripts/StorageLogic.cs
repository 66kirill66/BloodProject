using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorageLogic : MonoBehaviour
{
    public bool isBroke;
    int strorageId;
    public GameObject collisionEnzime;
    void Start()
    {
        strorageId = GetComponent<DataScript>().id;
    }

    void Update()
    {
        if (transform.childCount == 0)
        {
            FindObjectOfType<SugarStorageS>().storageList.Remove(gameObject);  
            Destroy(gameObject, 0.2f);
        }
        if(isBroke == true)
        {
            GetComponent<CapsuleCollider>().enabled = false; 
            if (transform.childCount != 0)
            {
                foreach (Transform i in transform)
                {                   
                    GameObject sugar = i.transform.gameObject;
                    FindObjectOfType<SugarS>().liverleList.Add(sugar);
                    if(i.GetComponent<MoleculeMove>() == null)
                    {
                        sugar.AddComponent<MoleculeMove>();
                    }
                    sugar.GetComponent<MoleculeMove>().StopCor();
                    sugar.GetComponent<MoleculeMove>().LiverCorutine();
                    i.transform.parent = null;
                }                
            }                       
        }
    }
    public void SetStorageLevel()
    {
        FindObjectOfType<SugarStorageS>().SetStorageLevelWeb(strorageId);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Sugar")
        {

            // add Sugar Meet storage func ??
        }
    }
}
