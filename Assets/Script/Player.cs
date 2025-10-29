using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    public Rigidbody rb;
    public JumpScript jumpDetector;

    public float speed = 5f;
    public float jumpPower = 7f;

    void Start()
    {
        // Garante que o Rigidbody e JumpScript estejam atribuídos
        if (rb == null)
            rb = GetComponent<Rigidbody>();

        if (jumpDetector == null)
            jumpDetector = GetComponentInChildren<JumpScript>();
    }

    void Update()
    {
        float move = 0f;

        if (Input.GetKey(KeyCode.D))
            move = -1f;
        else if (Input.GetKey(KeyCode.A))
            move = 1f;

        rb.linearVelocity = new Vector3(move * speed, rb.linearVelocity.y, 0);

        if (Input.GetKeyDown(KeyCode.W) && jumpDetector.allowJump)
            Pula();
    }

    void Pula()
    {
        rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0, 0);
        rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
    }
}
