using UnityEngine;
using TMPro;
public class MoneyManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI moneyText;
    float[] moneyTypes = { 0.25f, 0.50f, 1f, 2f, 3f, 4f, 5f };
    float[] moneyTypes2 = { 10f, 15f, 20f };
    public float money;

    private void Start()
    {
        SetMoneyText();
    }

    public void AddMoney()
    {
        int moneyTypeIndex = Random.Range(0, moneyTypes.Length);
        float randomMoney = moneyTypes[moneyTypeIndex];
        money += randomMoney;
        SetMoneyText();
    }
    public void AddMoney2()
    {
        int moneyType2Index = Random.Range(0, moneyTypes2.Length);
        float randomMoney2 = moneyTypes2[moneyType2Index];
        money += randomMoney2;
        SetMoneyText();
    }

    public void SetMoneyText()
    {
        moneyText.text = money.ToString("C2");
        if (money >= 1000) moneyText.text = ((double)money / 1000).ToString("$0.##k");
        else moneyText.text = "$" + money;

    }

    public void SetMoney(int amount)
    {
        money += amount;
    }
}
