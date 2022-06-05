using UnityEngine;

public class MoneySpawner : MonoBehaviour
{
    [SerializeField] GameObject[] coins;
    [SerializeField] MoneyManager moneyManager;
    public void Spawn()
    {
        float randomPosX = Random.Range(transform.position.x - 0.10f, transform.position.x + 0.10f);
        float randomPosZ = Random.Range(transform.position.z - 0.02f, transform.position.z + 0.02f);
        Vector3 randomPos = new Vector3(randomPosX, transform.position.y, randomPosZ);
        int randomIndex = Random.Range(0, coins.Length);
        GameObject coinInstance = Instantiate(coins[randomIndex], randomPos, Quaternion.identity) as GameObject;
        Destroy(coinInstance, 1.5f);
        moneyManager.AddMoney();
    }
}
