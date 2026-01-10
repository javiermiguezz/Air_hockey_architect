using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("Marcador")]
    public int playerScore = 0;
    public int botScore = 0;
    public int maxScore = 5;

    [Header("Referencias UI")]
    public TextMeshProUGUI scoreTextPlayer;
    public TextMeshProUGUI scoreTextBot;
    public GameObject menuPanel;
    public GameObject gamePanel;
    public GameObject gameOverPanel;
    public TextMeshProUGUI winnerText;

    [Header("Referencias Objetos")]
    public PlayerController player;
    public BotAI bot;
    public Puck puck;
    public ObstacleFactory obstacleFactory;

    public static event Action<PowerUpType> OnPowerUpCollected;

    public enum Difficulty { Easy, Medium, Hard }
    public enum ObstacleMode { None, Friction, Bouncy }

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    private void Start()
    {
        ShowMenu();
    }

    public void StartGame(Difficulty difficulty, ObstacleMode obsMode)
    {
        playerScore = 0;
        botScore = 0;
        UpdateScoreUI();

        // Configurar Estrategia del Bot
        if (bot != null)
        {
            switch (difficulty)
            {
                case Difficulty.Easy: bot.SetStrategy(new EasyAIStrategy()); break;
                case Difficulty.Medium: bot.SetStrategy(new MediumAIStrategy()); break;
                case Difficulty.Hard: bot.SetStrategy(new HardAIStrategy()); break;
            }
        }

        obstacleFactory?.CreateObstacles(obsMode);

        menuPanel.SetActive(false);
        gameOverPanel.SetActive(false);
        gamePanel.SetActive(true);

        Time.timeScale = 1f;
        ResetPositions();
    }

    public void AddScore(bool isPlayer)
    {
        if (isPlayer) playerScore++; else botScore++;
        UpdateScoreUI();

        if (playerScore >= maxScore || botScore >= maxScore) EndGame();
        else StartCoroutine(ResetRound());
    }

    private void UpdateScoreUI()
    {
        if (scoreTextPlayer) scoreTextPlayer.text = playerScore.ToString();
        if (scoreTextBot) scoreTextBot.text = botScore.ToString();
    }

    private void EndGame()
    {
        Time.timeScale = 0f;
        gamePanel.SetActive(false);
        gameOverPanel.SetActive(true);
        winnerText.text = playerScore >= maxScore ? "¡Has ganado!" : "Has perdido";
        winnerText.color = playerScore >= maxScore ? Color.green : Color.red;
    }

    private IEnumerator ResetRound()
    {
        Time.timeScale = 0.2f;
        yield return new WaitForSecondsRealtime(0.8f);
        Time.timeScale = 1f;
        ResetPositions();
    }

    public void ResetPositions()
    {
        player?.ResetPosition();
        bot?.ResetPosition();
        puck?.ResetPosition();
    }

    public void ShowMenu()
    {
        Time.timeScale = 0f;
        menuPanel.SetActive(true);
        gamePanel.SetActive(false);
        gameOverPanel.SetActive(false);
    }

    public void NotifyPowerUpCollected(PowerUpType type) => OnPowerUpCollected?.Invoke(type);
}