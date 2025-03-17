using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class Zoom : MonoBehaviour
{
    [SerializeField] GameObject UI;
    [SerializeField] float ZoomLevel = 1;
    void Update()
    {
        ZoomLevel += Input.GetAxis("Mouse ScrollWheel");
        if (ZoomLevel < 0.5)
        {
            ZoomLevel = 0.5f;
        }
        if (ZoomLevel > 3)
        {
            ZoomLevel = 3;
        }
        UI.transform.localScale = new Vector3(ZoomLevel, ZoomLevel, ZoomLevel);
    }
}
