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
    public bool isPlaying;
  void Start()
    {
        isPlaying = false;
    }
    void Update()
    {
        fuelAmount = fuelManager.fuel;
        if (fuelAmount <= 35 )
        {
            animator.Play("WarningAnim");
            
            image.enabled = true;
        }
        else if(fuelAmount> 35 )
        {
            animator.StopPlayback();
           
            image.enabled = false;
        }
    }
}
