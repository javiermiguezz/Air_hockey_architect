using UnityEngine;

public enum PowerUpType { BigPaddle, BigGoal }

public class PowerUp : MonoBehaviour
{
    public PowerUpType type;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Puck"))
        {
            // Notificar al Singleton (Sujeto)
            GameManager.Instance.NotifyPowerUpCollected(type);
            Destroy(gameObject);
        }
    }
}