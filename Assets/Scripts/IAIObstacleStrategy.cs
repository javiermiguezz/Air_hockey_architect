using UnityEngine;

public interface IAIObstacleStrategy
{
    void ApplyEffect(Rigidbody2D puckRb);
}

public class FrictionStrategy : IAIObstacleStrategy
{
    public void ApplyEffect(Rigidbody2D puckRb)
    {
        // Reduce la velocidad (efecto barro)
        puckRb.linearVelocity *= 0.95f;
    }
}

public class BouncyStrategy : IAIObstacleStrategy
{
    public void ApplyEffect(Rigidbody2D puckRb)
    {
        // Aumenta la velocidad (efecto acelerador/rebote loco)
        // Nota: Para rebote f�sico real, usa PhysicsMaterial en el collider no-trigger.
        // Esto es para un efecto de "�rea de aceleraci�n".
        puckRb.linearVelocity *= 1.05f;
    }
}