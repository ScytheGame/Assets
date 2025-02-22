using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class LeaderBoardController : MonoBehaviour
{
    [Space(10)]
    [Header("References")]
    [SerializeField] GameObject LeaderBoard;
    [SerializeField] GameObject LeaderBoardHud;
    [SerializeField] GameObject DeathScreen;
    [SerializeField] InputField playerNameInputField;
    [SerializeField] Button submitNameButton;
    [SerializeField] GameObject leaderboardEntryPrefab;
    [SerializeField] Transform leaderboardContent;
    [SerializeField] ValueSave ValueSave;
    [SerializeField] MainMenu MainMenu;
    [SerializeField] GameObject LeaderBoard1;

    [Space(10)]
    [Header("Saved Scores")]
    [SerializeField] int TimePlayed;
    [SerializeField] int Level;
    [SerializeField] int KillCount;

    private string playerName;

    void Start()
    {
        GameObject ValueObject = GameObject.FindGameObjectWithTag("Value");
        if (ValueObject != null)
        {
            ValueSave = ValueObject.GetComponent<ValueSave>();

            if (ValueSave == null)
            {
                Debug.LogWarning("ValueSave component not found on ValueObject.");
            }
        }
        else
        {
            Debug.LogWarning("GameObject with tag 'Value' not found.");
            ValueSave = null;
        }
        GameObject DestroyObject = GameObject.FindGameObjectWithTag("Destroy");
        if (DestroyObject != null)
        {
            MainMenu = DestroyObject.GetComponent<MainMenu>();

            if (MainMenu == null)
            {
                Debug.LogWarning("Destroy component not found on DestroyObject.");
            }
        }
        else
        {
            Debug.LogWarning("GameObject with tag 'Destroy' not found.");
            MainMenu = null;
        }

        if (MainMenu.destroy == true)
        {
            Destroy();
        }

        DeathScreen.SetActive(false);
        submitNameButton.onClick.AddListener(OnSubmitName);
        Load();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            TriggerDeath();
        }
    }

    public void TriggerDeath()
    {
        DeathScreen.SetActive(true);
    }

    public void OnSubmitName()
    {
        Level = ValueSave.Level;
        KillCount = ValueSave.KillCount;
        TimePlayed = ValueSave.TimePlayed;

        playerName = playerNameInputField.text;

        if (string.IsNullOrEmpty(playerName))
        {
            playerName = "Player" + Random.Range(1000, 9999);
        }

        Save(playerName);

        DeathScreen.SetActive(false); 
        Load();
    }

    void Save(string playerName)
    {
        PlayerPrefs.SetInt(playerName + "_TimePlayed", TimePlayed);
        PlayerPrefs.SetInt(playerName + "_Level", Level);
        PlayerPrefs.SetInt(playerName + "_KillCount", KillCount);
        PlayerPrefs.Save();
    }

    void Load()
    {
        foreach (Transform child in leaderboardContent)
        {
            Destroy(child.gameObject);
        }

        string[] allPlayers = { "Player1", "Player2", "Player3" };

        foreach (string playerName in allPlayers)
        {
            int timePlayed = PlayerPrefs.GetInt(playerName + "_TimePlayed", 0);
            int level = PlayerPrefs.GetInt(playerName + "_Level", 0);
            int killCount = PlayerPrefs.GetInt(playerName + "_KillCount", 0);

            GameObject leaderboardEntry = Instantiate(leaderboardEntryPrefab, leaderboardContent);

            Text[] texts = leaderboardEntry.GetComponentsInChildren<Text>();
            foreach (Text text in texts)
            {
                if (text.name == "PlayerNameText")
                    text.text = playerName;
                else if (text.name == "TimePlayedText")
                    text.text = "Time Played: " + timePlayed.ToString();
                else if (text.name == "LevelText")
                    text.text = "Level: " + level.ToString();
                else if (text.name == "KillCountText")
                    text.text = "Kills: " + killCount.ToString();
            }
        }
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
