using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    Canvas canvas;

    void Start()
    {
        canvas = new UnityEngine.GameObject("Canvas").AddComponent<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        canvas.gameObject.AddComponent<CanvasScaler>();
        canvas.gameObject.AddComponent<GraphicRaycaster>();

        CreateButton();
    }

    void CreateButton()
    {
        UnityEngine.GameObject buttonObj = new UnityEngine.GameObject("Button");
        buttonObj.transform.SetParent(canvas.transform);

        Button button = buttonObj.AddComponent<Button>();

        // �K�[Image Component�ó]�w�C��
        Image image = buttonObj.AddComponent<Image>();
        image.color = Color.red;

        // �K�[RectTransform�ó]�w�ؤo�M��m
        RectTransform rectTransform = button.GetComponent<RectTransform>();
        rectTransform.sizeDelta = new Vector2(100, 50);
        rectTransform.anchoredPosition = new Vector2(0, 0);

        // �K�[Button�I���ƥ�
        button.onClick.AddListener(() => { Debug.Log("Button clicked!"); });
    }
}
