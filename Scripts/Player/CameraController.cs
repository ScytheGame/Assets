using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    public Camera MainCamera;
    public Transform player;
    public Vector3 offset;
    public int size = 20;
    public float wait = 0.1f;
    void LateUpdate()
    {
        transform.position = player.position + offset;
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }
    void Update()
    {
        if (Input.GetKey("-") || Input.GetKey("_"))
        {
            if (size <= 6)
            {

            }
            else
            {
                wait -= Time.unscaledDeltaTime;

                if (wait <= 0)
                {
                    size -= 1;
                    wait = 0.01f;
                }
                
            }
        }
        if (Input.GetKey("=") || Input.GetKey("+"))
        {

            if (size >= 60)
            {

            }
            else
            {
                wait -= Time.unscaledDeltaTime;

                if (wait <= 0)
                {
                    size += 1;
                    wait = 0.01f;
                }
            }
        }

        MainCamera.orthographicSize = size;
    }
}
