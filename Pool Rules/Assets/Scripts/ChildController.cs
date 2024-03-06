using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildController : MonoBehaviour
{
    public Material MatDefault;
    public Material MatSelected;
    public Material MatNaughty;
    private MeshRenderer _rend;
    private Material MatCurrent;
    private bool isSelected = false;

    private void Awake()
    {
        _rend = GetComponent<MeshRenderer>();
        MatCurrent = MatDefault;
        _rend.material = MatCurrent;
    }

    void Update()
    {
        // if (Input.GetKeyDown(KeyCode.Z))
        // {
        //     MatCurrent = MatNaughty;
        //     _rend.material = MatCurrent;
        // }

        // if (isSelected)
        // {
        //     _rend.material = MatSelected;
        // }
        // else
        // {
        //     _rend.material = MatCurrent;
        // }
    }

    public void SetSelected(bool selected = true)
    {
        isSelected = selected;
    }
}
