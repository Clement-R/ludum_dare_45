using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D m_rigidbody;
    [SerializeField] private MovementPattern m_movementPattern;

    public void SetPattern(MovementPattern p_pattern)
    {
        m_movementPattern = p_pattern;
    }

    private void Update()
    {
        Vector2 movementVector = m_movementPattern.ComputeMovementVector(transform);

        m_rigidbody.velocity = Vector2.zero;
        m_rigidbody.AddForce(movementVector, ForceMode2D.Impulse);
    }
}
