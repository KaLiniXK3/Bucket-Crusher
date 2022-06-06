using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class WarningTrigger : MonoBehaviour
{
    private float fuelAmount;
    [SerializeField] FuelManager fuelManager;
    [SerializeField] Animator animator;
    public Image image;

    void Update()
    {
        fuelAmount = fuelManager.fuel;
        if (fuelAmount <= 35)
        {
            animator.Play("WarningAnim");
        }
    }
}
