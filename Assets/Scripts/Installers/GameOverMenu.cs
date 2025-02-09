using UnityEngine.UI;
using UnityEngine;
using Zenject;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    [SerializeField] private Button playAgainButton;
    [SerializeField] public Button mainMenuButton;
    private IEventManager eventManager;

    [Inject]
    public void Construct(IEventManager eventManager)
    {
        this.eventManager = eventManager;
    }

    private void OnEnable()
    {
        playAgainButton.onClick.AddListener(PlayAgain);
        mainMenuButton.onClick.AddListener(GoToMainMenu);
    }

    private void PlayAgain() => SceneManager.LoadScene(2);

    private void GoToMainMenu() => SceneManager.LoadScene(1);

    private void OnDestroy()
    {
        playAgainButton.onClick.RemoveListener(PlayAgain);
        mainMenuButton.onClick.RemoveListener(GoToMainMenu);       
    }
}
