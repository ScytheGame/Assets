using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using System.Threading.Tasks;
using SimpleKeplerOrbits;
using UnityEngine.Rendering.Universal;

public class CelestialObjectColourController : MonoBehaviour
{
    [SerializeField] Color Colour;
    [SerializeField] SpriteRenderer SpriteRenderer;
    [SerializeField] Light2D Light2D;
    [SerializeField] bool IsStar;
    [SerializeField] bool IsMoon;
    public void SetColour()
    {
        long Time = System.DateTime.Now.Ticks;
        int seed = (int)(Time % int.MaxValue);
        UnityEngine.Random.InitState(seed);

        if (IsMoon)
            return;

        if (IsStar)
        {
            Colour = SolarSystemData.StarColours[UnityEngine.Random.Range(0, SolarSystemData.StarColours.Length)];
            SpriteRenderer.color = Colour;
            Light2D.color = Colour;
            Debug.Log($"Choosen Colour: {Colour} ");
        }
        else
        {
            Colour = new Color(UnityEngine.Random.Range(0f, 1f), UnityEngine.Random.Range(0f, 1f), UnityEngine.Random.Range(0f, 1f));
            SpriteRenderer.color = Colour;
        }
    }
}
