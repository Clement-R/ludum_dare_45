using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUpgrader : MonoBehaviour
{
    [SerializeField] private WeaponSystem m_weapon;
    [SerializeField] private PlayerMovement m_movement;
    [SerializeField] private HealthBehaviour m_health;

    void Start()
    {
        
    }

    [ContextMenu("Add power")]
    public void AddPower()
    {
        //TODO: Change projectile, change damage
        // list of projectiles per power (sprite, damage, etc)
        // 1: arrow, 2: bullet, 3: cannon ball, etc.
        m_weapon.Damage += 1;
    }

    [ContextMenu("Add speed")]
    public void AddSpeed()
    {
        //TODO: Change sail, change speed
        // list with (sprite, speed)
        m_movement.SetInitialSpeed(m_movement.InitialSpeed + 1);
    }

    [ContextMenu("Add armor")]
    public void AddArmor()
    {
        //TODO: Change boat, change armor factor
        // list with (sprite, factor)
        m_health.ArmorFactor += 0.1f;
    }
}
