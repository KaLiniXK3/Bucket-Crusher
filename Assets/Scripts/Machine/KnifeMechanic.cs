using UnityEngine;

public class KnifeMechanic : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Cube"))
        {
            if (collision.gameObject.GetComponent<Rigidbody>() == null)
            {
                Rigidbody cubeRb = collision.gameObject.AddComponent<Rigidbody>();
                cubeRb.constraints = RigidbodyConstraints.FreezePositionZ;
                cubeRb.useGravity = true;
                cubeRb.collisionDetectionMode = CollisionDetectionMode.Continuous;
            }
        }
    }
}
