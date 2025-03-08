using UnityEngine;
using UnityEngine.UI;
using Zenject;
using System.Collections;

public class HealthBar : MonoBehaviour
{
    private Image lifeBar;
    private IHealth health;

    private Coroutine fillCoroutine;
    private readonly float transitionSpeed = 5f;

    [Inject]
    public void Construct(IHealth health)
    {
        this.health = health;
    }

    private void Start()
    {
        lifeBar = GetComponent<Image>();
        UpdateHealthBar();        
    }

    private void UpdateHealthBar() => lifeBar.fillAmount = health.LifeRatio;

    private void UpdateHealthBarSmoothly(HealthChangeType healthChage)
    {
        if (!gameObject.activeInHierarchy) return;
        float targetFill = health.LifeRatio;
        fillCoroutine = StartCoroutine(SmoothFillTransition(targetFill));
    }

    private IEnumerator SmoothFillTransition(float targetFill)
    {
        float startFill = lifeBar.fillAmount;
        float elapsed = 0f;

        while (elapsed < 1f)
        {
            elapsed += Time.deltaTime * transitionSpeed;
            lifeBar.fillAmount = Mathf.Lerp(startFill, targetFill, elapsed);
            yield return null;
        }

        lifeBar.fillAmount = targetFill;
    }

    private void StopCoroutine()
    {
        if (fillCoroutine != null)
        {
            StopCoroutine(fillCoroutine);

        }
        fillCoroutine = null;
    }

    private void OnEnable() => health.OnHealthChanged += UpdateHealthBarSmoothly;

    private void OnDisable()
    {
        StopCoroutine();
        health.OnHealthChanged -= UpdateHealthBarSmoothly;
    }

    private void OnDestroy() => health.OnHealthChanged -= UpdateHealthBarSmoothly;
}
