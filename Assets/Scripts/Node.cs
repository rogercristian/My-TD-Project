using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    [SerializeField] Color hoverColor;
    [SerializeField] Color noCashColor;
    [SerializeField] Color initColor;
    private Renderer rend;

    BuildManager buildManager;

    [HideInInspector] public GameObject turret;
    [HideInInspector] public TurretBlueprint turretBlueprint;
    [HideInInspector] public bool isUpgraded = false;
    private void Start()
    {
        rend = GetComponent<Renderer>();
        buildManager = BuildManager.instance;
    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject()) return;

        
        if(turret != null)
        {
            buildManager.SelectNode(this);
            //msg nao pode contruir aqui
            return;
        }

        if (!buildManager.CanBuild)  return; 

        //build turret
       // buildManager.BuildTurretOn(this);
        BuildTurret(buildManager.GetTurretToBuild());
    }

    void BuildTurret(TurretBlueprint blueprint)
    {
        if (PlayerStats.Cash < blueprint.cost)
        {
            Debug.Log("Ta sem grana mano");
            return;
        }

        PlayerStats.Cash -= blueprint.cost;

        GameObject _turret = Instantiate(blueprint.prefab, transform.position, Quaternion.identity);
        turret = _turret;

        turretBlueprint = blueprint;

        GameObject _buildVfx = Instantiate(buildManager.buildEVfx, transform.position, Quaternion.identity);
        // Destroy(_buildVfx);
        Debug.Log("Torre feita, cash restante: " + PlayerStats.Cash);
    }

    public void UpgradeTurret()
    {
        if (PlayerStats.Cash < turretBlueprint.upgradeCost)
        {
            Debug.Log("Ta sem grana mano");
            return;
        }

        PlayerStats.Cash -= turretBlueprint.upgradeCost;

        // rip old turret
        Destroy(turret);

        // upgraded turret
        GameObject _turret = Instantiate(turretBlueprint.upgradePrefab, transform.position, Quaternion.identity);
        turret = _turret;

        GameObject _buildVfx = Instantiate(buildManager.buildEVfx, transform.position, Quaternion.identity);
        // Destroy(_buildVfx);

        isUpgraded = true;
        Debug.Log("Torre evoluida " + PlayerStats.Cash);
    }

    public void SellTurret()
    {
        PlayerStats.Cash += turretBlueprint.GetSellAmount();
        // vfx apos a venda
        Destroy(turret);
        turretBlueprint = null;
    }
    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject()) return;
        if (!buildManager.CanBuild) return;
      //  if (turret != null) return;
        if (buildManager.HasCash)
        {
        rend.material.color = hoverColor;

        }
        else
        {
            rend.material.color = noCashColor;
        }
    }

    private void OnMouseExit()
    {
        rend.material.color = initColor;
    }
}
