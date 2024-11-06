using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastleHover : MonoBehaviour
{
    private Renderer[] castleRenderers; // Array of castle child renderers
    public Color hoverColor = Color.red; // Color to apply when hovering over tiles
    public Color[] originalColors; // Store original colors

    void Start()
    {
        // Get all child renderers of the castle
        castleRenderers = GetComponentsInChildren<Renderer>();
        originalColors = new Color[castleRenderers.Length];

        // Store the original colors of the castle pieces
        for (int i = 0; i < castleRenderers.Length; i++)
        {
            originalColors[i] = castleRenderers[i].material.color;
        }
    }

    // Method to set the opacity of the castle
    public void SetCastleOpacity(float opacity)
    {
        for (int i = 0; i < castleRenderers.Length; i++)
        {
            Color castleColor = originalColors[i]; // Use the original color
            castleColor.a = opacity; // Set the desired opacity
            castleRenderers[i].material.color = castleColor; // Update the renderer's color
        }
    }

    // Method to change the castle color
    public void ChangeCastleColor(Color color)
    {
        foreach (Renderer castleRenderer in castleRenderers)
        {
            Color castleColor = castleRenderer.material.color;
            castleColor = color; // Change the color to the new color
            castleRenderer.material.color = castleColor;
        }
    }
}
