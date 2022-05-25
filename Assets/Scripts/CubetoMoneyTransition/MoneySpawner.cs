using UnityEngine;

public class MoneySpawner : MonoBehaviour
{
    [SerializeField] GameObject coin;
    [SerializeField] MoneyManager moneyManager;
    public void Spawn()
    {
        Vector3 randomPos = new Vector3(Random.Range(transform.position.x - 0.10f, transform.position.x + 0.10f), transform.position.y, transform.position.z);
        GameObject coinInstance = Instantiate(coin, randomPos, Quaternion.identity) as GameObject;
        Destroy(coinInstance, 1.5f);
        moneyManager.AddMoney();
    }
}
