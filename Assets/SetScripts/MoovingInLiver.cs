using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoovingInLiver : MonoBehaviour
{
    bool liver = false;
    float PosXL;
    float PosYL;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CorutineToLiver());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private IEnumerator CorutineToLiver()
    {
        while (liver == true)
        {
            RundomPointInLiver();
            Vector3 startPos = transform.position;
            Vector3 endPos = new Vector3(PosXL, PosYL, -0.5f);
            float travel = 0;
            while (travel < 1f)
            {
                travel += Time.deltaTime * 0.2f;
                transform.position = Vector3.Lerp(startPos, endPos, travel);
                yield return new WaitForEndOfFrame();
            }
        }
    }
    private void RundomPointInLiver()
    {
        PosXL = Random.Range(-16f, -5f);
        PosYL = Random.Range(-1f, -4.5f);
    }
}
