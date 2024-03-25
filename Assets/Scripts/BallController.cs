using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BallController : MonoBehaviour
{
    public float maxPower = 100f; // Максимальная сила удара
    public float minPower = 0f;   // Минимальная сила удара
    public float powerMultiplier = 1f; // Множитель силы удара
    public float stopThreshold = 0.05f; // Порог скорости для определения остановки мяча

    private Rigidbody rb;
    private Vector3 hitDirection;
    private float currentPower = 0f;
    private bool isAiming = false;

    public LineRenderer lineRenderer;

    public Attempts attempts;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        lineRenderer.enabled = false; // Линия прицеливания изначально не отображается
    }

    void Update()
    {
        // Проверка на остановку мяча
        if (rb.velocity.magnitude <= stopThreshold)
        {
            // Обработка нажатия левой кнопки мыши для прицеливания и удара
            if (Input.GetMouseButtonDown(0))
            {
                isAiming = true;
            }
            else if (Input.GetMouseButtonUp(0) && isAiming)
            {
                isAiming = false;
                Shoot();
                attempts.DecreaseAttempts();
            }
        }

        // Отображение линии прицеливания (для отладки)
        if (isAiming)
        {
            Aim();
        }
    }

    void Aim()
    {
        // Отображаем линию прицеливания с помощью LineRenderer
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            hitDirection = (hit.point - transform.position).normalized;
            lineRenderer.enabled = true;
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, hit.point);

            // Определяем силу удара на основе длины линии
            float lineLength = Vector3.Distance(transform.position, hit.point);
            currentPower = Mathf.Lerp(minPower, maxPower, lineLength / lineRenderer.GetPosition(1).magnitude) * powerMultiplier;
        }
    }

    public void Shoot()
    {
        // Применяем силу удара к мячу
        rb.AddForce(hitDirection * currentPower, ForceMode.Impulse);

        // Выключаем линию прицеливания
        lineRenderer.enabled = false;
    }
}

