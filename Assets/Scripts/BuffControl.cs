using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffControl: MonoBehaviour
{
    public MoneyManager mM;
    public FuelManager fuelManager;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Money Buff"))
        {
            SoundManager.PlayTheSound("moneyBuff");
            mM.AddMoney2();
            mM.SetMoneyText();
            Debug.Log("MoneyEarned");
        }
        if (collision.gameObject.CompareTag("Fuel Buff"))
        {
            SoundManager.PlayTheSound("fuelBuff");
            
            fuelManager.fuel +=  (fuelManager.fuel / 4);
            fuelManager.fuelAmountSlider.value = fuelManager.fuel;
            fuelManager.UseFuel();

            Debug.Log("FuelEarned");
            Debug.Log(fuelManager.fuel);
        }
    }
    
}
