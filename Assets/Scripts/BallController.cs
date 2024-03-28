using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BallController : MonoBehaviour
{
    [SerializeField] private AudioSource _kickBall;
    
    public float maxPower = 25;
    public float minPower = 5;
    public float powerMultiplier = 1f;
    public float stopThreshold = 0.05f;
    public float maxLineLength = 10f;
    public float lineLengthMultiplier = 1f;
    public LineRenderer lineRenderer;


    private Rigidbody rb;
    private Vector3 hitDirection;
    private float currentPower = 0f;
    private bool isAiming = false;
    private bool hasReleasedMouseButton = false;
    private float _maxLength = 2f;


    


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        lineRenderer.enabled = false;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isAiming = true;
            hasReleasedMouseButton = false;
        }
        else if (Input.GetMouseButtonUp(0) && isAiming)
        {
            _kickBall.Play();
            isAiming = false;
            hasReleasedMouseButton = true;
           // attempts.DecreaseAttempts();
        }

        if (isAiming)
        {
            Aim();
        }
    }

    void FixedUpdate()
    {
        if (rb.velocity.magnitude <= stopThreshold && hasReleasedMouseButton)
        {
            Shoot();
            hasReleasedMouseButton = false;
        }
    }

    void Aim()
    {
        // Отображаем линию прицеливания с помощью LineRenderer
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            Vector3 horizontalHitPoint = new Vector3(hit.point.x, transform.position.y, hit.point.z);
            hitDirection = (horizontalHitPoint - transform.position).normalized;
            lineRenderer.enabled = true;
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, horizontalHitPoint);

            // Определяем силу удара на основе длины линии
            float lineLength = Vector3.Distance(transform.position, hit.point);
            Debug.Log(lineLength);
            if (lineLength > _maxLength) {
                lineLength = _maxLength;
            }
            currentPower = Mathf.Lerp(minPower, maxPower, lineLength / _maxLength) * powerMultiplier;
            
        }
    }

    public void Shoot()
    {
        rb.AddForce(hitDirection * currentPower , ForceMode.Impulse);

        lineRenderer.enabled = false;
    }
}



