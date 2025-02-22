using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem.HID;
using UnityEngine.SceneManagement;

public class DeathMenuController : MonoBehaviour
{
    public GameObject DeathMenu;
    [SerializeField] GameMenu GameMenu;
    public void MainMenu()
    {
        GameObject audioManager = GameObject.FindGameObjectWithTag("AudioManager");
        Destroy(audioManager);
        SceneManager.LoadScene("MainMenuPc");
        Time.timeScale = 1.0f;

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
