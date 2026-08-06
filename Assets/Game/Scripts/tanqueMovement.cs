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

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
{
    if (Input.GetButtonDown("Fire1") && Time.time >= nextFireTime)
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
            // Se estiver usando Unity 6
            bulletRb.linearVelocity = spawnPoint.right * bulletSpeed;

            // Para versões anteriores:
            // bulletRb.velocity = spawnPoint.right * bulletSpeed;
        }
    }
}

    void FixedUpdate()
    {
        // Movimento
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Rotação
        Quaternion deltaRotation = Quaternion.Euler(
            0f,
            horizontal * rotationSpeed * Time.fixedDeltaTime,
            0f
        );

        rb.MoveRotation(rb.rotation * deltaRotation);

        // Anda para frente e para trás
        Vector3 velocity = transform.right * vertical * moveSpeed;

        // Se sua versão do Unity não tiver linearVelocity, use rb.velocity
        rb.linearVelocity = velocity;
    }
}