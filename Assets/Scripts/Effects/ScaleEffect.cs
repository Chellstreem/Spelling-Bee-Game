using DG.Tweening;
using UnityEngine;

public class ScaleEffect : IScaler
{
    public void ShowWithScale(Transform target, float duration = 3f, float startScale = 0f, Ease easeType = Ease.OutBack)
    {
        if (target == null) return;

        Vector3 originalScale = target.localScale;
        target.localScale = Vector3.one * startScale;
        target.gameObject.SetActive(true);
        target.DOScale(originalScale, duration).SetEase(easeType);
    }

    public void HideWithScale(Transform target, float duration = 1f, float endScale = 0f, Ease easeType = Ease.InBack)
    {
        if (target == null) return;

        target.DOScale(Vector3.one * endScale, duration)
            .SetEase(easeType)
            .OnComplete(() => target.gameObject.SetActive(false)); 
    }
}
