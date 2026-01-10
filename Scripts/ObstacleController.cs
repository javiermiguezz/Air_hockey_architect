using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    private IAIObstacleStrategy strategy;

    public void SetStrategy(IAIObstacleStrategy newStrategy)
    {
        this.strategy = newStrategy;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Puck") && strategy != null)
        {
            strategy.ApplyEffect(other.GetComponent<Rigidbody2D>());
        }
    }
}