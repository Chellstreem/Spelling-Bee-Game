﻿using UnityEngine;

[CreateAssetMenu(fileName = "GameConfig", menuName = "Scriptable Objects/GameConfig")]
public class GameConfig : ScriptableObject
{
    [Header("General Config")]
    [SerializeField] private GameObject coroutineRunnerObj;
    [SerializeField] private float speed = 20f;

    public GameObject CoroutineRunnerObj => coroutineRunnerObj;
    public float Speed => speed;

    //

    [Header("Player Movement Config")]
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private float moveDistance = 5f;
    [SerializeField] private float moveSpeed = 25f;
    [SerializeField] private float positionThreshold = 0.001f;
    [SerializeField] private Vector3 playerPosition;

    public GameObject PlayerPrefab => playerPrefab;
    public float MoveDistance => moveDistance;
    public float MoveSpeed => moveSpeed;
    public float PositionThreshold => positionThreshold;
    public Vector3 PlayerPosition => playerPosition;

    //

    [Header("Movable Object Config")]
    [SerializeField] private GameObject backgroundPrefab;
    [SerializeField] private Vector3 backgroundPosition;
    [SerializeField] private float thresholdZ;

    public GameObject BackgroundPrefab => backgroundPrefab;
    public Vector3 BackgroundPosition => backgroundPosition;
    public float ThresholdZ => thresholdZ;

    //

    [Header("Spawn Config")]
    [SerializeField] private Vector3 spawnPosition;
    [SerializeField] private float decorativeSpawnFrequency = 1.5f;
    [SerializeField] private float interactableSpawnFrequency = 0.5f;    

    public Vector3 SpawnPosition => spawnPosition;
    public float DecorativeSpawnFrequency => decorativeSpawnFrequency;
    public float InteractableSpawnFrequency => interactableSpawnFrequency;

    //

    [Header("Word Controller Config")]
    [SerializeField] private int maskedLetterThreshold = 5;
    [SerializeField] private int maskedLetterMinNum = 1;
    [SerializeField] private int maskedLetterMaxNum = 2;

    public int MaskedLetterThreshold => maskedLetterThreshold;
    public int MaskedLetterMinNum => maskedLetterMinNum;
    public int MaskedLetterMaxNum => maskedLetterMaxNum;

    //

    [Header("Random Letter Config")]
    [SerializeField] private int extraLettersCount = 7;
    [SerializeField] private string availableLetters = "abcdefghijklmnopqrstuvwxyz";

    public int ExtraLettersCount => extraLettersCount;   
    public string AvailableLetters => availableLetters;

    // 

    [Header("Countdown Config")]
    [SerializeField] private int count = 3;
    [SerializeField] private int fontSize = 320;
    [SerializeField] private int fontSizeDecrement = 45; // Насколько уменьшается размер шрифта при каждом тике    
    [SerializeField] private int finalFontSize = 350; // Размер шрифта для надписи Go!

    public int Count => count;
    public int FontSize => fontSize;
    public int FontSizeDecrement => fontSizeDecrement;
    public int FinalFontSize => finalFontSize;

    //

    [Header("Missle Config")]
    [SerializeField] private float missileSpeed = 30f;
    [SerializeField] private float missileSpawnFrequency = 0.5f;

    public float MissileSpeed => missileSpeed;
    public float MissileSpawnFrequency => missileSpawnFrequency;
}
