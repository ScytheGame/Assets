using System.Collections.Generic;
using UnityEngine;

public static class SolarSystemData
{
    public static List<GameObject> PlanetTypes;
    public static Color[] StarColours = new Color[]
    {
        new Color(0.6f, 0.8f, 1.0f),
        new Color(0.7f, 0.85f, 1.0f),
        new Color(1.0f, 1.0f, 1.0f),
        new Color(1.0f, 1.0f, 0.9f),
        new Color(1.0f, 1.0f, 0.6f),
        new Color(1.0f, 0.8f, 0.4f),
        new Color(1.0f, 0.5f, 0.3f)
    };
}
