using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class FuelManager : MonoBehaviour
{
    public float fuel; // float fuel idi
    [SerializeField] Slider fuelAmountSlider;
    [SerializeField] MachineData machineData;
    //[SerializeField] TextMeshProUGUI fuelAmountText;//
    public GameObject outOfFuelScreen;
    public TextMeshProUGUI earnedMoneyText;
    public MoneyManager money;

    IEnumerator OutOfFuel()
    {
        outOfFuelScreen.SetActive(true);
        if (money.money >= 1000) earnedMoneyText.text = ((double)money.money / 1000).ToString("$0.##K");
        else earnedMoneyText.text = "$" + money.money;
        yield return new WaitForSeconds(4);
        outOfFuelScreen.SetActive(false);
        SetFuel();
    }

    public void UseFuel()
    {
        if (fuel > 0)
        {
            fuel -= Time.deltaTime * 12f;
            fuelAmountSlider.value = fuel;
        }
        else
        {
            StartCoroutine(OutOfFuel());
        }
    }

    public void SetFuel()
    {
        fuel = machineData.fuel;
        fuelAmountSlider.maxValue = machineData.fuel;
        fuelAmountSlider.value = fuel;
    }
}
