using UnityEngine;

public class CursorController : MonoBehaviour
{
    public Canvas canvas;
    public RectTransform rectTransform;
    public Vector2 targetPosition;

    void Start()
    {
        Cursor.visible = false;
    }
    void Update()
    {
        Vector2 mousePosition = Input.mousePosition;

        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.GetComponent<RectTransform>(), mousePosition, canvas.worldCamera, out Vector2 targetPosition);

        rectTransform.anchoredPosition = Vector2.Lerp(rectTransform.anchoredPosition, targetPosition, Time.unscaledDeltaTime * 60f);
    }
}
