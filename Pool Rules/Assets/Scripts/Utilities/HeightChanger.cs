using UnityEngine;

public class HeightChanger : MonoBehaviour
{
    [SerializeField] private float waterHeight = 1f;
    [SerializeField] private GameObject modelObject;

    private float originalHeight;

    private void Start()
    {
        originalHeight = modelObject.transform.position.y;
    }

    public void EnterWater()
    {
        Vector3 newPosition = modelObject.transform.position;
        newPosition.y = waterHeight;
        modelObject.transform.position = newPosition;
    }

    public void ExitWater()
    {
        Vector3 newPosition = modelObject.transform.position;
        newPosition.y = originalHeight;
        modelObject.transform.position = newPosition;
    }
}
