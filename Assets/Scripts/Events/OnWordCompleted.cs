using UnityEngine;

public class OnWordCompleted : IEvent
{
    public GameplayActionType GameplayAction {  get; }

    public OnWordCompleted()
    {
        // Случайно определяем, что случмтся после заполнения одного слова
        GameplayAction = Random.value > 0.5f ? GameplayActionType.CameraShake : GameplayActionType.Missiles; 
    }
}
