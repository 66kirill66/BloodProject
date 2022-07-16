using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChannelOldPlace : MonoBehaviour
{
    public bool isOld = true;
    public bool changePlase = false;
    public GameObject newChannelTransform;
    void Start()
    {
        changePlase = true;
    }


    void Update()
    {
        if (isOld == false && changePlase == true && newChannelTransform != null)
        {
            Invoke("SetPositionRotation", 1);
        }
    }
    private void SetPositionRotation()
    {
        Transform pos = newChannelTransform.gameObject.transform;
        transform.position = Vector3.Lerp(transform.position, pos.gameObject.transform.position, 1 * Time.deltaTime);
        transform.rotation = Quaternion.Euler(pos.rotation.x, pos.rotation.y, 100 );
    }
}
