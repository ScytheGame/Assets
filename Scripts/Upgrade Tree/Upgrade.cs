using TMPro;
using UnityEngine;

public class Upgrade : MonoBehaviour
{
    public string ID;
    public float Value;
    public float cost;
    public bool OneTime;

    [SerializeField] TextMeshProUGUI UpgradeNameText;
    [SerializeField] TextMeshProUGUI UpgradeDescriptionText;
    [SerializeField] Upgrade[] PreviousUpgrade;
    [SerializeField] UpgradeTree UpgradeTree;
    [SerializeField] Upgradepoints upgradepoints;
    bool IsUnlocked = false;
    bool CanUnlock = false;


    private void Update()
    {
        if (PreviousUpgrade != null)
        {
            foreach (Upgrade upgrade in PreviousUpgrade)
            {
                if (!IsUnlocked)
                {
                    CanUnlock = false;
                    break;
                }
                CanUnlock = true;
            }
        }
    }

    public void Unlock()
    {
        if (cost <= upgradepoints.SkillPoints)
        {

            if (CanUnlock)
            {
                UpgradeTree.Unlock(ID, Value, OneTime);
            }
        }
    }

}
