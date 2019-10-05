﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSystem : MonoBehaviour
{
    public float AttackRange
    {
        get
        {
            return m_attackRange;
        }
    }

    [SerializeField] private float m_attackSpeed = 1f;
    [SerializeField] private int m_damage = 1;
    [SerializeField] private float m_cooldown = 0.5f;
    [SerializeField] private float m_attackRange = 5f;
    [SerializeField] private Bullet m_bulletPrefab;
    [SerializeField] private BulletPattern m_patternPrefab;

    private BulletPattern m_pattern;

    private float m_lastShot = -1f;

    private void Start()
    {
        m_pattern = Instantiate(m_patternPrefab);
    }

    public void Shoot(Transform p_target)
    {
        m_lastShot = Time.time;
        //TODO: maybe rework position ?
        m_pattern.Shoot(transform.position, p_target, m_bulletPrefab, m_damage);
    }

    public bool IsInRange(Transform p_target)
    {
        return  (Vector2.Distance(p_target.position, transform.position) <= m_attackRange);
    }

    public bool CanShoot()
    {
        return (Time.time >= m_lastShot + m_cooldown);
    }
}
