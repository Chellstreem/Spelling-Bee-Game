using DG.Tweening;
using UnityEngine;

public interface IScaler
{
    public void ShowWithScale(Transform target, float duration = 1.5f, float startScale = 0f, Ease easeType = Ease.OutBack);
    public void HideWithScale(Transform target, float duration = 1.5f, float endScale = 0f, Ease easeType = Ease.InBack);
}
