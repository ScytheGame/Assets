using UnityEngine;
using System.Collections.Generic;
public class GameMenu : MonoBehaviour
{
    [SerializeField] List<GameObject> Menu;
    [SerializeField] List<GameObject> Hud;
    [SerializeField] GameObject settings;

    public bool gamePaused = false;
    float waitTime = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach (GameObject obj in Menu)
        {
            obj.SetActive(false);
        }
        foreach (GameObject obj in Hud)
        {
            obj.SetActive(true);
        }

        Debug.Log("Game paused " + gamePaused);
        settings.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        waitTime -= Time.deltaTime;
        if (Input.GetKeyDown("escape"))
        {
            Debug.Log("Escape key pressed");
            Debug.Log("Game Paseed " + gamePaused);
        }
        if (Input.GetKeyDown("escape") && gamePaused == false && waitTime <= 0f)
        {
            Time.timeScale = 0f;
            gamePaused = true;
            Debug.Log("Should be paused");
            waitTime = 0.5f;

            foreach (GameObject obj in Menu)
            {
                obj.SetActive(true);
            }
            foreach (GameObject obj in Hud)
            {
                obj.SetActive(false);
            }
        }
        else if (Input.GetKeyDown("escape") && gamePaused == true && waitTime <=0f)
        {
            Time.timeScale = 1f;
            gamePaused = false;
            waitTime = 0.5f;

            foreach (GameObject obj in Menu)
            {
                obj.SetActive(false);
            }
            foreach (GameObject obj in Hud)
            {
                obj.SetActive(true);
            }
        }

    }
    public void Continue()
    {
        Time.timeScale = 1f;
        gamePaused = false;

        foreach (GameObject obj in Menu)
        {
            obj.SetActive(false);
        }
        foreach (GameObject obj in Hud)
        {
            obj.SetActive(true);
        }
    }
    public void Pause()
    {
        Time.timeScale = 0f;
        gamePaused = true;

        foreach (GameObject obj in Menu)
        {
            obj.SetActive(true);
        }
        foreach (GameObject obj in Hud)
        {
            obj.SetActive(false);
        }
    }

}
