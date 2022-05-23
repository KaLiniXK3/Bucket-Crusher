using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawn : MonoBehaviour
{
    public GameObject coin;
    public void Spawn()

    { 
        Instantiate(coin, transform.position, Quaternion.identity);
        
        
    }
}
