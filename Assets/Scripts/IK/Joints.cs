using UnityEngine;

public class Joints : MonoBehaviour
{
    public Joints child;

    public Joints GetChild()
    {
        return child;
    }

    public void Rotate(float angle)
    {
        transform.Rotate(Vector3.forward * angle);
    }
}
