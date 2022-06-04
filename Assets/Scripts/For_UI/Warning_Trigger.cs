using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warning_Trigger : MonoBehaviour
{
    private float fuelAmount;
    [SerializeField] FuelManager fuelManager;
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        fuelAmount = fuelManager.fuel;

        if (fuelAmount <= 35)
            StartCoroutine(Blink());
    }

    IEnumerator Blink()
    {
        animator.SetTrigger("Warning");

        yield return new WaitForSeconds(4);

        animator.ResetTrigger("Warning");
    }
}
