using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D m_rigidbody;
    [SerializeField] private float m_speed = 2f;

    private Vector3 m_target;
    private Vector2 m_direction;

    void Start()
    {
        
    }

    void Update()
    {
        m_target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        m_direction = m_target - transform.position;

        Debug.Log(m_direction.magnitude) ;

        m_rigidbody.velocity = Vector2.zero;
        if (m_direction.magnitude > 0.1f)
        {
            m_rigidbody.AddForce(m_direction.normalized * m_speed, ForceMode2D.Impulse);
        }
    }
}
