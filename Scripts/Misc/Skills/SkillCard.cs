using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SkillCard : MonoBehaviour
{
    [Header("References")]
    public TextMeshProUGUI skillNameText;
    public TextMeshProUGUI skillDescriptionText;
    public TextMeshProUGUI skillDebuffDescriptionText;
    public TextMeshProUGUI BuffText;
    public TextMeshProUGUI DebuffText;
    public GameObject BuffArrow;
    public GameObject DebuffArrow;
    public Button skillButton;

    private SkillData skillData;
    private SkillsController SkillsController;
    PlayerController Player;
    public void Initialize(SkillData data, SkillsController manager)
    {
        skillData = data;
        SkillsController = manager; 
        GameObject playerobject = GameObject.FindGameObjectWithTag("Player");
        Player = playerobject.GetComponent<PlayerController>();

        skillNameText.text = skillData.skillName;
        skillDescriptionText.text = skillData.skillDescription;
        skillButton.onClick.AddListener(OnSkillSelected);
        BuffText.text = skillData.skillBuff1;
    }
    private void OnSkillSelected()
    {
        SkillsController.ApplySkill(skillData);
        SkillsController.CloseSkillPanel();
        Player.SkillsAfterLevelUp();
    }
}
