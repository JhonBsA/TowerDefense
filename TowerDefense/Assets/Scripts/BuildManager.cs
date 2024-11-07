using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    /* Singleton Pattern: 
     * -Only 1 BuildManager
     * -Global Access */
    public static BuildManager instance; 
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one BuildManager in scene!");
        }
        instance = this; //this (BuildManager class)
    }

    public GameObject standardTurretPrefab;

    private void Start()
    {
        turretToBuild = standardTurretPrefab;
    }

    private GameObject turretToBuild;

    public GameObject GetTurretToBuild()
    {
        return turretToBuild;
    }

    #region Orientation
    public void PlaceTurret(Vector3 position)
    {
        // Access TurretOrientation to place the turret at the position
        TurretOrientation turretOrientation = FindObjectOfType<TurretOrientation>();
        if (turretOrientation != null)
        {
            turretOrientation.PlaceTurret(position);
        }
        else
        {
            Debug.LogError("TurretOrientation not found!");
        }
    }
    #endregion
}
