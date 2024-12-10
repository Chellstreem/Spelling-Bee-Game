using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private ObjectPool objectPool;
    [SerializeField] private Spawner spawner;
    [SerializeField] private GameplayUI gameplayUI;   
    [SerializeField] private WordController wordController;
    [SerializeField] private PlayerAnimation playerAnimation;
    [SerializeField] private GameStateManager gameStateManager;

    private void Start()
    {
        playerMovement.Initialize();
        objectPool.Initialize();
        spawner.Initialize(objectPool);
        gameplayUI.Initialize();
        wordController.Initialize();               
        playerAnimation.Initialize();
        gameStateManager.Initialize();
    }
}
