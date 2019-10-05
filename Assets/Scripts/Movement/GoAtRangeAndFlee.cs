using UnityEngine;

[CreateAssetMenu(fileName = "GoAtRangeAndFlee", menuName = "Movement/GoAtRangeAndFlee", order = 0)]
public class GoAtRangeAndFlee : GoAtShootingRange
{
    private float m_distanceToPlayer = 0f;

    public override Vector2 ComputeMovementVector(Transform p_myTransform)
    {
        base.ComputeMovementVector(p_myTransform);

        if(m_movementVector == Vector2.zero)
        {
            m_distanceToPlayer = Vector2.Distance(p_myTransform.position, GameConfiguration.Instance.Player.transform.position);

            if(m_distanceToPlayer < m_weapon.AttackRange * 0.85f)
                m_movementVector = (p_myTransform.position - GameConfiguration.Instance.Player.transform.position).normalized * m_speed;
        }

        return m_movementVector;
    }
}
