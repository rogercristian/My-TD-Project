using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBlueprint standardTurret;
    public TurretBlueprint misselTurret;
    public TurretBlueprint laserWeapon;

    BuildManager _buildManager;

    private void Start()
    {
        _buildManager = BuildManager.instance;
    }
    public void SelectStandardTurrent()
    {
        Debug.Log("Comprou turret");
        _buildManager.SelectTurretToBuild(standardTurret);
    }
    public void SelectMisselTurrent()
    {
        Debug.Log("Comprou missel");
        _buildManager.SelectTurretToBuild(misselTurret);
    }

    public void SelectLaserWeapon()
    {
        Debug.Log("Comprou missel");
        _buildManager.SelectTurretToBuild(laserWeapon);
    }
}
