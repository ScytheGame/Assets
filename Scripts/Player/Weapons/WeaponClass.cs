using Sirenix.OdinInspector;
using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "WeaponClass", menuName = "Scriptable Objects/WeaponClass")]
public class WeaponClass : ScriptableObject
{
    [SerializeField, BoxGroup("Base")] public string ClassName;
    [SerializeField, BoxGroup("Base")] public string ClassDescription;
    [SerializeField, BoxGroup("Weapons")] public List<Weapon> Weapons;
}
