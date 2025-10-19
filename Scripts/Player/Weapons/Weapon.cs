using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "Scriptable Objects/Weapon")]
public class Weapon : ScriptableObject
{
    [SerializeField, BoxGroup("Base")] public string WeaponName;
    [SerializeField, BoxGroup("Base")] public string WeaponDescription;
    [SerializeField, BoxGroup("Base")] public WeaponClass Class;
    [SerializeField, BoxGroup("Base")] public GameObject BulletPrefab;

    [SerializeField, BoxGroup("Weapon Stats")] public Vector3 DamageRange;
    [SerializeField, BoxGroup("Weapon Stats")] public float AmmoCost;
    [SerializeField, BoxGroup("Weapon Stats")] public float AttackSpeed;
    [SerializeField, BoxGroup("Weapon Stats")] public float MaxAttackSpeed;
    [SerializeField, BoxGroup("Weapon Stats")] public float ProjectileSpeed;
    [SerializeField, BoxGroup("Weapon Stats")] public float BulletLifetime;
    [SerializeField, BoxGroup("weapon Stats")] public float BulletHealth;

    [SerializeField, BoxGroup("Weapon Skills")] public bool DoubleShot;
    [SerializeField, BoxGroup("Weapon Skills")] public bool BackwardsFire;
    [SerializeField, BoxGroup("Weapon Skills")] public bool MultiShot;

    [SerializeField, BoxGroup("Extras")] public int BulletCount;
    [SerializeField, BoxGroup("Extras")] public int IntermitentFireDelay;
    [SerializeField, BoxGroup("Extras")] public bool Burst;

    [SerializeField, BoxGroup("Extras")] public Vector2 Spread;
    [SerializeField, BoxGroup("Extras")] public bool RandomSpread;

}
