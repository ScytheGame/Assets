using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem.HID;
using UnityEngine.SceneManagement;

public class DeathMenuController : MonoBehaviour
{
    public GameObject DeathMenu;
    public string Scene = "MainMenuPc";
    [SerializeField] GameMenu GameMenu;
    public void MainMenu()
    {
        GameObject audioManager = GameObject.FindGameObjectWithTag("AudioManager");
        Destroy(audioManager);
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(Scene);

    }
    public void Continue()
    {
        GameMenu.Continue();
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
