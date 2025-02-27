using System.Collections.Generic;
using UnityEngine;

public class SkillTreeController : MonoBehaviour
{
    [SerializeField] SkillTreeController Stats;
    [SerializeField] bool HeavyClass;
    [SerializeField] bool RapidClass;
    [SerializeField] bool HomingClass;
    public void Upgrade(string ID, float Value)
    {

        // Classes

        if (ID.Equals("Rapid"))
        {
            RapidClass = true;
        }
        if (ID.Equals("Homing"))
        {
            HomingClass = true;
        }

        // Weapons

        if (ID.Equals("Missile"))
        {

        }

        if (ID.Equals("Minigun"))
        {

        }

        if (ID.Equals("Drone"))
        {

        }

        if (ID.Equals("Nuke"))
        {

        }



        // Skills

        if (ID.Equals("DB")) // DB = Damage Boost
        {

        }

        if (ID.Equals("SB")) // SB = Speed Boost
        {

        }

        if (ID.Equals("AS")) // AS = Attack Speed
        {

        }

        if (ID.Equals("PS")) // Projectile Speed
        {

        }

        if (ID.Equals("HB")) // Health Boost
        {

        }

        if (ID.Equals("EB")) // Experience Boost
        {

        }

        // Skills (bool)

        if (ID.Equals("MS")) // MultiShot
        {

        }

        if (ID.Equals("DS")) // DoubleShot
        {

        }

        if (ID.Equals("HC")) // Homing
        {

        }
    }
}
