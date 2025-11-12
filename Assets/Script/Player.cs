using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    public Rigidbody rb;
    public GameObject model;
    public JumpScript jumpDetector;

    [Header("Configurações de Movimento")]
    public float speed = 5f;
    public float jumpPower = 7f;
    public float rotateSpeed = 10f; 

    private bool facingRight = true;
    private Quaternion targetRotation;

    void Start()
    {
        if (rb == null)
            rb = GetComponent<Rigidbody>();

        if (jumpDetector == null)
            jumpDetector = GetComponentInChildren<JumpScript>();

        if (model == null)
            model = this.gameObject;

        // Começa apontando para frente
        targetRotation = model.transform.rotation;
    }

    void Update()
    {
        float move = 0f;

        if (Input.GetKey(KeyCode.D))
            move = -1f;
        else if (Input.GetKey(KeyCode.A))
            move = 1f;

        rb.linearVelocity = new Vector3(move * speed, rb.linearVelocity.y, 0);

        if (move > 0 && !facingRight)
        {
            facingRight = true;
            targetRotation = Quaternion.Euler(0, -270, 0);
        }
        else if (move < 0 && facingRight)
        {
            facingRight = false;
            targetRotation = Quaternion.Euler(0, -90, 0);
        }

        model.transform.rotation = Quaternion.Lerp(
            model.transform.rotation,
            targetRotation,
            rotateSpeed * Time.deltaTime
        );

        if (Input.GetKeyDown(KeyCode.W) && jumpDetector.allowJump)
            Pula();
    }

    void Pula()
    {
        rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0, 0);
        rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
    }
}
