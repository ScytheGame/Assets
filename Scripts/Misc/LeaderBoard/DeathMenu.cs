using UnityEngine;

public class DeathMenu : MonoBehaviour
{
    [SerializeField] LeaderBoardController controller;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject player = GameObject.FindWithTag("LeaderBoard");

        if (player != null)
        {
            LeaderBoardController controller = player.GetComponent<LeaderBoardController>();

            if (controller != null)
            {
                controller.TriggerDeath();
            }
            else
            {
                //Debug.LogWarning("LeaderBoardController component not found on the GameObject with tag 'LeaderBoard'.");
            }
        }
        else
        {
            //Debug.LogWarning("GameObject with tag 'LeaderBoard' not found.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
