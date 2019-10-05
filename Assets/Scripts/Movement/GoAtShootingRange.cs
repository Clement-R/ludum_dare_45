using UnityEngine;

[CreateAssetMenu(fileName = "GoAtShootingRange", menuName = "Movement/GoAtShootingRange", order = 0)]
public class GoAtShootingRange : MovementPattern
{
    protected WeaponSystem m_weapon = null;

    public override Vector2 ComputeMovementVector(Transform p_myTransform)
    {
        m_movementVector = Vector2.zero;

        if(m_weapon == null)
            m_weapon = p_myTransform.gameObject.GetComponent<WeaponSystem>();

        // Am I in attack range ?
        if(!m_weapon.IsInRange(GameConfiguration.Instance.Player.transform))
        {
            m_movementVector = (GameConfiguration.Instance.Player.transform.position - p_myTransform.position).normalized * m_speed;
        }

        return m_movementVector;
    }
}