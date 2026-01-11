using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    private GameManager.Difficulty selectedDifficulty = GameManager.Difficulty.Easy;
    private GameManager.ObstacleMode selectedObstacle = GameManager.ObstacleMode.None;

    public void SetDifficulty(int index) => selectedDifficulty = (GameManager.Difficulty)index;
    public void SetObstacle(int index) => selectedObstacle = (GameManager.ObstacleMode)index;

    public void PlayGame() => GameManager.Instance.StartGame(selectedDifficulty, selectedObstacle);

    public void BackToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}