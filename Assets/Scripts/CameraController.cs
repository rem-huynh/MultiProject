using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform playerTransform;
    public float distanceFromPlayer = 2.0f;
    public float currentX = 0.0f;
    public float currentY = 0.0f;
    public float sensitivityX = 4.0f;
    public float sensitivityY = 1.0f;

    private void Update()
    {
        currentX += Input.GetAxis("Mouse X") * sensitivityX;
        currentY -= Input.GetAxis("Mouse Y") * sensitivityY;
        currentY = Mathf.Clamp(currentY, -35, 60);
    }

    private void LateUpdate()
    {
        Vector3 dir = new Vector3(0, 0, -distanceFromPlayer);
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
        transform.position = playerTransform.position + rotation * dir;
        transform.LookAt(playerTransform.position);
    }
}
