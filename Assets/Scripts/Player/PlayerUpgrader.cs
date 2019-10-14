using System;
using UnityEngine;

public class PlayerUpgrader : MonoBehaviour
{
    public Action<string, int> OnUpgrade;

    public int Power
    {
        get;
        private set;
    } = 0;

    public int Speed
    {
        get;
        private set;
    } = 0;

    public int Armor
    {
        get;
        private set;
    } = 0;

    public int MaxUpgrade
    {
        get { return m_maxUpgrade; }
    }

    [SerializeField] private int m_maxUpgrade;
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
        Power ++;
        m_weapon.Damage += 1;
    }

    [ContextMenu("Add speed")]
    public void AddSpeed()
    {
        //TODO: Change sail, change speed
        // list with (sprite, speed)
        Speed ++;
        m_movement.SetInitialSpeed(m_movement.InitialSpeed + 1);
    }

    [ContextMenu("Add armor")]
    public void AddArmor()
    {
        //TODO: Change boat, change armor factor
        // list with (sprite, factor)
        Armor ++;
        m_health.ArmorFactor += 0.1f;
    }
}
