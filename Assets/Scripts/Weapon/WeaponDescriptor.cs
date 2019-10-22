using System;

using UnityEngine;

[System.Serializable]
public class WeaponDescriptor
{
    public BulletPattern Pattern;
    public Bullet BulletPrefab;
    public int Damages;
}