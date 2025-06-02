using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public bool destroy = false;
    public string Scene = "BaseFightPc";
    public void playGame()
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
