
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;
    //public GameObject standardTurretPrefab;
    //public GameObject misselTurretPrefab;
    public GameObject buildEVfx;

    private TurretBlueprint turretToBuild;

    private Node selectedNode;

    public NodeUi nodeUi;
    private void Awake()
    {
        if(instance != null) {
            Debug.LogError("Mais de um build manager aqui");
            return;
        }
        instance = this;
    }

    //pr
    //ivate void Start()
    //{
    //    turretToBuild = standardTurretPrefab;
    //}
    public bool CanBuild { get { return turretToBuild != null; } }
    public bool HasCash { get { return PlayerStats.Cash >= turretToBuild.cost; } }

   

    public void SelectNode(Node node)
    {
        if(selectedNode == node)
        {
            DeselectNode();
            return;
        }
        selectedNode = node;
        turretToBuild = null;

        nodeUi.SetTarget(node);
    }

    public void DeselectNode()
    {
        selectedNode = null;
        nodeUi.Hide();
    }
   public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;

        DeselectNode();
    }

    public TurretBlueprint GetTurretToBuild() { return turretToBuild; }
}
