using UnityEngine;

public class HardAIStrategy : IAIStrategy
{
    public Vector2 CalculateMovement(Vector2 botPos, Vector2 puckPos, Rect limits)
    {
        // Agresivo: Intenta golpear el puck siempre que entre en su campo
        Vector2 target = puckPos;

        // Si el puck está en el campo del jugador, vuelve al centro rápidamente
        if (puckPos.x < limits.x)
        {
            target = new Vector2(limits.x + limits.width / 2, 0);
        }

        // Clamping para no salir del campo
        target.x = Mathf.Clamp(target.x, limits.x, limits.x + limits.width);
        target.y = Mathf.Clamp(target.y, limits.y, limits.y + limits.height);

        return target;
    }
}