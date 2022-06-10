using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffSpawner : MonoBehaviour
{
    public GameObject[] buffs;
    private float startDelay = 5;
    private float spawnInterval = 10;

    public object SetActive { get; internal set; }

    void Start()
    {
        InvokeRepeating("SpawnRandomBuff", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {


    }
   public void SpawnRandomBuff()
    {
        int buffIndex = Random.Range(0, buffs.Length);
        Vector3 spawnPos = new Vector3(Random.Range(-0.125f, 0.258f), transform.position.y, transform.position.z);

        Instantiate(buffs[buffIndex], spawnPos, buffs[buffIndex].transform.rotation);
    }
}
