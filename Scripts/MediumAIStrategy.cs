using UnityEngine;

public class MediumAIStrategy : IAIStrategy
{
    public Vector2 CalculateMovement(Vector2 botPos, Vector2 puckPos, Rect limits)
    {
        // Sigue la Y con precisión, avanza un poco si el puck está cerca
        float targetX = limits.x + (limits.width / 3); // Posición defensiva

        if (puckPos.x > limits.x) // Si el puck entra en su campo
        {
            targetX = puckPos.x; // Intenta interceptar
        }

        float targetY = Mathf.Clamp(puckPos.y, limits.y, limits.y + limits.height);
        return new Vector2(Mathf.Clamp(targetX, limits.x, limits.x + limits.width), targetY);
    }
}