using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class ScreensManager : MonoBehaviour
{
    [SerializeField] private TurretManager turrets;
    [SerializeField] private GameManager gameManager;

    [SerializeField] private List<string> welcomeDialogue;
    [SerializeField] private List<TextMeshProUGUI> welcomeTexts;
    [SerializeField] private List<TextMeshProUGUI> scoreTexts;
    [SerializeField] private List<TextMeshProUGUI> gameOverTexts;
    [SerializeField] private List<Canvas> gameOverScreens;
    [SerializeField] private List<Canvas> ongoingGameScreens;
    [SerializeField] private List<GameObject> continueButtons;

    private string currText;
    private int currTextIndex;
    private int lastTextIndex;
    private bool lastMessageDisplayed;

    // Start is called before the first frame update
    void Start()
    {
        currTextIndex = 0;
        lastTextIndex = welcomeDialogue.Count - 1;
        DisplayNextMessage();
        lastMessageDisplayed = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisplayNextMessage()
    {
        if (!lastMessageDisplayed)
        {
            if (currTextIndex <= lastTextIndex)
            {
                currText = welcomeDialogue.ElementAt(currTextIndex);
                foreach (TextMeshProUGUI screen in welcomeTexts) { screen.text = currText; }
                currTextIndex++;
            }
            else
            {
                gameManager.StartGame();
                lastMessageDisplayed = true;
            }
        }
    }

    public void UpdateAllScreenTexts(string p_text)
    {
        foreach (TextMeshProUGUI screen in welcomeTexts)
        {
            screen.text = p_text;
        }
    }

    public void UpdateAllScoreScreenTexts(string p_text)
    {
        foreach (TextMeshProUGUI screen in scoreTexts)
        {
            screen.text = p_text;
        }
    }

    public void StartGame()
    {
        foreach (TextMeshProUGUI screen in scoreTexts) { screen.gameObject.SetActive(true); }
        foreach (GameObject button in continueButtons) { button.SetActive(false); }
    }

    public void SetGameOver(int score)
    {
        foreach (Canvas screen in ongoingGameScreens) { screen.gameObject.SetActive(false); }
        foreach (Canvas screen in gameOverScreens) { screen.gameObject.SetActive(true); }
        foreach (TextMeshProUGUI screen in gameOverTexts) { screen.text += "\nScore: " + score; }
    }
}
