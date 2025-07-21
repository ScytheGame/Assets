using UnityEngine;

public class Wormhole : MonoBehaviour
{
    [SerializeField] public string Name;
    [SerializeField] WormholeObject WormholeObject;
    Wormhole OtherWormhole;
    Vector3 OtherWormholePosition;
    public float DelayTime = 0.01f;
    public float Timer = 0;
    private void Update()
    {
        if (OtherWormhole == null)
            OtherWormhole = WormholeObject.GetOtherWormhole(Name);
        if (OtherWormholePosition == Vector3.zero)
        OtherWormholePosition = WormholeObject.GetOtherWormholePosition(Name);

        Timer += Time.deltaTime;
    }
    public void ResetTimer()
    {
        Timer = 0;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Timer >= DelayTime)
            if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("player") || collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("enemy"))
            {
                Debug.Log($"TelePorting Object To: {OtherWormholePosition}");
                OtherWormhole.ResetTimer();
                ResetTimer();
                collision.transform.position = OtherWormholePosition;
            }
    }
}
