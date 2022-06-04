using UnityEngine;

public class MoneySpawner : MonoBehaviour
{
    [SerializeField] GameObject[] coins;
    [SerializeField] MoneyManager moneyManager;
    public void Spawn()
    {
        Vector3 randomPos = new Vector3(Random.Range(transform.position.x - 0.12f, transform.position.x + 0.12f), transform.position.y, transform.position.z);
        int randomIndex = Random.Range(0, coins.Length);
        GameObject coinInstance = Instantiate(coins[randomIndex], randomPos, Quaternion.identity) as GameObject;
        Destroy(coinInstance, 1.5f);
        moneyManager.AddMoney();
    }
}
