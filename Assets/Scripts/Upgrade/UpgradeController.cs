using UnityEngine;
using TMPro;
using System.Globalization;

public class UpgradeController : MonoBehaviour
{
    int[] lengthCosts = new int[] { 10, 300, 4000, 10000 };

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

    //Costs
    int lengthCost = 10;
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
                Debug.Log(lengthUpdateCount);
                machineData.AddLength(lengthUpdateCount - 1, lengthUpdateCount);
                if (lengthUpdateCount < lengthCosts.Length)
                {
                    lengthCost = lengthCosts[lengthUpdateCount];
                    SetUpgradeCostText(lengthCostText, lengthCost);
                }
                if (lengthUpdateCount == lengthCosts.Length - 1)
                {
                    Debug.Log("Max Length");
                }
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
                    Debug.Log("Max Fuel");
                }
            }
        }
    }

    public void Power()
    {
        if (moneyManager.money >= powerCost)
        {
            if (powerUpdateCount + 1 < powerCosts.Length)
            {
                machineData.AddPower(100);
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
                    Debug.Log("Max Power");
                }
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
                sizeCost = sizeCosts[sizeUpdateCount];
                SetUpgradeCostText(sizeCostText, sizeCost);
                Debug.Log("sizeUpdate" + sizeUpdateCount);
                if (sizeUpdateCount == sizeCosts.Length - 1)
                {
                    Debug.Log("Max Size");
                }
            }
        }
    }

    void SetUpgradeCostText(TextMeshProUGUI upgradeTypeText, int upgradeTypeCost)
    {
        if (upgradeTypeCost >= 1000) upgradeTypeText.text = ((double)upgradeTypeCost / 1000).ToString("$0.##k");
        else upgradeTypeText.text = "$" + upgradeTypeCost;
    }
}
