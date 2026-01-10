using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 startPos;
    public float minX = -8.5f, maxX = -0.5f, minY = -4.5f, maxY = 4.5f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        startPos = transform.position;
    }

    private void FixedUpdate()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 clampedPos = new Vector2(
            Mathf.Clamp(mousePos.x, minX, maxX),
            Mathf.Clamp(mousePos.y, minY, maxY)
        );
        rb.MovePosition(clampedPos);
    }

    public void ResetPosition()
    {
        rb.linearVelocity = Vector2.zero;
        transform.position = startPos;
    }
}