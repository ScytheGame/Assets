using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class SkillInterface : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] SkillPopup SkillPopup;
    [SerializeField] GameObject SkillPopupObject;
    [SerializeField] SkillPrefabController SkillPrefabController;
    [SerializeField] bool IsMouseOver;


    [SerializeField] string SkillNameText;
    [SerializeField] string skillDescriptionText;
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

        SkillNameText = SkillPrefabController.SkillNameText;
        skillDescriptionText = SkillPrefabController.skillDescriptionText;
        CelestialCostText = SkillPrefabController.CelestialCostText;
        SolarCostText = SkillPrefabController.SolarCostText;
        UpgradeLevelText = SkillPrefabController.UpgradeLevelText;
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
