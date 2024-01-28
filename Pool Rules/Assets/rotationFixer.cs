using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotationFixer : MonoBehaviour
{
    private Vector3 cachedScale = Vector3.one;
    void Update()
    {
        cachedScale = transform.localScale;
        if (transform.rotation.y == 0) return;
        else if (transform.rotation.y > 0) cachedScale.x = 1f;
        else if (transform.rotation.y < 0) cachedScale.x = -1f;
        transform.localScale = cachedScale;
    }
}
