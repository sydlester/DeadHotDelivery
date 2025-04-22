using UnityEngine;
using TMPro;

[RequireComponent(typeof(RectTransform))]
//helper to resize the background of the quest text
public class ResizeBackgroundWidthOnly : MonoBehaviour
{
    public TextMeshProUGUI targetText;   
    public float horizontalPadding = 20f;

    private RectTransform rectTransform;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        Resize();
    }

    void Update()
    {
        Resize(); 
    }

    void Resize()
    {
        if (targetText == null) return;

        float width = 2 * targetText.preferredWidth + horizontalPadding;
        float height = rectTransform.sizeDelta.y; 

        rectTransform.sizeDelta = new Vector2(width, height);
    }
}

