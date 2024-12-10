using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneObjectManager : MonoBehaviour
{
    [SerializeField] private GameObject victoryObjects;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject lossObjects;
    [SerializeField] private GameObject muskratSign;

    private const float GoDownDuration = 0.8f;
    private readonly Vector3 VictoryPlayerPosition = new Vector3(-1.33f, 0, -42.74f);

    private void Start()
    {
        EventBus.OnVictory += OnVictory;
        EventBus.OnLoss += OnLoss;
        MovingState.OnMovingStarted += OnMovingStarted;        
    }

    private void OnVictory()
    {
        victoryObjects.SetActive(true);
        StartCoroutine(MoveToPosition(player, VictoryPlayerPosition));
    }
    
    private void OnLoss() => lossObjects.SetActive(true);
    private void OnMovingStarted() => muskratSign.SetActive(false);

    private IEnumerator MoveToPosition(GameObject obj, Vector3 targetPosition)
    {
        float elapsedTime = 0f;        
        Vector3 startPosition = player.transform.position;

        while (elapsedTime < GoDownDuration)
        {            
            player.transform.position = Vector3.Lerp(startPosition, targetPosition, elapsedTime / GoDownDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        player.transform.position = targetPosition; 
    }    

    private void OnDestroy()
    {
        EventBus.OnVictory -= OnVictory;
        EventBus.OnLoss -= OnLoss;
        MovingState.OnMovingStarted -= OnMovingStarted;
    }
}
