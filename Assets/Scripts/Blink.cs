using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class Blink : MonoBehaviour
{
    private Image uiElement;
    private readonly float duration = 0.8f;
    private readonly float minAlpha = 0.1f;
    private readonly bool loopForever = true;

    private Tween blinkTween;

    private void Awake()
    {
        uiElement = GetComponent<Image>();        
    }

    private void OnEnable()
    {
        StartBlinking();
    }

    public void StartBlinking()
    {
        if (uiElement == null) return;
        blinkTween?.Kill();

        blinkTween = uiElement.DOFade(minAlpha, duration)
            .SetLoops(loopForever ? -1 : 2, LoopType.Yoyo)
            .SetEase(Ease.InOutSine);
    }

    public void StopBlinking()
    {
        blinkTween?.Kill();        
        uiElement.color = new Color(uiElement.color.r, uiElement.color.g, uiElement.color.b, 1f);
    }

    private void OnDisable()
    {
        StopBlinking();
    }
}
