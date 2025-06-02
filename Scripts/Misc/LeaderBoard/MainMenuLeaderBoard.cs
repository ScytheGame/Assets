using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using System.IO;

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

    private string leaderboardFilePath;

    void Start()
    {
        leaderboardFilePath = Path.Combine(Application.persistentDataPath, "leaderboard.json");
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

        // Load leaderboard data from JSON
        LeaderboardData leaderboard = LoadLeaderboardData();

        if (leaderboard.players == null || leaderboard.players.Count == 0)
        {
            Debug.LogWarning("No players found in the leaderboard.");
            return;
        }

        // Sort players by KillCount and Level
        var sortedPlayers = leaderboard.players
            .OrderByDescending(p => p.KillCount)
            .ThenByDescending(p => p.Level)
            .ToList();

        // Populate the leaderboard
        foreach (PlayerStats player in sortedPlayers)
        {
            GameObject leaderboardEntry = Instantiate(leaderboardEntryPrefab, leaderboardContent);

            TMP_Text[] texts = leaderboardEntry.GetComponentsInChildren<TMP_Text>();
            foreach (TMP_Text text in texts)
            {
                if (text.name == "PlayerNameText")
                {
                    text.text = player.PlayerName;
                    Debug.Log($"Set PlayerNameText to: {player.PlayerName}");
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

    private LeaderboardData LoadLeaderboardData()
    {
        if (File.Exists(leaderboardFilePath))
        {
            string json = File.ReadAllText(leaderboardFilePath);
            return JsonUtility.FromJson<LeaderboardData>(json) ?? new LeaderboardData();
        }
        return new LeaderboardData();
    }
}
