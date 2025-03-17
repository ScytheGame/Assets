using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkillPopup : MonoBehaviour
{

    [SerializeField] GameObject[] Popup;
    [SerializeField] GameObject Skill;

    [SerializeField] RectTransform SkillTransform;
    [SerializeField] Vector2 SkillPosition;
    [SerializeField] Vector2 Offset = new Vector2(60, 60);

    [SerializeField] TextMeshProUGUI SkillNameText;
    [SerializeField] TextMeshProUGUI skillDescriptionText;
    [SerializeField] TextMeshProUGUI CelestialCostText;
    [SerializeField] TextMeshProUGUI SolarCostText;
    [SerializeField] TextMeshProUGUI IsOwnedText;
    [SerializeField] GameObject Line;

    private void Update()
    {
        if (Skill != null)
        {
            SkillTransform = Skill.GetComponent<RectTransform>();
            SkillPosition = SkillTransform.position;

            transform.position = SkillPosition + Offset;
        }
    }
    public void Show(GameObject Skill, string SkillName, string SkillDescription, string CelestialCost, string SolarCost, string UpgradeLevel, bool IsOwned, bool IsLocked, bool ShowLine)
    {
        if (!IsLocked)
        {
            this.Skill = Skill;
            foreach (GameObject Popup in Popup)
                Popup.SetActive(true);

            SkillNameText.text = SkillName;
            skillDescriptionText.text = SkillDescription;
            CelestialCostText.text = CelestialCost;
            SolarCostText.text = SolarCost;
            Line.SetActive(ShowLine);
            if (IsOwned)
            {
                IsOwnedText.text = "Owned";
            }
            else
            {
                IsOwnedText.text = UpgradeLevel;
            }
        }

    }
    public void Hide()
    {
        foreach (GameObject Popup in Popup)
            Popup.SetActive(false);
    }
}
