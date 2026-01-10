using UnityEngine;

public class EasyAIStrategy : IAIStrategy
{
    public Vector2 CalculateMovement(Vector2 botPos, Vector2 puckPos, Rect limits)
    {
        // Solo sigue la Y, movimiento lento, se queda en el centro X de su campo
        float targetX = limits.x + (limits.width / 2);
        float targetY = Mathf.Clamp(puckPos.y, limits.y, limits.y + limits.height);

        // Añadimos error/retraso con Lerp simulado
        return new Vector2(targetX, targetY);
    }
}