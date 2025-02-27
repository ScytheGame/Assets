using System.Collections.Generic;
using UnityEngine;

public class SkillTreeController : MonoBehaviour
{
    [SerializeField] StatsController Stats;
    [SerializeField] SkillPrefabController HeavyClass;
    [SerializeField] SkillPrefabController RapidClass;
    [SerializeField] SkillPrefabController HomingClass;
    [SerializeField] SkillPrefabController ExplosiveClass;
    [SerializeField] PlayerAttackController PlayerAttackController;
    [SerializeField] public string Class;
    public void Upgrade(string ID, float Value)
    {

        // Classes

        if (ID.Equals("Heavy"))
        {
            RapidClass.Disable();
            HomingClass.Disable();
            ExplosiveClass.Disable();
            Class = ("Heavy");
        }
        if (ID.Equals("Rapid"))
        {
            HeavyClass.Disable();
            HomingClass.Disable();
            ExplosiveClass.Disable();
            Class = ("Rapid");
        }
        if (ID.Equals("Homing"))
        {
            HeavyClass.Disable();
            RapidClass.Disable();
            ExplosiveClass.Disable();
            Class = ("Homing");
        }
        if (ID.Equals("Explosive"))
        {
            HeavyClass.Disable();
            RapidClass.Disable();
            HomingClass.Disable();
            Class = ("Explosive");
        }
        // Weapons

        if (ID.Equals("Missile"))
        {
            PlayerAttackController.MissileBool = true;
        }
        if (ID.Equals("Minigun"))
        {
            PlayerAttackController.MinigunBool = true;
        }
        if (ID.Equals("Drone"))
        {
            PlayerAttackController.DroneBool = true;
        }
        if (ID.Equals("Nuke"))
        {
            PlayerAttackController.NukeBool = true;
        }



        // Skills

        if (ID.Equals("DB")) // DB = Damage Boost
         {
            Stats.MinigunDamage *= Value + 0.9f;
            Stats.MissileDamage *= Value + 1f;
            Stats.DroneDamage *= Value + 0.9f;
            Stats.NukeDamage *= Value + 1.1f;
        }
        if (ID.Equals("ER")) // Explosion Radius
        {
            Stats.MissileRadiusMax *= Value + 1f;
            Stats.MissileRadiusMin *= Value + 1f;

            Stats.MinigunRadiusMax *= Value + 0.9f;
            Stats.MinigunRadiusMax *= Value + 0.9f;

            Stats.DroneRadiusMax *= Value + 0.9f;
            Stats.DroneRadiusMax *= Value + 0.9f;

            Stats.NukeRadiusMax *= Value + 1.1f;
            Stats.NukeRadiusMax *= Value + 1.1f;
        }
        if (ID.Equals("SB")) // SB = Speed Boost
        {
            Stats.Speed *= Value + 1;
        }
        if (ID.Equals("AS")) // AS = Attack Speed
        {
            Stats.MissileAttackDelay *= Value;
            Stats.MinigunAttackDelay *= Value;
            Stats.DroneAttackDelay *= Value;
            Stats.NukeAttackDelay *= Value;
        }
        if (ID.Equals("PS")) // Projectile Speed
        {
            Stats.MissileSpeed *= Value + 0.9f;
            Stats.MinigunSpeed *= Value + 1.1f;
            Stats.DroneSpeed *= Value + 1.1f;
            Stats.NukeSpeed *= Value + 0.8f;
        }
        if (ID.Equals("HB")) // Health Boost
        {
            Stats.MaxHealth *= Value + 1;
            Stats.Health = Stats.MaxHealth;
        }
        if (ID.Equals("EB")) // Experience Boost
        {
            Stats.ExperinceDropOnKillMax *= Value + 1;
            Stats.ExperinceDropOnKillMin *= Value + 1;
        }

        // Skills (bool)

        if (ID.Equals("MS")) // MultiShot
        {
            Stats.MultiShot = true;
        }
        if (ID.Equals("DS")) // DoubleShot
        {
            Stats.DoubleShot = true;
        }
        if (ID.Equals("HC")) // Homing
        {
            Stats.Homing = true;
        }
        if (ID.Equals("PS")) // Poison Shot
        {
            Stats.PoisonAttack = true;
        }
        if (ID.Equals("DP")) // Double Point
        {
            Stats.DoublePoint = true;
        }
    }
}
