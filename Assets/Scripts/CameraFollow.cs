using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform ball;
    [SerializeField] float rotationSpeed = 5.0f;
    [SerializeField] float distance = 5.0f;
    Vector3 offset = Vector3.zero;

    void LateUpdate()
    {

        float horizontalInput = Input.GetAxis("Horizontal");
        transform.RotateAround(ball.position, Vector3.up, horizontalInput * rotationSpeed * Time.deltaTime);

        Vector3 desiredPosition = ball.position + Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0) * offset;
        transform.position = Vector3.Lerp(transform.position, desiredPosition, 0.1f);

        transform.position = ball.position - transform.forward * distance;
    }
}

