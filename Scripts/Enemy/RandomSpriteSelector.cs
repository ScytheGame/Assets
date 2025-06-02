using UnityEngine;

public class RandomSpriteSelector : MonoBehaviour
{
    [SerializeField] GameObject[] sprites;

    private void Start()
    {
        if (sprites.Length == 0)
        {
            Debug.LogWarning("No sprites assigned to RandomSpriteSelector.");
            return;
        }

        int randomIndex = Random.Range(0, sprites.Length);
        GameObject selectedSprite = sprites[randomIndex];

        selectedSprite.SetActive(true);
    }
}
