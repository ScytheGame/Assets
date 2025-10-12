using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "Scriptable Objects/EnemyData")]
public class EnemyData : ScriptableObject
{
    [SerializeField, TabGroup("Base")] public string Name;

    [SerializeField, TabGroup("Stats")] public float MoveSpeed;
    [SerializeField, TabGroup("Stats")] public float RotationSpeed;

    [SerializeField, TabGroup("Stats")] public float Health;
    [SerializeField, TabGroup("Stats")] public float Damage;
    [SerializeField, TabGroup("Stats")] public float AttackRate;
    [SerializeField, TabGroup("Stats")] public Vector2Int LevelRange;
}
