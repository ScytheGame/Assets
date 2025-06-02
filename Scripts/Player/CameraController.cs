using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    public Camera MainCamera;
    public Transform player;
    public Vector3 offset;
    public float size = 20;
    public float Speed = 5;
    void LateUpdate()
    {
        transform.position = player.position + offset;
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }
    void Update()
    {
        size += Input.GetAxis("Mouse ScrollWheel") * Speed;

        if (size > 60)
        {
            size = 60;
        }
        else if (size < 6)
        {
            size = 6;
        }


        MainCamera.orthographicSize = size;
    }
}
