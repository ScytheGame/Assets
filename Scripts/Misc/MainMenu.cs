using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public bool destroy = false;
    public void playGame()
    {
        destroy = true;
        SceneManager.LoadScene("BaseFightPc");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void DeleteGameData()
    {
        PlayerPrefs.DeleteAll();
    }
}
