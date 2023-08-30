using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class TextManager : MonoBehaviour
{
    [SerializeField] private Canvas textCanvas;
    [SerializeField] private TextMeshProUGUI displayedText;
    [SerializeField] private List<string> texts;
    [SerializeField] private bool loop;
    private int currText;
    private int lastTextIndex;

    private bool allMessagesDisplayed;

    // Start is called before the first frame update
    void Start()
    {
        currText = 0;
        loop = false;
        lastTextIndex = texts.Count - 1;
        DisplayNextMessage();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    

    public void DisplayNextMessage()
    {
        if (!allMessagesDisplayed)
        {
            if (currText <= lastTextIndex)
            {
                displayedText.text = texts.ElementAt(currText);
                currText++;
            }
            else
            {
                if (loop)
                {
                    currText = 0;
                }
                else
                {
                    allMessagesDisplayed = true;
                    textCanvas.gameObject.SetActive(false);
                }
            }
        }
    }
}
