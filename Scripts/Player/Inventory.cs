using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GameObject Skills;
    void Update()
    {

        if (Input.GetKeyDown("tab"))
        {
            if(Skills.activeInHierarchy == false)
            {
                Skills.SetActive(true);

            }
            else
            {
                Skills.SetActive(false);

            }
        }
    }
}
