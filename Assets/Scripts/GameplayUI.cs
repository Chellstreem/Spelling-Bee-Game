using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameplayUI : MonoBehaviour, IInitializable
{
    [SerializeField] private Button playAgainButton;
    [SerializeField] private Button mainMenuButton;

    [SerializeField] private TextMeshProUGUI currentWord;
    [SerializeField] private TextMeshProUGUI currentWordIndex;
    [SerializeField] private TextMeshProUGUI countdown;        
    [SerializeField] private GameObject gameOverMenu;

    private const string victoryMessage = "YOU DID IT!"; 
    
    
    public void Initialize()
    {
        playAgainButton.onClick.AddListener(PlayAgain);
        mainMenuButton.onClick.AddListener(GoToMainMenu);

        WordController.OnIndexChanged += UpdateCurrentIndexDisplay;
        WordController.OnWordChanged += UpdateCurrentWordDisplay;

        CountdownState.OnCountdownStarted += ActivateCountdownBar;
        CountdownState.OnCountdownEnded += DeactivateCountdownBar;
        CountdownState.OnCountdownTick += UpdateCountdown;

        EventBus.OnVictory += ShowVictoryMessage;
        EventBus.OnVictory += ShowGameOverMenu;
        EventBus.OnLoss += ShowGameOverMenu;

    }    

    private void PlayAgain() => SceneManager.LoadScene(2);    
    
    private void GoToMainMenu() => SceneManager.LoadScene(1);

    private void UpdateCurrentIndexDisplay(int currentIndex, int totalWords) => currentWordIndex.text = $"{currentIndex} / {totalWords}";

    private void UpdateCurrentWordDisplay(string maskedWord) => currentWord.text = maskedWord.ToUpper();

    private void ShowVictoryMessage() => currentWord.text = victoryMessage;

    private void ShowGameOverMenu() => gameOverMenu.SetActive(true);

    private void ActivateCountdownBar() => countdown.gameObject.SetActive(true);
    private void DeactivateCountdownBar() => countdown.gameObject.SetActive(false);

    private void UpdateCountdown(int count, int fontSize, int goFontSize)
    {        
        if (count == 0)
        {
            countdown.fontSize = goFontSize;
            countdown.text = "GO!";
        }
        else
        {
            countdown.fontSize = fontSize;
            countdown.text = count.ToString();
        }
    }
    

    private void OnDestroy()
    {
        playAgainButton.onClick.RemoveListener(PlayAgain);
        mainMenuButton.onClick.RemoveListener(GoToMainMenu);

        WordController.OnIndexChanged -= UpdateCurrentIndexDisplay;
        WordController.OnWordChanged -= UpdateCurrentWordDisplay;

        CountdownState.OnCountdownStarted -= ActivateCountdownBar;
        CountdownState.OnCountdownEnded -= DeactivateCountdownBar;
        CountdownState.OnCountdownTick -= UpdateCountdown;

        EventBus.OnVictory -= ShowVictoryMessage;
        EventBus.OnVictory -= ShowGameOverMenu;
        EventBus.OnLoss -= ShowGameOverMenu;
    }
}


