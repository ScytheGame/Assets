using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GameObject Skills;
    bool isOpen = false;
    void Update()
    {

        if (Input.GetKeyDown("tab"))
        {
            if (isOpen)
                isOpen = false;
            else
                isOpen = true;
        }

        Skills.SetActive(isOpen);
    }
}
