using UnityEngine;

public class ObstacleFactory : MonoBehaviour
{
    public GameObject frictionPrefab;
    public GameObject bouncyPrefab;

    // Lista para guardar los creados y borrarlos al reiniciar
    private System.Collections.Generic.List<GameObject> activeObstacles = new System.Collections.Generic.List<GameObject>();

    public void CreateObstacles(GameManager.ObstacleMode mode)
    {
        // Limpiar anteriores
        foreach (var obs in activeObstacles) Destroy(obs);
        activeObstacles.Clear();

        if (mode == GameManager.ObstacleMode.None) return;

        GameObject prefabToUse = (mode == GameManager.ObstacleMode.Friction) ? frictionPrefab : bouncyPrefab;

        // Crear 2 obstáculos simétricos
        Vector2 pos1 = new Vector2(0, 2.5f);
        Vector2 pos2 = new Vector2(0, -2.5f);

        Spawn(prefabToUse, pos1, mode);
        Spawn(prefabToUse, pos2, mode);
    }

    private void Spawn(GameObject prefab, Vector2 pos, GameManager.ObstacleMode mode)
    {
        GameObject obj = Instantiate(prefab, pos, Quaternion.identity);
        activeObstacles.Add(obj);

        // Configurar la estrategia del obstáculo
        ObstacleController controller = obj.GetComponent<ObstacleController>();
        if (controller != null)
        {
            if (mode == GameManager.ObstacleMode.Friction)
                controller.SetStrategy(new FrictionStrategy());
            else if (mode == GameManager.ObstacleMode.Bouncy)
                controller.SetStrategy(new BouncyStrategy());
        }
    }
}