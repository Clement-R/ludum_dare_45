using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Spreadshot", menuName = "Pattern/Spreadshot")]
public class SpreadShot : BulletPattern
{
    public float Angle = 45f;

    public override void Shoot(Vector2 m_position, Transform p_target, Bullet p_bullet, float p_damage)
    {
        //TODO: Use pool
        Bullet bullet = Instantiate(p_bullet, m_position, Quaternion.identity);
        Bullet bulletL = Instantiate(p_bullet, m_position, Quaternion.identity);
        Bullet bulletR = Instantiate(p_bullet, m_position, Quaternion.identity);

        Vector3 pos = m_position;
        Vector2 direction = (p_target.position - pos).normalized;

        bullet.Shoot(direction, p_damage);
        bulletL.Shoot(Quaternion.Euler(0f, 0f, -Angle) * direction, p_damage);
        bulletR.Shoot(Quaternion.Euler(0f, 0f, Angle) * direction, p_damage);
    }
}
