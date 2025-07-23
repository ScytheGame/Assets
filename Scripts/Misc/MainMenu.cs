using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public bool destroy = false;
    public void playGame(string Scene)
    {
        destroy = true;
        SceneManager.LoadScene(Scene);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void DeleteGameData()
    {
        PlayerPrefs.DeleteAll();
        Directory.Delete(Application.persistentDataPath, true);
    }
}
