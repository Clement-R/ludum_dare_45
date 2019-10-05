using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BulletPattern : ScriptableObject
{
    public abstract void Shoot(Vector2 m_shootPosition, Transform p_target, Bullet p_bullet, int p_damage);
}
