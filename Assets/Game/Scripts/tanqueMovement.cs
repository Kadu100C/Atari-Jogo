using UnityEngine;

public class tanqueMovement : MonoBehaviour
{
    
    public float moveSpeed = 1f;
    public float rotationSpeed = 180f;

    private Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();

        }

    void FixedUpdate()
    {
        // Horizontal = A/D ou Setas Esquerda/Direita
        float horizontal = Input.GetAxis("Horizontal");

        // Vertical = W/S ou Setas Cima/Baixo
        float vertical = Input.GetAxis("Vertical");

        // Rotaciona no eixo Y
        Quaternion deltaRotation = Quaternion.Euler(0f, horizontal * rotationSpeed * Time.fixedDeltaTime, 0f);
        rb.MoveRotation(rb.rotation * deltaRotation);

   Vector3 velocity = transform.right* vertical * moveSpeed;


rb.linearVelocity = velocity;
    }
}