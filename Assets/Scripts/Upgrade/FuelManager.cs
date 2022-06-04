using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class FuelManager : MonoBehaviour
{
    public static float fuel; // float fuel idi
    [SerializeField] Slider fuelAmountSlider;
    [SerializeField] MachineData machineData;
    //[SerializeField] TextMeshProUGUI fuelAmountText;//
    public GameObject outOfFuelGameobject;
    public TextMeshProUGUI earnedMoneyText;
    public MoneyManager earnedMoney;


    private void Start()
    {
        SetFuel();
    }

    private void Update()
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

    IEnumerator OutOfFuel()
    {
        
        outOfFuelGameobject.SetActive(true);
        if (earnedMoney.money >= 1000) earnedMoneyText.text = ((double)earnedMoney.money / 1000).ToString("$0.##K");
        else earnedMoneyText.text = "$" + earnedMoney.money;
        yield return new WaitForSeconds(4);

        outOfFuelGameobject.SetActive(false);

        SetFuel();
    }

    public void SetFuel()
    {
        fuel = machineData.fuel;
        fuelAmountSlider.maxValue = fuel;
    }
}
