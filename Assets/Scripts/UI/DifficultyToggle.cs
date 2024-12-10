using UnityEngine;
using UnityEngine.UI;


public class DifficultyToggle : MonoBehaviour
{
    [SerializeField] RectTransform handleRectTransform;
    public Toggle toggle;
    private Vector2 handlePosition;
    
    void Start()
    {
        toggle = GetComponent<Toggle>();
        handlePosition = handleRectTransform.anchoredPosition;
        toggle.onValueChanged.AddListener(MoveHandle);
        if (toggle.isOn)
            MoveHandle(true);
    }

    private void MoveHandle(bool isOn)
    {
        handleRectTransform.anchoredPosition = isOn ? handlePosition * -1 : handlePosition;
    }
}
