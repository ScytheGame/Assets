using UnityEngine;

public class WormholeObject : MonoBehaviour
{

    [SerializeField] Wormhole Wormhole1;
    string Wormhole1Name;
    Vector3 Wormhole1Position;
    [SerializeField] Wormhole Wormhole2;
    string Wormhole2Name;
    Vector3 Wormhole2Position;

    private void Start()
    {
        Wormhole1Name = Wormhole1.Name;
        Wormhole1Position = Wormhole1.transform.position;

        Wormhole2Name = Wormhole2.Name;
        Wormhole2Position = Wormhole2.transform.position;
    }
    public Wormhole GetOtherWormhole(string WormholeName)
    {
        if (WormholeName == Wormhole1Name)
        {
            return Wormhole2;
        }
        else if (WormholeName == Wormhole2Name)
        {
            return Wormhole1;
        }

        else return null;
    }
    public Vector3 GetOtherWormholePosition(string WormholeName)
    {
        if (WormholeName == Wormhole1Name)
        {
            return Wormhole2Position;
        }
        else if (WormholeName == Wormhole2Name)
        {
            return Wormhole1Position;
        }

        else return new Vector3(0, 0, 0);
    }
}
