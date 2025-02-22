using UnityEngine;
using UnityEngine.UI;

public class OtherSettings : MonoBehaviour
{

    [SerializeField] Toggle SwapPlayerShip;
    [SerializeField] GameObject Ship1;
    [SerializeField] GameObject Ship2;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        Load();
    }
    void Update()
    {
        if (SwapPlayerShip.isOn == true)
        {
            Ship1.SetActive(false);
            Ship2.SetActive(true);
        }
        if (SwapPlayerShip.isOn == false)
        {
            Ship1.SetActive(true);
            Ship2.SetActive(false);
        }
        Save();
    }

    void Save()
    {
        PlayerPrefs.SetInt("SwapPlayerShipToggle", SwapPlayerShip.isOn ? 1 : 0);
    }
    void Load()
    {
        SwapPlayerShip.isOn = PlayerPrefs.GetInt("SwapPlayerShipToggle", 0) == 1;
    }
}
