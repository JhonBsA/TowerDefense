using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBlueprint arrowTurret;
    public TurretBlueprint cannonTurret;
    public TurretBlueprint crystalurret;

    BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void SelectArrowTurret ()
    {
        Debug.Log("Arrow Turret Selected");
        buildManager.SelectTurretToBuild(arrowTurret);
    }

    public void SelectCannonTurret()
    {
        Debug.Log("Cannon Turret Selected");
        buildManager.SelectTurretToBuild(cannonTurret);
    }

    public void SelectCrystalTurret()
    {
        Debug.Log("Crystal Turret Selected");
        buildManager.SelectTurretToBuild(crystalurret);
    }

}
