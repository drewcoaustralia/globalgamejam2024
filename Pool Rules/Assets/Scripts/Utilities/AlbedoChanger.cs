using UnityEngine;

public class AlbedoChanger : MonoBehaviour
{
    private Material originalMaterial;
    private Material modifiedMaterial;

    private void Start()
    {
        Renderer renderer = GetComponent<Renderer>();
        if (renderer == null)
        {
            Debug.LogError("No Renderer component found on this GameObject.");
            enabled = false;
            return;
        }

        originalMaterial = renderer.material;
        modifiedMaterial = new Material(originalMaterial);
    }

    public void ChangeAlbedoColor(Color newColor)
    {
        if (modifiedMaterial != null)
        {
            modifiedMaterial.color = newColor;
            GetComponent<Renderer>().material = modifiedMaterial;
        }
        else
        {
            Debug.LogError("Material not properly initialized. Make sure there's a Renderer component with a material attached.");
        }
    }

    public void ChangeAlbedoColorToRed()
    {
        ChangeAlbedoColor(Color.red);
    }

    public void ResetAlbedoColor()
    {
        if (originalMaterial != null)
        {
            GetComponent<Renderer>().material = originalMaterial;
        }
        else
        {
            Debug.LogError("Original material not properly initialized. Make sure there's a Renderer component with a material attached.");
        }
    }
}
