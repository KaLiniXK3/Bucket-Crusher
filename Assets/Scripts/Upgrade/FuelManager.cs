using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class FuelManager : MonoBehaviour
{
    float fuel;
    [SerializeField] Slider fuelAmountSlider;
    [SerializeField] MachineData machineData;
    [SerializeField] TextMeshProUGUI fuelAmountText;
    private void Start()
    {
        SetFuel();
        fuelAmountSlider.maxValue = fuel;
        SetFuelAmountText();
    }

    private void Update()
    {
        if (fuel >= 0)
        {
            fuel -= Time.deltaTime * 1.2f;
            fuelAmountSlider.value = fuel;
        }
    }

    public void SetFuelAmountText()
    {
        fuelAmountText.text = fuel.ToString("0");
    }

    public void SetFuel()
    {
        fuel = machineData.fuel;
        fuelAmountSlider.maxValue = fuel;
    }
}
