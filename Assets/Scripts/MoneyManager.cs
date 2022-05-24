using UnityEngine;
using TMPro;
public class MoneyManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI moneyText;

    public float money;

    private void Start()
    {
        moneyText.text = money.ToString("C2");
    }

    public void AddMoney(float amount)
    {
        money += amount;
        moneyText.text = money.ToString("C2");
    }

}
