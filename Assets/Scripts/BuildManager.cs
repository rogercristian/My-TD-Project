
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;
    public GameObject standardTurretPrefab;
    public GameObject misselTurretPrefab;
    public GameObject buildEVfx;

    private TurretBlueprint turretToBuild;


    private void Awake()
    {
        if(instance != null) {
            Debug.LogError("Mais de um build manager aqui");
            return;
        }
        instance = this;
    }

    //private void Start()
    //{
    //    turretToBuild = standardTurretPrefab;
    //}
    public bool CanBuild { get { return turretToBuild != null; } }
    public bool HasCash { get { return PlayerStats.Cash >= turretToBuild.cost; } }

    public void BuildTurretOn(Node node)
    {
        if(PlayerStats.Cash < turretToBuild.cost)
        {
            Debug.Log("Ta sem grana mano");
            return;
        }

        PlayerStats.Cash -= turretToBuild.cost;

        GameObject turret =  Instantiate(turretToBuild.prefab,node.transform.position, Quaternion.identity);
        node.turret = turret;

        GameObject _buildVfx = Instantiate(buildEVfx,node.transform.position, Quaternion.identity);
       // Destroy(_buildVfx);
        Debug.Log("Torre feita, cash restante: " + PlayerStats.Cash);
    }
   public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
    }
}
