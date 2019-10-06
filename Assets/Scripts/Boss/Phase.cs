using UnityEngine;

public abstract class Phase : ScriptableObject
{
    public abstract void Init(EnemyMovement p_movement, WeaponSystem p_weapon);
}