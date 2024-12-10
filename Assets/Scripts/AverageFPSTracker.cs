using UnityEngine;

public class AverageFPSCounter : MonoBehaviour
{
    private float totalTime = 0f;  // Общее время работы игры
    private int totalFrames = 0;   // Общее количество кадров

    private void Update()
    {
        totalTime += Time.unscaledDeltaTime;  // Учитываем время между кадрами
        totalFrames++;  // Считаем кадры
    }

    private void OnDisable()
    {
        if (Application.isPlaying) // Убедимся, что остановка происходит в Play Mode
        {
            float averageFPS = totalFrames / totalTime;  // Средний FPS
            Debug.Log($"Средний FPS за сессию: {averageFPS:F2}");  // Вывод в консоль
        }
    }
}
