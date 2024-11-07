using UnityEngine;

public class CastleHover : MonoBehaviour
{
    public Material castleMat; // The original opaque material
    public Material castleTransparent; // The transparent material

    private Renderer[] castleRenderers; // Array of renderers for all parts of the castle
    private Material[] originalMaterials; // Stores original materials to revert back

    void Start()
    {
        // Get all renderers within the castle object
        castleRenderers = GetComponentsInChildren<Renderer>();

        // Store the original materials so we can revert back after hover
        originalMaterials = new Material[castleRenderers.Length];
        for (int i = 0; i < castleRenderers.Length; i++)
        {
            originalMaterials[i] = castleRenderers[i].material;
        }
    }

    // Change castle to transparent material
    public void SetTransparentMaterial()
    {
        foreach (Renderer renderer in castleRenderers)
        {
            renderer.material = castleTransparent;
        }
    }

    // Change castle to the original material
    public void SetOriginalMaterial()
    {
        for (int i = 0; i < castleRenderers.Length; i++)
        {
            castleRenderers[i].material = originalMaterials[i];
        }
    }
}
