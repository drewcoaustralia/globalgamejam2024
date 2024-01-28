using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeightChanger : MonoBehaviour
{
    [SerializeField] private float waterHeight = 1f;

    private float originalHeight;

    private void Start()
    {
        originalHeight = transform.position.y;
    }

    public void EnterWater()
    {
        Vector3 newPosition = transform.position;
        newPosition.y = waterHeight;
        transform.position = newPosition;
    }

    public void ExitWater()
    {
        Vector3 newPosition = transform.position;
        newPosition.y = originalHeight;
        transform.position = newPosition;
    }
}
