using UnityEngine;

public class Goal : MonoBehaviour
{
    public bool isPlayerGoal; // Si es true, el Bot anota aquí.

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Puck"))
        {
            // Si entra en portería jugador -> Punto para Bot
            GameManager.Instance.AddScore(!isPlayerGoal);
        }
    }

    // --- PATRÓN OBSERVER ---
    private void OnEnable() => GameManager.OnPowerUpCollected += OnPowerUp;
    private void OnDisable() => GameManager.OnPowerUpCollected -= OnPowerUp;

    private void OnPowerUp(PowerUpType type)
    {
        // Si el jugador coge "BigGoal", agrandamos la portería del BOT (para facilitar gol)
        if (type == PowerUpType.BigGoal && !isPlayerGoal)
        {
            transform.localScale = new Vector3(1, 2, 1);
            Invoke("ResetSize", 5f);
        }
    }
    private void ResetSize() => transform.localScale = Vector3.one;
}