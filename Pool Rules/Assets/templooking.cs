using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class templooking : MonoBehaviour
{
    //public float angleOffset = 0f;
    public bool freezeXZAxis = true;
    void Update()
    {
        if (freezeXZAxis)
        {
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, -Camera.main.transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
        }
        else
        {
            transform.rotation = Camera.main.transform.rotation;
        }
        //transform.localEulerAngles += new Vector3(0f, angleOffset, 0f);
    }
}
