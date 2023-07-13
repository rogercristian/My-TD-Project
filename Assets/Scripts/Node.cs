using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    [SerializeField] Color hoverColor;
    [SerializeField] Color noCashColor;
    [SerializeField] Color initColor;
    [HideInInspector] public GameObject turret;
    private Renderer rend;

    BuildManager buildManager;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        buildManager = BuildManager.instance;
    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject()) return;

        if (!buildManager.CanBuild)  return; 
        
        if(turret != null)
        {
            //msg nao pode contruir aqui
            return;
        }

        //build turret
        buildManager.BuildTurretOn(this);

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
