using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public bool destroy = false;
    public string Scene;
    public void playGame(int Difficulty)
    {
        destroy = true;

        PlayerPrefs.SetInt("Difficulty", Difficulty);


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
