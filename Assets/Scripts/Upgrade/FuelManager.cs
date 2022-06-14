using UnityEngine;
using UnityEngine.UI;

public class FuelManager : MonoBehaviour
{
    public float fuel;
    public bool outOfFuel = false;
    [SerializeField] public Slider fuelAmountSlider;
    [SerializeField] MachineData machineData;
    [SerializeField] GameManager gameManager;


    public void UseFuel()
    {
        if (fuel > 0)
        {
            fuel -= Time.deltaTime * 12f;
            fuelAmountSlider.value = fuel;
        }
        else
        {
            if (!outOfFuel)
            {
                outOfFuel = true;
                StartCoroutine(gameManager.OutOfFuelEvents());
            }

        }
    }

    public void SetFuel()
    {
        fuel = machineData.fuel;
        fuelAmountSlider.maxValue = machineData.fuel;
        fuelAmountSlider.value = fuel;
    }
}
