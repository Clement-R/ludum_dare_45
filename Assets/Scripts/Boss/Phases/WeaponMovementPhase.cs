using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponMovementPhase", menuName = "Phases/WeaponMovementPhase")]
public class WeaponMovementPhase : Phase
{
    [SerializeField] private MovementPattern m_movementPattern;
    [SerializeField] private BulletPattern m_bulletPattern;

    //TODO: Add new weaponsystem configuration to override cooldown, etc

    public override void Init(EnemyMovement p_movement, WeaponSystem p_weapon)
    {
        p_movement.SetPattern(m_movementPattern);
        p_weapon.SetPattern(m_bulletPattern);
    }
}
