using UnityEngine;

public interface IAIStrategy
{
    Vector2 CalculateMovement(Vector2 botPos, Vector2 puckPos, Rect limits);
}