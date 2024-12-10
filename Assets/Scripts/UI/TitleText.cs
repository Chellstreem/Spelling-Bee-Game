using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleText : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] TextMeshProUGUI textObject;
    private float endSize = 210f;
    [SerializeField] float duration = 5f;
    private float initialFontSize;



    void Start()
    {
        initialFontSize = textObject.fontSize;
        StartCoroutine(IncreaseFontSize());
    }

    IEnumerator IncreaseFontSize()
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




