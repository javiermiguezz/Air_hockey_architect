using UnityEngine;

public class BotAI : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 startPos;
    public Transform puck;

    // --- PATRÓN STRATEGY: Referencia a la interfaz ---
    private IAIStrategy currentStrategy;

    public float speed = 10f;
    public Rect limits = new Rect(0, -4.5f, 8, 9); // Ajusta a tu campo derecho

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        startPos = transform.position;
    }

    public void SetStrategy(IAIStrategy strategy)
    {
        currentStrategy = strategy;

        // Asignar velocidades segun el tipo de clase
        if (strategy is EasyAIStrategy) speed = 6f;
        else if (strategy is MediumAIStrategy) speed = 9f;
        else if (strategy is HardAIStrategy) speed = 12f;
    }

    private void FixedUpdate()
    {
        if (currentStrategy != null && puck != null)
        {
            // Delegamos la decisión de movimiento a la estrategia
            Vector2 targetPos = currentStrategy.CalculateMovement(transform.position, puck.position, limits);

            // Movemos físicamente para golpear
            Vector2 newPos = Vector2.MoveTowards(transform.position, targetPos, speed * Time.fixedDeltaTime);
            rb.MovePosition(newPos);
        }
    }

    public void ResetPosition()
    {
        transform.position = startPos;
    }
}