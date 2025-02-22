using UnityEngine;
using UnityEngine.UIElements;

public class FloatingText : MonoBehaviour
{
    public float DestroyTime = 1.5f;

    private void Start()
    {
        int RR1 = Random.Range(1, 4);
        int RR2 = Random.Range(1, 4);
        Vector3 Offset = new Vector3(RR1, RR2, 0);
        transform.localPosition = Offset;
    }
    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.identity;
        DestroyTime -= Time.deltaTime;
        if (DestroyTime <= 0 )
        {
            Destroy(gameObject);
        }
    }
}
