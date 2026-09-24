using UnityEngine;

public class tanqueMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 180f;

    public Transform spawnPoint;     // Local de onde o tiro sai
    public GameObject bulletPrefab;  // Prefab da bala
    public float bulletSpeed = 10f;

    private Rigidbody rb;

    public float fireCooldown = 1f; // Tempo entre tiros
    private float nextFireTime = 0f;

    public string botaoAtirar;
    public string mhorizontal;
    public string mvertical;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetButtonDown(botaoAtirar) && Time.time >= nextFireTime)
        {
            // Define quando poderá atirar novamente
            nextFireTime = Time.time + fireCooldown;

            GameObject bullet = Instantiate(
                bulletPrefab,
                spawnPoint.position,
                spawnPoint.rotation
            );

            Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();

            if (bulletRb != null)
            {
                // usa spawnPoint.right para o tiro ir na direção do Eixo X local
                bulletRb.linearVelocity = spawnPoint.right * bulletSpeed;

                // Para versões anteriores da Unity:
                // bulletRb.velocity = spawnPoint.right * bulletSpeed;
            }
        }
    }

    void FixedUpdate()
    {
        // Movimento
        float horizontal = Input.GetAxis(mhorizontal);
        float vertical = Input.GetAxis(mvertical);

        // Rotação no eixo Y
        Quaternion deltaRotation = Quaternion.Euler(
            0f,
            horizontal * rotationSpeed * Time.fixedDeltaTime,
            0f
        );

        rb.MoveRotation(rb.rotation * deltaRotation);

        // Movimento no Eixo X local do tanque
        Vector3 velocity = transform.forward * vertical * moveSpeed;

        rb.linearVelocity = velocity;
    }
}