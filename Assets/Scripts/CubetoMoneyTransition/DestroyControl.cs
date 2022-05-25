using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyControl : MonoBehaviour
{
    [SerializeField] MoneySpawner spawner;
    bool destroyed;
    bool hasSpawned;

    void Update()
    {
        if (destroyed && !hasSpawned)
        {
            spawner.Spawn();
            hasSpawned = true;

        }
        if (destroyed & hasSpawned)
        {
            destroyed = false;
            hasSpawned = false;
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Cube"))
        {
            destroyed = true;
            Destroy(other.gameObject);
        }
    }
}
