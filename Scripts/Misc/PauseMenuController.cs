using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem.HID;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour
{
    [SerializeField] GameMenu GameMenu;
    [SerializeField] string Scene = "GameOverPc";
    ValueSave ValueSave;
    private void Start()
    {
        ValueSave = GameObject.FindGameObjectWithTag("Value").GetComponent<ValueSave>();
    }
    public void MainMenu()
    {
        GameObject audioManager = GameObject.FindGameObjectWithTag("AudioManager");
        Destroy(audioManager);
        if (ValueSave != null)
        {
            ValueSave.Save();
        }
        SceneManager.LoadScene(Scene);
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