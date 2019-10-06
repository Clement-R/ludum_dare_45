using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Singleshot", menuName = "Pattern/Singleshot")]
public class SingleShot : BulletPattern
{
    public override void Shoot(Vector2 m_position, Transform p_target, Bullet p_bullet, float p_damage)
    {
        //TODO: Use pool
        Bullet bullet = Instantiate(p_bullet, m_position, Quaternion.identity);
        bullet.ShootAt(p_target, p_damage);
    }
}
