using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretOrientation : MonoBehaviour
{
    public GameObject turretPrefab;

    private static readonly Quaternion Up = Quaternion.Euler(0, 90, 0);        
    private static readonly Quaternion Down = Quaternion.Euler(0, -90, 0);     
    private static readonly Quaternion Left = Quaternion.Euler(0, 0, 0);       
    private static readonly Quaternion Right = Quaternion.Euler(0, 180, 0);    

    // This method will be called from BuildManager to place the turret
    public void PlaceTurret(Vector3 position)
    {
        // Get the turret prefab from BuildManager (use singleton)
        turretPrefab = BuildManager.instance.GetTurretToBuild();

        // Instantiate the turret at the specified position
        GameObject newTurret = Instantiate(turretPrefab, position, Quaternion.identity);

        // Set rotation based on coordinates (x and z values)
        newTurret.transform.rotation = DetermineRotation(position);
    }

    private Quaternion DetermineRotation(Vector3 position)
    {
        // Logic based on the z-position and x-position
        if (position.z > 1)
        {
            return Down; // Facing down
        }
        else if (position.z < -8)
        {
            return Up; // Facing up
        }
        else if (position.x > 5)
        {
            return Left; // Facing left
        }
        else if (position.z == -1)
        {
            return position.x > 0 ? Up : Down; // Up or Down based on x
        }
        else if (position.z == -2)
        {
            return position.x > 5 ? Left : Right; // Left or Right based on x
        }
        else if (position.z == -3)
        {
            if (position.x < -5)
            {
                return Up; // Facing up
            }
            else if (position.x > 5)
            {
                return Left; // Facing left
            }
            else
            {
                return Down; // Facing down
            }
        }
        else if (position.z == -4)
        {
            return position.x == -2 ? Left : Right; // Left or Right based on x
        }
        else if (position.z == -5)
        {
            if (position.x == -2)
            {
                return Left; // Facing left
            }
            else if (position.x == 2)
            {
                return Right; // Facing right
            }
            else
            {
                return Up; // Facing up
            }
        }
        else if (position.z == -6 || position.z == -7)
        {
            if (position.x == -4)
            {
                return Right; // Facing right
            }
            else if (position.x == 4)
            {
                return Left; // Facing left
            }
            else
            {
                return Down; // Facing down
            }
        }

        // Default rotation (you can change this as needed)
        return Up; // Default to facing up
    }
}
