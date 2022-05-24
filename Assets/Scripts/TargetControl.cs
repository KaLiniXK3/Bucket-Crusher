using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetControl : MonoBehaviour
{
    [SerializeField] Joystick joystickInput;
    [SerializeField] float speed;
    [SerializeField] float constraintValue;

    private void Update()
    {
        Vector3 position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        position.x += joystickInput.Horizontal;
        position.y += joystickInput.Vertical;
        //position.x = Mathf.Clamp(position.x, -constraintValue, constraintValue);
        //position.y = Mathf.Clamp(position.y, -constraintValue, constraintValue);
        transform.position = position;
    }

}
