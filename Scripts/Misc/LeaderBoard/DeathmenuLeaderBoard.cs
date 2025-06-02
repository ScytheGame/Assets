using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DeathMenuLeaderBoard : MonoBehaviour
{
    [Header("References")]
    [SerializeField] GameObject DeathScreen;
    [SerializeField] TMP_InputField playerNameInputField;
    [SerializeField] Button submitNameButton;
    [SerializeField] ValueLoad ValueSave;

    private string leaderboardFilePath;

    void Start()
    {
        leaderboardFilePath = Path.Combine(Application.persistentDataPath, "leaderboard.json");
        submitNameButton.onClick.AddListener(OnSubmitName);
    }

    public void OnSubmitName()
    {
        string playerName = playerNameInputField.text.Trim();
        if (string.IsNullOrEmpty(playerName)) return;

        LeaderboardData leaderboard = LoadLeaderboard();

        // Check if player already exists
        PlayerStats existing = leaderboard.players.Find(p => p.PlayerName == playerName);
        if (existing == null)
        {
            existing = new PlayerStats { PlayerName = playerName };
            leaderboard.players.Add(existing);
        }

        // Update stats from ValueSave
        if (ValueSave != null)
        {
            existing.TimePlayed = ValueSave.TimePlayed;
            existing.Level = ValueSave.Level;
            existing.KillCount = ValueSave.KillCount;
        }
        else
        {
            return;
        }

        SaveLeaderboard(leaderboard);
        Debug.Log($"Saved stats for {playerName}: TimePlayed = {existing.TimePlayed}, Level = {existing.Level}, KillCount = {existing.KillCount}");
    }

    private LeaderboardData LoadLeaderboard()
    {
        if (File.Exists(leaderboardFilePath))
        {
            string json = File.ReadAllText(leaderboardFilePath);
            return JsonUtility.FromJson<LeaderboardData>(json) ?? new LeaderboardData();
        }
        return new LeaderboardData();
    }

    private void SaveLeaderboard(LeaderboardData leaderboard)
    {
        string json = JsonUtility.ToJson(leaderboard, true);
        File.WriteAllText(leaderboardFilePath, json);
    }
}
