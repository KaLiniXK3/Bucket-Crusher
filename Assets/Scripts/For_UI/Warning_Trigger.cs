using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warning_Trigger : MonoBehaviour
{
    private static float fuelAmount;

    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }
  
    // Update is called once per frame
    void Update()
    {
        fuelAmount = FuelManager.fuel;

        if (fuelAmount <= 35)
            StartCoroutine(Blink());
            /* animator.SetTrigger("Warning"); */
        
       
        
    }

     IEnumerator Blink()
    {
        animator.SetTrigger("Warning");

        yield return new WaitForSeconds(4);

        animator.ResetTrigger("Warning");



    }
}
