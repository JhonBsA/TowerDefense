using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : MonoBehaviour
{
    public Color hoverColor; // The color to change to on hover

    private GameObject turret;

    public Vector3 hoverScale = new Vector3(1.1f, 1.1f, 1.1f);
    public float hoverOpacity = 0.5f; // Opacity on hover
    public float startOpacity = 1.0f; // Original opacity

    private Renderer rend;
    private Color startColor;
    private Vector3 startScale;

    void Start()
    {
        // Initialize Color and Scale
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        startScale = transform.localScale;
    }

    void OnMouseEnter()
    {
        // Change color and opacity on hover
        Color newColor = hoverColor;
        newColor.a = hoverOpacity; // Set the hover opacity
        rend.material.color = newColor;
        transform.localScale = hoverScale;


        // Notify the Castle to change 
        CastleHover castleHover = FindObjectOfType<CastleHover>();
        if (castleHover != null)
        {
            // On hover, set the transparent material
            castleHover.SetTransparentMaterial();
        }
    }

    #region Highlighting 
    void OnMouseDown()
    {
        if (turret != null)
        {
            Debug.Log("Can't build there! ToDo: Display this on screen");
            return;
        }

        GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();
        turret = (GameObject)Instantiate(turretToBuild, transform.position, transform.rotation);
    }

    void OnMouseExit() // Reset
    {
        // Reset to original color and opacity
        Color resetColor = startColor;
        resetColor.a = startOpacity; // Set the original opacity
        rend.material.color = resetColor; // Reset tile color
        transform.localScale = startScale;

        // Notify the Castle to reset opacity and color
        CastleHover castleHover = FindObjectOfType<CastleHover>();
        if (castleHover != null)
        {
            // When the hover ends, revert to the original material
            castleHover.SetOriginalMaterial();
        }
    }
    #endregion
}
