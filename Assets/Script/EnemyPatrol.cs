using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(Collider))]
public class EnemyPatrol : MonoBehaviour
{
    public Rigidbody rb;
    public Transform model;

    [Header("Movimento")]
    public float speed = 3f;

    [Header("Detecção")]
    public float rayDistance = 0.5f;
    public float groundRayLength = 1.2f;
    public Vector3 rayOriginOffset = new Vector3(0, 0.5f, 0);
    public LayerMask groundLayer;
    public LayerMask wallLayer;

    private bool movingRight = true;
    private float flipCooldown = 0.3f;
    private float lastFlipTime = 0f;

    void Start()
    {
        if (rb == null)
            rb = GetComponent<Rigidbody>();

        if (model == null)
            model = transform;

        rb.useGravity = true;
        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
        rb.collisionDetectionMode = CollisionDetectionMode.Continuous;
    }

    void FixedUpdate()
    {
        float direction = movingRight ? 1f : -1f;

        rb.linearVelocity = new Vector3(direction * speed, rb.linearVelocity.y, 0);

        Vector3 basePos = transform.position + rayOriginOffset;
        Vector3 frontOrigin = basePos + Vector3.right * direction * 0.4f;
        Vector3 downOrigin = basePos + Vector3.right * direction * 0.3f;

        // Raycasts
        bool wallHit = Physics.Raycast(frontOrigin, Vector3.right * direction, rayDistance, wallLayer);
        bool groundAhead = Physics.Raycast(downOrigin, Vector3.down, groundRayLength, groundLayer);

        // Debug rays
        Debug.DrawRay(frontOrigin, Vector3.right * direction * rayDistance, Color.red);
        Debug.DrawRay(downOrigin, Vector3.down * groundRayLength, Color.green);

        if ((wallHit || !groundAhead) && Time.time - lastFlipTime > flipCooldown)
        {
            Flip();
        }
    }

    void Flip()
    {
        movingRight = !movingRight;
        lastFlipTime = Time.time;

        Vector3 rot = model.eulerAngles;
        rot.y += 180f;
        model.eulerAngles = rot;
    }
}
