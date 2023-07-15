using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class NodeUi : MonoBehaviour
{
    [SerializeField] private GameObject canvas;
    [SerializeField] private TMP_Text upgradeCosttext;
    [SerializeField] public Button upgradeButton;
    private Node target;


    public void SetTarget(Node _target)
    {
        target = _target;

        transform.position = target.transform.position;
        if (!target.isUpgraded)
        {
            upgradeCosttext.text = "R$ " + target.turretBlueprint.upgradeCost;
            upgradeButton.interactable = true;
        }
        else
        {
           upgradeButton.interactable = false;
            upgradeCosttext.text = "Done";
        }

        canvas.SetActive(true);
    }

    public void Hide()
    {
        canvas.SetActive(false);
    }

    public void Upgrade()
    {
        target.UpgradeTurret();
        BuildManager.instance.DeselectNode();
    }
}
