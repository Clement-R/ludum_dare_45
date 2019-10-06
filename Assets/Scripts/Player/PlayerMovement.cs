using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float Speed
    {
        get
        {
            return m_speed;
        }

        set
        {
            m_speed = value;
        }
    }
    
    [SerializeField] private Rigidbody2D m_rigidbody;
    [SerializeField] private float m_speed = 2f;
    [SerializeField] private float m_initialSpeed = 2f;

    private Vector3 m_target;
    private Vector2 m_direction;

    private void Start()
    {
        m_initialSpeed = m_speed;
    }

    // Store previous speed to allow usage of slow effects, at the end
    // of status speed should be set to m_initialSpeed
    public void SetInitialSpeed(float p_speed)
    {
        m_initialSpeed = p_speed;
        Speed = m_initialSpeed;
    }

    void Update()
    {
        m_target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        m_direction = m_target - transform.position;

        m_rigidbody.velocity = Vector2.zero;
        if (m_direction.magnitude > 0.1f)
        {
            m_rigidbody.AddForce(m_direction.normalized * m_speed, ForceMode2D.Impulse);
        }
    }
}
