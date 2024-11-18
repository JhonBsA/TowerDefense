using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BuildManager : MonoBehaviour
{
    #region Building
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
        instance = this; // this (BuildManager class)
    }

    //public GameObject standardTurretPrefab;  // Prefab of the turret BORRAR
    public GameObject arrowTurretPrefab;
    public GameObject cannonTurretPrefab;
    public GameObject crystalTurretPrefab;

    private GameObject turretToBuild;

    private TurretOrientation turretOrientation;


    public GameObject GetTurretToBuild()
    {
        return turretToBuild;
    }

    public void SetTurretToBuild (GameObject turret)
    {
        turretToBuild = turret;
    }
    #endregion

    #region Orientation
    // Turret Direction Variables
    private Quaternion Up = Quaternion.Euler(0, 90, 0);   
    private Quaternion Down = Quaternion.Euler(0, -90, 0); 
    private Quaternion Left = Quaternion.Euler(0, 0, 0);    
    private Quaternion Right = Quaternion.Euler(0, 180, 0); 

    

    public GameObject OrientTurret(Vector3 tilePosition)
    {
        // Determine the rotation based on the position
        Quaternion turretRotation = DetermineRotation(tilePosition);

        // Instantiate the turret at this position with the calculated rotation
        return Instantiate(turretToBuild, tilePosition, turretRotation);
    }
    // Method to calculate the turret's rotation based on the position
    public Quaternion DetermineRotation(Vector3 position)
    {
        float z = position.z;
        float x = position.x;

        // Grouped conditions based on x
        if (x == 7)
        {
            return Left;
        }
        else if (x == -5 && z <= -6)
        {
            return Right;
        }
        else if (x == 5 && z <= -6)
        {
            return Left;
        }
        // Grouped conditions based on z
        else if (z == 2 || (z == 0 && x <= -4))
        {
            return Down;
        }
        else if (z == -1)
        {
            return Left;
        }
        else if (z == -2)
        {
            if (x == -3 || x == -2)
                return Down;
            else if (x == 1 || x == 2)
                return Up;
            else if (x == 3)
                return Right;
        }
        else if (z == -3 || z == -4)
        {
            if (x == -8 || x == -7)
                return Up;
            else if (x == -1)
                return Left;
            else if (x == 1)
                return Right;
        }
        else if (z == -5)
        {
            if (x == -7)
                return Right;
            else if (x == -1 || x == 1)
                return Down;
        }
        else if (z == -6)
        {
            if (x == -6 || x == 6)
                return Up;
        }
        else if (z == -9)
        {
            return Up;
        }
        

        // Default rotation
        return Up;
    }
    #endregion
}
