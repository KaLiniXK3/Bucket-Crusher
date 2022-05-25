using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateKnifes : MonoBehaviour
{
    [SerializeField] int speed;
    private void Update()
    {
        transform.Rotate(new Vector3(0, 0, -1) * Time.deltaTime * speed);
    }
}
