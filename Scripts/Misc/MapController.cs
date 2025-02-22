using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using UnityEditor;
using System.Drawing;

public class MapController : MonoBehaviour
{
    [SerializeField] PlayerController PlayerController;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] GameObject MainCameraObject;
    [SerializeField] GameObject MapCameraObject;
    [SerializeField] Camera MainCamera;
    [SerializeField] Camera MapCamera;
    [SerializeField] List<GameObject> menu = new List<GameObject>();
    [SerializeField] bool MapOpen = false;
    [SerializeField] float inputHorizontal;
    [SerializeField] float inputVertical;
    [SerializeField] float moveSpeed = 20;
    [SerializeField] float size = 200;
    [SerializeField] float wait = 0.01f;
    public float dragSpeed = 10f;

    private Vector2 dragStartPos;
    private Vector2 dragEndPos;
    private bool isDragging = false;
    void Start()
    {
        MainCamera = MainCameraObject.GetComponent<Camera>();
        MapCamera = MapCameraObject.GetComponent<Camera>();

    }

    // Update is called once per frame
    void Update()
    {
        if (MapOpen == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                dragStartPos = MapCamera.ScreenToWorldPoint(Input.mousePosition);
                isDragging = true;
            }

            if (Input.GetMouseButton(0) && isDragging)
            {
                dragEndPos = MapCamera.ScreenToWorldPoint(Input.mousePosition);
            }

            if (Input.GetMouseButtonUp(0) && isDragging)
            {
                Vector2 dragDirection = (dragEndPos - dragStartPos).normalized;
                float dragDistance = Vector2.Distance(dragStartPos, dragEndPos);

                MoveObject(dragDirection * dragDistance);
                isDragging = false;
            }
        }
        if (MapOpen == false)
        {
            MapCamera.enabled = false;
        }


        if (Input.GetKeyUp("m") && MapOpen == false)
        {
            OpenMap();
        }
        else if (Input.GetKeyUp("m") && MapOpen == true)
        {
            CloseMap();
        }
        if (Input.GetKey("-") || Input.GetKey("_"))
        {
            if (size <= 60)
            {

            }
            else
            {
                wait -= Time.unscaledDeltaTime;

                if (wait <= 0)
                {
                    size -= 2;
                    wait = 0.01f;
                }

            }
        }
        if (Input.GetKey("=") || Input.GetKey("+"))
        {

            if (size >= 600)
            {

            }
            else
            {
                wait -= Time.unscaledDeltaTime;

                if (wait <= 0)
                {
                    size += 2;
                    wait = 0.01f;
                }
            }
        }

        MapCamera.orthographicSize = size;
    }
    void OpenMap()
    {
        PlayerController.enabled = false;
        MainCamera.enabled = false;
        MapCamera.enabled = true;
        foreach (GameObject Object in menu)
        {
            Object.SetActive(false);
        }
        MapOpen = true;
        Time.timeScale = 0.00001f;
        Debug.Log("Map open");
    }
    void CloseMap()
    {
        PlayerController.enabled = true;
        MainCamera.enabled = true;
        MapCamera.enabled = false;
        foreach (GameObject Object in menu)
        {
            Object.SetActive(true);
        }
        MapOpen = false;
        Time.timeScale = 1;
        Debug.Log("Map closed");
    }
    private void MoveObject(Vector2 dragVector)
    {
        rb.MovePosition(rb.position + dragVector * moveSpeed * Time.unscaledDeltaTime);
    }
}
