using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonEatPizza : MonoBehaviour
{
    [SerializeField] Transform createPlase;
    public Transform instPos;
    public GameObject sugar;

    public void OnEatPizza()
    {
        int sug = 0;
        while (sug < 2)
        {
            GameObject sugarInst = Instantiate(sugar, instPos.position, transform.rotation);
            sugarInst.transform.parent = createPlase;
            FindObjectOfType<SugarS>().bloodList.Add(sugarInst);
            sugarInst.AddComponent<MoleculeMove>();
            FindObjectOfType<SugarS>().addSugarPerson++;
            sug++;
        }
    }
}
