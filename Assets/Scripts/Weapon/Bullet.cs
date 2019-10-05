using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Speed = 1f;

    [SerializeField] private LayerMask m_layer;
    [SerializeField] private bool m_steering = false;
    
    private Rigidbody2D m_rigidbody;
    private int m_damage = 1;

    private void Awake()
    {
        m_rigidbody = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 5f);
    }

    public void Shoot(Vector2 p_direction, int p_damage)
    {
        m_damage = p_damage;
        m_rigidbody.AddForce(p_direction * Speed, ForceMode2D.Impulse);
    }

    public void ShootAt(Transform p_target, int p_damage)
    {
        Vector2 direction = (p_target.position - transform.position).normalized;
        m_damage = p_damage;

        if(m_steering)
        {
            //TODO: Implement
        }
        else
        {
            m_rigidbody.AddForce(direction * Speed, ForceMode2D.Impulse);
        }
    }

    private void OnTriggerEnter2D(Collider2D p_other)
    {
        //TODO: Implement
        // Get Health component
        // health.TakeDamage(m_damage)
    }
}
