using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheBuffDestroyer : MonoBehaviour
{
    public FuelManager fuelManager;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (fuelManager.fuel<0 && (other.gameObject.CompareTag("Money Buff") || other.gameObject.CompareTag("Fuel Buff")) )
        {
            Destroy(other.gameObject);
        }
    }
}
