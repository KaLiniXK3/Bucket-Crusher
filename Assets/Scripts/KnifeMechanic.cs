using UnityEngine;

public class KnifeMechanic : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Cube"))
        {
            if (collision.gameObject.GetComponent<Rigidbody>() == null)
            {
                Debug.Log(collision.gameObject.name);
                collision.gameObject.AddComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionZ;
            }
        }
    }
}
