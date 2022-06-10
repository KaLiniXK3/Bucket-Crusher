using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffSpawner : MonoBehaviour
{
    public GameObject[] buffsDebuffs;
    private float startDelay = 5;
    private float spawnInterval = 10;

    public object SetActive { get; internal set; }

    void Start()
    {
        InvokeRepeating("SpawnRandomBuffDebuff", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {


    }
   public void SpawnRandomBuffDebuff()
    {
        int buffDebuffIndex = Random.Range(0, buffsDebuffs.Length);
        Vector3 spawnPos = new Vector3(Random.Range(-0.125f, 0.258f), transform.position.y, transform.position.z);

        Instantiate(buffsDebuffs[buffDebuffIndex], spawnPos, buffsDebuffs[buffDebuffIndex].transform.rotation);
    }
}
