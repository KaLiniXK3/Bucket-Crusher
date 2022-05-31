using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelBarController : MonoBehaviour
{
    float fuel;
    [SerializeField] Slider fuelAmountSlider;
    [SerializeField] MachineData machineData;



    private void Start()
    {
        SetFuel();
        fuelAmountSlider.maxValue = fuel;

        
     
       
    }

    // Update is called once per frame
    private void Update()
    {
        if (fuel >= 0)
        {
            fuel -= Time.deltaTime * 1.2f;
            fuelAmountSlider.value = fuel;
        }
        
    }

    public void SetFuel()
    {
        fuel = machineData.fuel;
        fuelAmountSlider.maxValue = fuel;
    }
    
}
