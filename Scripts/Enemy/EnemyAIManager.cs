using UnityEngine;

public class EnemyAIManager : MonoBehaviour
{
    public static EnemyAIManager Instance { get; private set; }

    public float[] directionPreferences = new float[4];

    private void Awake()
    {

        for (int i = 0; i < directionPreferences.Length; i++)
        {
            directionPreferences[i] = 0f;
        }
    }
}
