using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameState gameState { get; private set; }
    [SerializeField] private List<Canvas> gameOverScreens;
    [SerializeField] private List<Canvas> ongoingGameScreens;
    [SerializeField] private TurretManager turretManager;
    [SerializeField] private ScreensManager screensManager;
    [SerializeField] private TextMeshProUGUI wristData;

    [SerializeField] private TrackVelocity leftHandVelocity;
    [SerializeField] private TrackVelocity rightHandVelocity;
    [SerializeField] private TrackVelocity headVelocity;

    [SerializeField] private GameObject target;

    private int score;

    private float averageVelocity;

    private string scoreString;

    public enum GameState
    {
        StartMenu,
        Playing,
        GameOver
    }

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        switch (gameState)
        {
            case GameState.StartMenu:
                break;
            case GameState.Playing:
                turretManager.UpdateTurrets();
                screensManager.UpdateAllScoreScreenTexts("Score: " + score + "\n" + scoreString);
                break;
            case GameState.GameOver:
                break;
        }
    }

    private void LateUpdate()
    {
        averageVelocity = (leftHandVelocity.velocity + rightHandVelocity.velocity + headVelocity.velocity) / 3;
        averageVelocity = Mathf.Clamp(averageVelocity, 0f, 1f);
        //Time.timeScale = 1 - averageVelocity;

        wristData.text = averageVelocity.ToString();
    }

    public void StartGame()
    {
        gameState = GameState.Playing;
        turretManager.SetAllTurretsActive(true);
        turretManager.CycleState();
        screensManager.StartGame();
        target.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

    public void GameOver()
    {
        gameState = GameState.GameOver;
        turretManager.SetIdle();
        screensManager.SetGameOver(score);
        target.SetActive(false);
    }

    public void TargetHit(string s, int p_score)
    {
        scoreString = s;
        score += p_score;
    }
}
