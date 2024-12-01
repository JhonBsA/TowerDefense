using System.Collections;
using UnityEngine;

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
            return;
        }
        instance = this; // this (BuildManager class)
    }

    public GameObject arrowTurretPrefab;
    public GameObject cannonTurretPrefab;
    public GameObject crystalTurretPrefab ;

    public GameObject buildEffect;

    private TurretBlueprint turretToBuild;

    public bool CanBuild {  get { return turretToBuild != null; } }
    public bool HasMoney { get { return PlayerStats.Money >= turretToBuild.cost; } }

    public void BuildTurretOn (Selector node)
    {
        if (turretToBuild == null) 
        {
            Debug.LogError("TurretBlueprint is not assigned! Use SelectTurretToBuild first.");
            return;
        }
        if (turretToBuild.prefab == null)
        {
            Debug.LogError("TurretBlueprint Prefab is not assigned! Use SelectTurretToBuild first.");
            return;
        }

        if (PlayerStats.Money < turretToBuild.cost)
        {
            Debug.Log("Not enough money to buil that!");
            return;
        }

        PlayerStats.Money -= turretToBuild.cost;

        GameObject turret = OrientTurret(node.transform.position);
            node.turret = turret;

        GameObject effect = (GameObject)Instantiate(buildEffect, OrientTurret(node.transform.position).transform.position, Quaternion.identity);
        Destroy(effect, 5f);

        Debug.Log("Turret build! Money left: " + PlayerStats.Money);

    }

    public void SelectTurretToBuild (TurretBlueprint turret)
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
        // Use the factory to get the correct rotation
        Quaternion turretRotation = OrientationFactory.GetRotation(tilePosition);

        // Instantiate the turret at this position with the calculated rotation
        return Instantiate(turretToBuild.prefab, tilePosition, turretRotation);
    }
    #endregion
}
