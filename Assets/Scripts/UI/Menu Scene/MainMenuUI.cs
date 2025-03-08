using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using GameplayData;

public class MainMenuUI : MonoBehaviour
{
    [Header("Кнопки")]
    [SerializeField] private Button addNewButton;
    [SerializeField] private Button deleteButton;
    [SerializeField] private Button startButton;
    [SerializeField] private Button exitButton;    

    [Header("Пользовательский ввод")]
    [SerializeField] private TMP_InputField[] inputFields;
    [SerializeField] private GameObject[] fields;
    [SerializeField] private DifficultyToggle difficultyToggle;
    
    private List<string> savedWords;
    private int activeFieldIndex = 0;

    private const int normalSpeed = 20;
    private const int fastSpeed = 40;

    private void Start()
    {
        for (int i = 1; i < fields.Length; i++)
        {
            fields[i].SetActive(false);
        }

        savedWords = new List<string>();        

        AddListenersForButtons();
        UpdateButtonStates();
    }
    private void SaveAndPlay()
    {
        SaveWords();
        if (savedWords.Count == 0)
        {
            Debug.LogWarning("Необходимо ввести хотя бы одно слово!");
            return;
        }

        GameplayData.GameplayData.SavedWords = savedWords;
        GameplayData.GameplayData.Speed = (difficultyToggle.toggle.isOn ? fastSpeed : normalSpeed);

        SceneManager.LoadScene(2);
    }

    public void ActivateNextField()
    {
        if (activeFieldIndex < fields.Length - 1)
        {
            activeFieldIndex++;
            fields[activeFieldIndex].SetActive(true);
            UpdateButtonStates();
        }
    }

    private void DeactivateLastField()
    {
        if (activeFieldIndex > 0)
        {
            fields[activeFieldIndex].SetActive(false);
            activeFieldIndex--;
            UpdateButtonStates();
        }
    }    

    private void SaveWords()
    {
        savedWords.Clear();

        foreach (TMP_InputField inputField in inputFields)
        {
            if (inputField.gameObject.activeSelf)
            {
                string cleanedInput = inputField.text.Trim();

                if (!string.IsNullOrEmpty(cleanedInput))
                {
                    savedWords.Add(cleanedInput);
                }
            }
        }
    }

    private void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
Application.Quit();
#endif
    }

    private void UpdateButtonStates()
    {
        addNewButton.interactable = activeFieldIndex < fields.Length - 1;
        deleteButton.interactable = activeFieldIndex > 0;
    }

    private void AddListenersForButtons()
    {
        addNewButton.onClick.AddListener(ActivateNextField);
        deleteButton.onClick.AddListener(DeactivateLastField);
        startButton.onClick.AddListener(SaveAndPlay);
        exitButton.onClick.AddListener(ExitGame);
    }
}

