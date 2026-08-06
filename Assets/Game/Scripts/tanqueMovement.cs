using UnityEngine;

public class tanqueMovement : MonoBehaviour
{

    [Header("Configuracoes de Movimento")]
    [Tooltip("Velocidade de movimento para frente (Tecla W)")]
    public float velocidadeMovimento = 10f;

    [Tooltip("Velocidade de rotacao (Teclas A e D)")]
    public float velocidadeRotacao = 100f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        
        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
    }

    void FixedUpdate()
    {
        MoverParaFrente();
        Rotacionar();
    }

    void MoverParaFrente()
    {
        
        if (Input.GetKey(KeyCode.W))
        {
            
            Vector3 deslocamento = transform.forward * velocidadeMovimento * Time.fixedDeltaTime;
            rb.MovePosition(rb.position + deslocamento);
        }
    }

    void Rotacionar()
    {
        
        float direcaoRotacao = 0f;

        if (Input.GetKey(KeyCode.D))
        {
            direcaoRotacao = 1f;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            direcaoRotacao = -1f;
        }

        
        float grausParaGirar = direcaoRotacao * velocidadeRotacao * Time.fixedDeltaTime;
        Quaternion deltaRotation = Quaternion.Euler(0f, grausParaGirar, 0f);
        
        rb.MoveRotation(rb.rotation * deltaRotation);
    }
}
