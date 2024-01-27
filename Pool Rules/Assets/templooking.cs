using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class templooking : MonoBehaviour
{
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
    }
}
