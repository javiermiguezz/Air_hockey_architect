using UnityEngine;

public class Puck : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 startPos;

    [Header("Física")]
    public float maxSpeed = 20f; 
    public float startingImpulse = 7f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        startPos = transform.position;
    }

    private void FixedUpdate()
    {
        if (rb.linearVelocity.magnitude > maxSpeed)
        {
            rb.linearVelocity = rb.linearVelocity.normalized * maxSpeed;
        }
    }

    public void ResetPosition()
    {
        transform.position = startPos;
        rb.linearVelocity = Vector2.zero;
        rb.angularVelocity = 0;

        float xDir = UnityEngine.Random.Range(0, 2) == 0 ? -1 : 1;
        float yDir = UnityEngine.Random.Range(-0.5f, 0.5f);
        rb.AddForce(new Vector2(xDir, yDir).normalized * startingImpulse, ForceMode2D.Impulse);
    }
}