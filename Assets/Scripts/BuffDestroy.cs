using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffDestroy: MonoBehaviour
{
    private void Update()
    {
        Destroy(gameObject, 5f);
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Knives") || collision.gameObject.CompareTag("Ground") /*|| collision.gameObject.CompareTag("Cube")*/)
        {
           
            Destroy(gameObject);
        
        }

    }
}
