using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D m_rigidbody;
    [SerializeField] private MovementPattern m_movementPattern;

    void Update()
    {
        Vector2 movementVector = m_movementPattern.ComputeMovementVector(transform);

        m_rigidbody.velocity = Vector2.zero;
        m_rigidbody.AddForce(movementVector, ForceMode2D.Impulse);
    }
}
