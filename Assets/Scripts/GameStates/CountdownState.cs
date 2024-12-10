using System;
using System.Collections;
using UnityEngine;


public class CountdownState : IGameState
{
    private GameStateManager gameStateManager;

    public static event Action OnCountdownStarted;
    public static event Action<int, int, int> OnCountdownTick;
    public static event Action OnCountdownEnded;

    private const int Count = 3;  
    private const int GoFontSize = 350; // Размер шрифта для надписи Go!
    private const int FontSizeDecrement = 45; // Насколько уменьшается размер шрифта при каждом тике
    private int fontSize = 320;    

    public CountdownState(GameStateManager gameStateManager)  => this.gameStateManager = gameStateManager;   
    
    public void Enter()
    {
        CoroutineRunner.Instance.StartCustomCoroutine(Countdown(Count, fontSize, GoFontSize));         
    }

    private IEnumerator Countdown(int count, int fontSize, int goFontSize)
    {
        OnCountdownStarted?.Invoke();
        while (count >= 0)
        {            
            OnCountdownTick?.Invoke(count, fontSize, goFontSize);
            yield return new WaitForSeconds(1f);               
            count--;
            fontSize -= FontSizeDecrement;
        }
        
        OnCountdownEnded?.Invoke();        
        ChangeState(GameStateManager.GameState.Moving);

    }

    private void ChangeState(GameStateManager.GameState gameState) => gameStateManager.SetState(gameState);    

    public void Exit() { }
}
