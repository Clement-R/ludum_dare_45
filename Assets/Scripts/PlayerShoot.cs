using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private Transform m_dummyTarget;

    private WeaponSystem m_weapon;

    private void Start()
    {
        m_weapon = GetComponent<WeaponSystem>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            m_weapon.Shoot(m_dummyTarget);
        }       
    }
}
