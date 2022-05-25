using UnityEngine;
using TMPro;
public class MoneyManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI moneyText;
    float[] moneyTypes = { 0.25f, 0.50f, 1f, 2f, 3f, 4f, 5f };
    public float money;

    private void Start()
    {
        moneyText.text = money.ToString("C2");
    }

    public void AddMoney()
    {
        int moneyTypeIndex = Random.Range(0, moneyTypes.Length);
        float randomMoney = moneyTypes[moneyTypeIndex];
        money += randomMoney;
        moneyText.text = money.ToString("C2");
    }

}
