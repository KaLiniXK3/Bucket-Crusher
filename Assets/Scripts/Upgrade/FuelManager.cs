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
    public GameObject Canvas;
    public TextMeshProUGUI earnedMoneyText;
    public MoneyManager earnedMoney;


    private void Start()
    {
        SetFuel();
        fuelAmountSlider.maxValue = fuel;
        
        //SetFuelAmountText();//
    }

    private void Update()
    {
        if (fuel > 0) //fuel >= 0 idi
        {
            fuel -= Time.deltaTime * 12f; //1.2f 
            fuelAmountSlider.value = fuel;
           
            
        }
        else
        {
            
            StartCoroutine(GoBack()); 
            
            

        } 

    }

    /*public void SetFuelAmountText()
    {
        fuelAmountText.text = fuel.ToString("0");
    }*/

    IEnumerator GoBack()
    {
        
        Canvas.SetActive(true);
        if (earnedMoney.money >= 1000) earnedMoneyText.text = ((double)earnedMoney.money / 1000).ToString("$0.##K");
        else earnedMoneyText.text = "$" + earnedMoney.money;
       

        yield return new WaitForSeconds(4);

        Canvas.SetActive(false);

        SetFuel();

        
    }

    public void SetFuel()
    {
        fuel = machineData.fuel;
        fuelAmountSlider.maxValue = fuel;
    }
}
