using UnityEngine;

public class IKManager : MonoBehaviour
{
    public Joints root;
    public Joints end;

    public GameObject target;

    public float threshhold = 0.05f;
    public float rate = 15;
    int steps = 20;
    public Joystick joystickInput;
    [SerializeField] int speed = 3;
    float CalculateSlope(Joints joint)
    {
        float deltaTheta = 0.01f;
        float distance1 = GetDistance(end.transform.position, target.transform.position);
        joint.Rotate(deltaTheta);
        float distance2 = GetDistance(end.transform.position, target.transform.position);
        joint.Rotate(-deltaTheta);

        return (distance2 - distance1) / deltaTheta;
    }

    private void Update()
    {
        for (int i = 0; i < steps; i++)
        {
            if (GetDistance(end.transform.position, target.transform.position) > threshhold)
            {
                Joints current = root;
                while (current != null)
                {
                    float slope = CalculateSlope(current);
                    current.Rotate(-slope * rate);
                    current = current.GetChild();
                }
            }
        }

        Vector3 position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        position.x += joystickInput.Horizontal * Time.deltaTime * speed;
        position.y += joystickInput.Vertical * Time.deltaTime * speed;
        position.x = Mathf.Clamp(position.x, -2, 2);
        position.y = Mathf.Clamp(position.y, -2, 2);
        transform.position = position;


    }
    float GetDistance(Vector3 point1, Vector3 point2)
    {
        return Vector3.Distance(point1, point2);
    }

}
