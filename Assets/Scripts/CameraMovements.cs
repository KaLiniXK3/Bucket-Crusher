using UnityEngine;

public class CameraMovements : MonoBehaviour
{
    [SerializeField] Joystick joystick;

    private void Update()
    {
        MoveCam(joystick.Horizontal, joystick.Vertical);
    }

    public void MoveCam(float x, float y)
    {
        Vector3 position = transform.position + new Vector3(x, y, 0);
        position.x = Mathf.Clamp(position.x, -0.01f, 0.435f);
        position.y = Mathf.Clamp(position.y, 0.4f, 0.84f);
        transform.position = Vector3.Lerp(transform.position, position, Time.deltaTime * 0.3f);
    }


}
