using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SkillInterface : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] SkillPopup SkillPopup;
    [SerializeField] GameObject SkillPopupObject;
    [SerializeField] SkillPrefabController SkillPrefabController;
    [SerializeField] bool IsMouseOver;


    [SerializeField] string SkillNameText;
    [SerializeField] string skillDescriptionText;
    [SerializeField] Image SkillIcon;
    [SerializeField] string CelestialCostText;
    [SerializeField] string SolarCostText;
    [SerializeField] string UpgradeLevelText;
    [SerializeField] bool IsOwned;
    [SerializeField] bool IsLocked;
    [SerializeField] bool ShowLine;

    void Update()
    {
        SkillPopupObject = GameObject.FindWithTag("Popup");
        SkillPopup = SkillPopupObject.GetComponent<SkillPopup>();

        SkillNameText = SkillPrefabController.SkillTree.SkillNameText;
        skillDescriptionText = SkillPrefabController.SkillTree.skillDescriptionText;
        SkillIcon.sprite = SkillPrefabController.SkillTree.SkillIcon;
        CelestialCostText = SkillPrefabController.SkillTree.CelestialCostText;
        SolarCostText = SkillPrefabController.SkillTree.SolarCostText;
        UpgradeLevelText = SkillPrefabController.SkillTree.UpgradeLevelText;
        IsOwned = SkillPrefabController.IsOwned;
        IsLocked = SkillPrefabController.IsLocked;
        SkillPrefabController.IsMouseOver = IsMouseOver;
        ShowLine = SkillPrefabController.ShowLine;


        if (IsMouseOver)
        {
            SkillPopup.Show(this.gameObject, SkillNameText, skillDescriptionText, CelestialCostText, SolarCostText, UpgradeLevelText, IsOwned, IsLocked, ShowLine);
        }
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        IsMouseOver = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        IsMouseOver = false;
        SkillPopup.Hide();
    }
}
