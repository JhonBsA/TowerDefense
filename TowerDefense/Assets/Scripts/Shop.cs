using UnityEngine;

public class Shop : MonoBehaviour
{

    BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void PurchaseArrowTurret ()
    {
        Debug.Log("Arrow Turret Selected");
        buildManager.SetTurretToBuild(buildManager.arrowTurretPrefab);
    }

    public void PurchaseCannonTurret()
    {
        Debug.Log("Cannon Turret Selected");
        buildManager.SetTurretToBuild(buildManager.cannonTurretPrefab);
    }

    public void PurchaseCrystalTurret()
    {
        Debug.Log("Crystal Turret Selected");
        buildManager.SetTurretToBuild(buildManager.crystalTurretPrefab);
    }

}
