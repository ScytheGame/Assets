using System.Collections.Generic;
using UnityEngine;

public class SolarSystemDataSetter : MonoBehaviour
{
    [SerializeField] List<GameObject> PlanetTypes;
    void Awake()
    {
        SolarSystemData.PlanetTypes = PlanetTypes;
    }

}
