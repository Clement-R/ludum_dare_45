using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private Transform m_dummyTarget;

    private WeaponSystem m_weapon;
    private Transform m_target;
    private GameObject[] m_enemies;

    private void Start()
    {
        m_weapon = GetComponent<WeaponSystem>();
    }

    void Update()
    {
        if(Time.frameCount % 5 == 0)
        {
            GetNearestTarget();
        }

        if(m_weapon.CanShoot() && m_target != null)
            m_weapon.Shoot(m_target);
    }

    private void GetNearestTarget()
    {
        m_enemies = GameObject.FindGameObjectsWithTag("Enemy");

        float minDistance = 999f;
        Transform closest = null;
        Transform enemy = null;
        float distance = 0f;
        
        for (int i = 0; i < m_enemies.Length; i++)
        {
            enemy = m_enemies[i].transform;
            distance = (enemy.position - transform.position).magnitude;

            if(distance < minDistance)
            {
                minDistance = distance;
                closest = enemy;
            }
        }

        m_target = closest;
    }
}
