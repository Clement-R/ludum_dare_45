using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class PlayerUpgrader : MonoBehaviour
{
    public Action<EStats> OnUpgrade;

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
        get
        {
            return m_maxUpgrade;
        }
    }

    [SerializeField] private int m_maxUpgrade;
    [SerializeField] private WeaponSystem m_weapon;
    [SerializeField] private PlayerMovement m_movement;
    [SerializeField] private HealthBehaviour m_health;

    [Header("Upgrades")]
    [SerializeField] private List<Sprite> m_sails;
    [SerializeField] private List<Sprite> m_ships;
    [SerializeField] private List<WeaponDescriptor> m_powers;

    [Header("Player parts")]
    [SerializeField] private SpriteRenderer m_playerRenderer;
    [SerializeField] private SpriteRenderer m_sailRenderer;

    void Start()
    {

    }

    [ContextMenu("Add power")]
    public void AddPower()
    {
        Power++;

        WeaponDescriptor weapon = m_powers[Power];

        m_weapon.Damage = weapon.Damages;
        m_weapon.SetBulletPrefab(weapon.BulletPrefab);
        m_weapon.SetPattern(weapon.Pattern);

        OnUpgrade?.Invoke(EStats.POWER);
    }

    [ContextMenu("Add speed")]
    public void AddSpeed()
    {
        Speed++;
        m_movement.SetInitialSpeed(m_movement.InitialSpeed + 1);

        //TODO: Effect on sail change
        m_sailRenderer.sprite = m_sails[Speed];

        OnUpgrade?.Invoke(EStats.SPEED);
    }

    [ContextMenu("Add armor")]
    public void AddArmor()
    {
        Armor++;
        m_health.ArmorFactor += 0.1f;

        //TODO: Effect on boat change
        m_playerRenderer.sprite = m_ships[Armor];

        OnUpgrade?.Invoke(EStats.ARMOR);
    }

    public void Reset()
    {
        Power = 0;
        Armor = 0;
        Speed = 0;
    }
}