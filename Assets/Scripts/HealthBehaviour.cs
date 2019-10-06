using System;

using UnityEngine;

public class HealthBehaviour : MonoBehaviour
{
    public Action OnDeath;
    public Action OnHitTaken;
    public Action OnHeal;

    public float Health
    {
        get;
        private set;
    }

    public float Percent
    {
        get
        {
            return Health / MaxHealth;
        }
    }

    [SerializeField] private float MaxHealth = 100;

    private void Start()
    {
        Health = MaxHealth;    
    }

    public void TakeDamage(float p_amount)
    {
        Health -= p_amount;
        if(Health <= 0f)
            Death();
    }

    private void Death()
    {
        //TODO: Implement
    }

    #region DEBUG
    [ContextMenu("Take 5 damage")]
    private void TakeLowDamage()
    {
        TakeDamage(5f);
    }

    [ContextMenu("Take 50 damage")]
    private void TakeHighDamage()
    {
        TakeDamage(50f);
    }
    #endregion
}