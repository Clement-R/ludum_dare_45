using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUpgrader : MonoBehaviour
{
    [SerializeField] private WeaponSystem m_weapon;
    [SerializeField] private PlayerMovement m_movement;

    void Start()
    {
        
    }

    public void AddPower()
    {
        //TODO: Change projectile, change damage
        // list of projectiles per power 1: arrow, 2: bullet, 3: cannon ball, etc.
    }

    public void AddSpeed()
    {
        
    }

    public void AddArmor()
    {

    }
}
