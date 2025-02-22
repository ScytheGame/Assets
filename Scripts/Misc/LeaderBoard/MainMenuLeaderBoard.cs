using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;
using static Cinemachine.DocumentationSortingAttribute;
using TMPro;

public class MainMenuLeaderBoard : MonoBehaviour
{
    [Header("References")]
    [SerializeField] GameObject LeaderBoard;
    [SerializeField] GameObject LeaderBoard1;
    [SerializeField] Transform leaderboardContent;
    [SerializeField] GameObject leaderboardEntryPrefab;

    public string Name;
    public int TimePlayed;
    public int Level;
    public int KillCount;

    void Start()
    {
    }
    public void Show()
    {
        LeaderBoard.SetActive(true);
        LeaderBoard1.SetActive(true);
    }
    public void Close()
    {
        LeaderBoard.SetActive(false);
        LeaderBoard1.SetActive(false);
    }
    public void LoadLeaderboard()
    {
        // Clear existing leaderboard entries
        foreach (Transform child in leaderboardContent)
        {
            Destroy(child.gameObject);
        }

        // Load the player list
        List<string> allPlayers = new List<string>(PlayerPrefs.GetString("AllPlayerNames", "").Split(','));
        allPlayers.RemoveAll(string.IsNullOrEmpty);

        if (allPlayers.Count == 0)
        {
            Debug.LogWarning("No players found in the leaderboard.");
            return;
        }

        // Initialize a list to hold loaded player data
        List<PlayerData> playerDataList = new List<PlayerData>();

        // Load player data for each player name
        foreach (string playerName in allPlayers)
        {
            // Load the player data immediately inside the loop
            int timePlayed = PlayerPrefs.GetInt(playerName + "_TimePlayed", 0);
            int level = PlayerPrefs.GetInt(playerName + "_Level", 0);
            int killCount = PlayerPrefs.GetInt(playerName + "_KillCount", 0);

            playerDataList.Add(new PlayerData
            {
                Name = playerName,
                TimePlayed = timePlayed,
                Level = level,
                KillCount = killCount
            });

            Debug.Log($"Loaded leaderboard data for {playerName}: TimePlayed = {timePlayed}, Level = {level}, KillCount = {killCount}");
        }

        // Sort players by KillCount and Level
        playerDataList.Sort((a, b) =>
        {
            int killComparison = b.KillCount.CompareTo(a.KillCount);
            if (killComparison != 0) return killComparison;

            return b.Level.CompareTo(a.Level); // Compare levels (descending)
        });

        // Populate the leaderboard
        foreach (PlayerData player in playerDataList)
        {
            GameObject leaderboardEntry = Instantiate(leaderboardEntryPrefab, leaderboardContent);

            TMP_Text[] texts = leaderboardEntry.GetComponentsInChildren<TMP_Text>();
            foreach (TMP_Text text in texts)
            {
                if (text.name == "PlayerNameText")
                {
                    text.text = player.Name;
                    Debug.Log($"Set PlayerNameText to: {player.Name}");
                }
                else if (text.name == "TimePlayedText")
                {
                    text.text = "Time Played: " + player.TimePlayed;
                    Debug.Log($"Set TimePlayedText to: {player.TimePlayed}");
                }
                else if (text.name == "LevelText")
                {
                    text.text = "Level: " + player.Level;
                    Debug.Log($"Set LevelText to: {player.Level}");
                }
                else if (text.name == "KillCountText")
                {
                    text.text = "Kills: " + player.KillCount;
                    Debug.Log($"Set KillCountText to: {player.KillCount}");
                }
            }
        }
    }



    private void LoadPlayerData(string playerName)
    {
        // Check if the player data exists
        if (PlayerPrefs.HasKey(playerName + "_TimePlayed"))
        {
            TimePlayed = PlayerPrefs.GetInt(playerName + "_TimePlayed");
            Level = PlayerPrefs.GetInt(playerName + "_Level");
            KillCount = PlayerPrefs.GetInt(playerName + "_KillCount");

            Debug.Log($"Loaded data for {playerName}: TimePlayed = {TimePlayed}, Level = {Level}, KillCount = {KillCount}");
        }
        else
        {
            Debug.LogWarning($"No data found for player {playerName}");
        }
    }

}
public class PlayerData
{
    public string Name;
    public int TimePlayed;
    public int Level;
    public int KillCount;
}
