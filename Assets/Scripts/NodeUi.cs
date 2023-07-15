using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class NodeUi : MonoBehaviour
{
    [SerializeField] private GameObject canvas;
    [SerializeField] private TMP_Text upgradeCosttext;
    [SerializeField] public Button upgradeButton;
    [SerializeField] private TMP_Text sellAmountText;
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

        sellAmountText.text = "$" + target.turretBlueprint.GetSellAmount();
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

    public void Sell() {
        
        target.SellTurret();
        BuildManager.instance.DeselectNode();
    }
}
