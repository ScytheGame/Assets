using UnityEngine;

public class DevLogSettings : MonoBehaviour
{
    [SerializeField] GameObject DevLog;
    [SerializeField] GameObject DevLogButton;
    [SerializeField] GameObject OpenDevLog;
    [SerializeField] GameObject OpenLeaderBoard;
    [SerializeField] GameObject OpenSkillTree;
    [SerializeField] int DevLogSave;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Load();
        if (DevLogSave == 2)
        {
            DevLog.SetActive(false);
            DevLogButton.SetActive(false);
            OpenDevLog.SetActive(true);
            OpenLeaderBoard.SetActive(true);
            OpenSkillTree.SetActive(true);
        }
        else
        {
            DevLog.SetActive(true);
            DevLogButton.SetActive(true);
            OpenDevLog.SetActive(false);
            OpenLeaderBoard.SetActive(false);
            OpenSkillTree.SetActive(false);
        }
    }
    public void Close ()
    {
        DevLog.SetActive (false);
        DevLogButton.SetActive(false);
        OpenDevLog.SetActive(true);
        OpenLeaderBoard.SetActive(true);
        OpenSkillTree.SetActive(true);
        DevLogSave = 2;
        Save();
    }
    public void Open()
    {
        DevLog.SetActive(true);
        DevLogButton.SetActive(true);
        OpenDevLog.SetActive(false);
        OpenLeaderBoard.SetActive(false);
        OpenSkillTree.SetActive(true);
        DevLogSave = 0;
        Save();
    }

    void Save()
    {
        PlayerPrefs.SetInt("DevLog", DevLogSave);
    }
    void Load()
    {
       DevLogSave = PlayerPrefs.GetInt("DevLog", 0);
    }
}
