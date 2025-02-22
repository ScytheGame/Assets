using UnityEngine;

public class SettingsController : MonoBehaviour
{
    [SerializeField] GameObject Settings;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Settings.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
