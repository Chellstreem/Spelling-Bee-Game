using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroText : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textObject;    
    [SerializeField] float duration = 5f;
    private float initialFontSize;
    private float endSize = 210f;

    void Start()
    {
        initialFontSize = textObject.fontSize;
        StartCoroutine(IntroCoroutine());
    }

    IEnumerator IntroCoroutine()
    {
        float timeElapsed = 0f;
        while (timeElapsed < duration)
        {
            textObject.fontSize = Mathf.Lerp(initialFontSize, endSize, timeElapsed / duration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        textObject.fontSize = endSize;
        SceneManager.LoadScene(1);
    }
}




