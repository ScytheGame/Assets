using System.Collections.Generic;
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

    [Header("Saved Scores")]
    private int TimePlayed;
    private int Level;
    private int KillCount;
    private string playerName;

    void Start()
    {
        // Attach listener to the submit button
        submitNameButton.onClick.AddListener(OnSubmitName);
    }
    public void OnSubmitName()
    {
        // Retrieve or initialize the player list
        List<string> allPlayers = new List<string>(PlayerPrefs.GetString("AllPlayerNames", "").Split(','));
        allPlayers.RemoveAll(string.IsNullOrEmpty);

        // Fetch the player name from the input field
        playerName = playerNameInputField.text.Trim();

        if (string.IsNullOrEmpty(playerName))
        {
            Debug.LogWarning("Player name is empty. Cannot save stats.");
            return;
        }

        // Add the player name if it doesn't exist
        if (!allPlayers.Contains(playerName))
        {
            allPlayers.Add(playerName);
        }

        // Save the updated player list
        PlayerPrefs.SetString("AllPlayerNames", string.Join(",", allPlayers));

        // Save stats for the player
        Save(playerName);

        // Save all PlayerPrefs data
        PlayerPrefs.Save();

        Debug.Log($"Stats saved for {playerName}: TimePlayed = {TimePlayed}, Level = {Level}, KillCount = {KillCount}");
    }

    private void Save(string playerName)
    {
        if (ValueSave != null)
        {
            // Retrieve stats from ValueSave before saving
            TimePlayed = ValueSave.TimePlayed;
            Level = ValueSave.Level;
            KillCount = ValueSave.KillCount;
        }
        else
        {
            Debug.LogWarning("ValueSave is null. Unable to retrieve stats.");
            return;
        }

        // Save the player's stats to PlayerPrefs
        PlayerPrefs.SetInt(playerName + "_TimePlayed", TimePlayed);
        PlayerPrefs.SetInt(playerName + "_Level", Level);
        PlayerPrefs.SetInt(playerName + "_KillCount", KillCount);


        Debug.Log($"Saved stats for {playerName}: TimePlayed = {TimePlayed}, Level = {Level}, KillCount = {KillCount}");
    }

}
