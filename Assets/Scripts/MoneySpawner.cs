using UnityEngine;

public class MoneySpawner : MonoBehaviour
{
    [SerializeField] GameObject coin;
    [SerializeField] MoneyManager moneyManager;
    float[] moneyTypes = { 0.25f, 0.50f, 1f, 2f, 3f, 4f, 5f };
    public void Spawn()
    {
        Vector3 randomPos = new Vector3(Random.Range(transform.position.x - 0.10f, transform.position.x + 0.10f), transform.position.y, transform.position.z);
        GameObject coinInstance = Instantiate(coin, randomPos, Quaternion.identity) as GameObject;
        Destroy(coinInstance, 1.5f);
        int moneyTypeIndex = Random.Range(0, moneyTypes.Length);
        float randomMoney = moneyTypes[moneyTypeIndex];
        moneyManager.AddMoney(randomMoney);
    }
}
