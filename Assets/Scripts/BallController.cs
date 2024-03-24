using UnityEngine;

public class BallController : MonoBehaviour
{
    public float maxPower = 100f;
    public float minPower = 0f;
    public float powerChangeSpeed = 1f;
    public float rotationSpeed = 5f;

    private Rigidbody rb;
    private Vector3 hitDirection;
    private float currentPower = 0f;
    private bool isAiming = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isAiming = true;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isAiming = false;
            Shoot();
        }

        float mouseY = Input.GetAxis("Mouse Y");
        currentPower += mouseY * powerChangeSpeed;
        currentPower = Mathf.Clamp(currentPower, minPower, maxPower);
    }

    void FixedUpdate()
    {
        if (isAiming)
        {
            Aim();
        }
    }

    void Aim()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            hitDirection = (hit.point - transform.position).normalized;

            Debug.DrawLine(transform.position, hit.point, Color.red);
        }
    }

    void Shoot()
    {
        rb.AddForce(hitDirection * currentPower, ForceMode.Impulse);

        currentPower = 0f;
    }
}





