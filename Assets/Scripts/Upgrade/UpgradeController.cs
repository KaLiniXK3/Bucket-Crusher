using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Globalization;

public class UpgradeController : MonoBehaviour
{
    int[] lengthCosts = new int[] { 300, 4000, 10000 };

    int[] fuelCosts = new int[] { 5, 10, 15, 20, 30, 40, 50, 60, 70, 80, 90, 100, 120, 130, 140, 150, 160, 170, 180, 190, 200, 210, 220, 230, 240, 250, 270, 280, 290 };
    int[] powerCosts = new int[] { 5, 20, 100, 200, 300, 1000, 1200, 1300, 1400, 1500, 1600, 1700, 2000, 3000, 4000 };
    int[] sizeCosts = new int[] { 15, 90, 130, 250, 350, 500, 600, 780, 935, 1020 };



    [SerializeField] MachineData machineData;
    [SerializeField] MoneyManager moneyManager;

    //UI
    public TextMeshProUGUI lengthCostText;
    public TextMeshProUGUI fuelCostText;
    public TextMeshProUGUI powerCostText;
    public TextMeshProUGUI sizeCostText;

    //Buttons
    public Button lengthButton;
    public Button fuelButton;
    public Button powerButton;
    public Button sizeButton;

    //Costs
    int lengthCost = 300;
    int fuelCost = 5;
    int powerCost = 5;
    int sizeCost = 15;

    //UpdateCound
    int lengthUpdateCount = 0;
    int fuelUpdateCount = 0;
    int powerUpdateCount = 0;
    int sizeUpdateCount = 0;

    //Constants
    float sizeUpgradeAmount = 0.001f;
    float fuelUpgradeAmount = 10;

    private void Start()
    {
        lengthCost = lengthCosts[lengthUpdateCount];
        fuelCost = fuelCosts[fuelUpdateCount];
        powerCost = powerCosts[powerUpdateCount];
        sizeCost = sizeCosts[sizeUpdateCount];

        SetUpgradeCostText(lengthCostText, lengthCost);
        SetUpgradeCostText(fuelCostText, fuelCost);
        SetUpgradeCostText(powerCostText, powerCost);
        SetUpgradeCostText(sizeCostText, sizeCost);
    }

    public void Length()
    {
        if (moneyManager.money >= lengthCost)
        {
            if (lengthUpdateCount + 1 <= lengthCosts.Length)
            {
                lengthUpdateCount++;
                machineData.AddLength(lengthUpdateCount - 1, lengthUpdateCount);
                moneyManager.SetMoney(-lengthCost);
                moneyManager.SetMoneyText();
                if (lengthUpdateCount < lengthCosts.Length)
                {
                    lengthCost = lengthCosts[lengthUpdateCount];
                    SetUpgradeCostText(lengthCostText, lengthCost);
                }
                if (lengthUpdateCount == lengthCosts.Length - 1)
                {
                    SetUpgradeCostText(lengthCostText, 0);
                }
                CheckCanBuy();
            }
        }
    }

    public void Fuel()
    {
        if (moneyManager.money >= fuelCost)
        {
            if (fuelUpdateCount + 1 < fuelCosts.Length)
            {
                machineData.AddFuel(fuelUpgradeAmount);
                fuelUpdateCount++;
                moneyManager.SetMoney(-fuelCost);
                moneyManager.SetMoneyText();
                if (fuelUpdateCount < fuelCosts.Length)
                {
                    fuelCost = fuelCosts[fuelUpdateCount];
                    SetUpgradeCostText(fuelCostText, fuelCost);
                }
                if (fuelUpdateCount == fuelCosts.Length - 1)
                {
                    SetUpgradeCostText(fuelCostText, 0);
                }
                CheckCanBuy();
            }
        }
    }

    public void Power()
    {
        if (moneyManager.money >= powerCost)
        {
            if (powerUpdateCount + 1 < powerCosts.Length)
            {
                machineData.AddPower(50);
                powerUpdateCount++;
                moneyManager.SetMoney(-powerCost);
                moneyManager.SetMoneyText();
                if (powerUpdateCount < powerCosts.Length)
                {
                    powerCost = powerCosts[powerUpdateCount];
                    SetUpgradeCostText(powerCostText, powerCost);
                }
                if (powerUpdateCount == powerCosts.Length - 1)
                {
                    SetUpgradeCostText(powerCostText, 0);
                }
                CheckCanBuy();
            }
        }
    }

    public void Size()
    {
        if (moneyManager.money >= sizeCost)
        {
            if (sizeUpdateCount + 1 < sizeCosts.Length)
            {
                sizeUpdateCount++;
                machineData.AddSize(sizeUpgradeAmount);
                moneyManager.SetMoney(-sizeCost);
                moneyManager.SetMoneyText();
                CheckCanBuy();
                sizeCost = sizeCosts[sizeUpdateCount];
                SetUpgradeCostText(sizeCostText, sizeCost);
                if (sizeUpdateCount == sizeCosts.Length - 1)
                {
                    SetUpgradeCostText(sizeCostText, 0);
                }
                CheckCanBuy();
            }
        }
    }

    void SetUpgradeCostText(TextMeshProUGUI upgradeTypeText, int upgradeTypeCost)
    {
        // MAX 
        if (upgradeTypeCost == 0)
        {
            upgradeTypeText.text = "MAX";
        }
        else if (upgradeTypeCost >= 1000) upgradeTypeText.text = ((double)upgradeTypeCost / 1000).ToString("$0.##k");
        else upgradeTypeText.text = "$" + upgradeTypeCost;
    }

    public void CheckCanBuy()
    {
        if (moneyManager.money < lengthCost)
        {
            lengthButton.interactable = false;
        }
        else
            lengthButton.interactable = true;

        if (moneyManager.money < fuelCost)
        {
            fuelButton.interactable = false;
        }
        else
        {
            fuelButton.interactable = true;
        }
        if (moneyManager.money < powerCost)
        {
            powerButton.interactable = false;
        }
        else powerButton.interactable = true;
        if (moneyManager.money < sizeCost)
        {
            sizeButton.interactable = false;
        }
        else
            sizeButton.interactable = true;
    }
}
