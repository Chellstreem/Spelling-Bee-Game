using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Zenject;

public class SceneUIStore : MonoBehaviour, IEventSubscriber<OnVictory>, IEventSubscriber<OnDeath>
{
    private IEventManager eventManager;

    [SerializeField] public GameObject gameOverMenu;
    [SerializeField] public Button playAgainButton;
    [SerializeField] public Button mainMenuButton;    
    [SerializeField] public TextMeshProUGUI currentWordIndex;
    [SerializeField] public TextMeshProUGUI countdown;      

    [Inject]
    public void Construct(IEventManager eventManager)
    {
        this.eventManager = eventManager;
    }
    
    private void Start()
    {
        playAgainButton.onClick.AddListener(PlayAgain);
        mainMenuButton.onClick.AddListener(GoToMainMenu);        

        eventManager.Subscribe<OnVictory>(this);
        eventManager.Subscribe<OnDeath>(this);
    }
    
    public void OnEvent(OnVictory eventData)
    {        
        ShowGameOverMenu(); 
    }

    public void OnEvent(OnDeath eventData)
    {
        ShowGameOverMenu();
    }

    private void PlayAgain() => SceneManager.LoadScene(2);    
    
    private void GoToMainMenu() => SceneManager.LoadScene(1);

    public void UpdateCurrentIndexDisplay(int currentIndex, int totalWords) => currentWordIndex.text = $"{currentIndex} / {totalWords}";    

    private void ShowGameOverMenu() => gameOverMenu.SetActive(true);

    public void ActivateCountdownBar() => countdown.gameObject.SetActive(true);

    public void DeactivateCountdownBar() => countdown.gameObject.SetActive(false);

    public void UpdateCountdown(int count, int fontSize, int goFontSize)
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

        eventManager.Unsubscribe<OnVictory>(this);
        eventManager.Unsubscribe<OnDeath>(this);
    }
}


