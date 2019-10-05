using UnityEngine;

public abstract class MovementPattern : ScriptableObject
{
    [SerializeField] protected float m_speed = 1f;
    
    protected Vector2 m_movementVector;
    
    public abstract Vector2 ComputeMovementVector(Transform p_myTransform);
}