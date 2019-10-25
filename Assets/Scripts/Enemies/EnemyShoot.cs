using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField] private WeaponSystem m_weapon;

    private Transform m_target;

    private void Start()
    {
        m_target = GameConfiguration.Instance.Player.transform;
    }

    private void Update()
    {
        if (m_weapon.CanShoot() && m_weapon.IsInRange(m_target))
            m_weapon.Shoot(m_target);
    }
}