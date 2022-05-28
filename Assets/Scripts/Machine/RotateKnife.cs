using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateKnife : MonoBehaviour
{
    public int power;
    private void Update()
    {
        transform.Rotate(new Vector3(0, 0, -1) * Time.deltaTime * power);
    }
}
