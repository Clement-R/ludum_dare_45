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

    public float NormalizedHealth
    {
        get
        {
            return Health / (float) m_maxHealth;
        }
    }

    public float ArmorFactor
    {
        get
        {
            return m_armorFactor;
        }
        set
        {
            m_armorFactor = value;
        }
    }

    public float Percent
    {
        get
        {
            return Health / m_maxHealth;
        }
    }

    [SerializeField] private float m_maxHealth = 100;
    [SerializeField] private float m_armorFactor = 0f;
    [SerializeField] private bool m_destroyOnDeath = true;
    [SerializeField] private ParticleSystem m_onHitEffect;
    [SerializeField] private ParticleSystem m_deathEffect;

    private void Start()
    {
        Health = m_maxHealth;
        ArmorFactor = m_armorFactor;
    }

    public void TakeDamage(float p_amount)
    {
        Health -= p_amount * (1f - m_armorFactor);
        OnHitTaken?.Invoke();

        if (m_onHitEffect != null)
            m_onHitEffect.Play();

        if (Health <= 0f)
            Death();
    }

    public void Heal(float p_amount)
    {
        Health = Mathf.Clamp(Health + p_amount, 0, m_maxHealth);
        OnHeal?.Invoke();
    }

    public void FullHeal()
    {
        Health = m_maxHealth;
        OnHeal?.Invoke();
    }

    private void Death()
    {
        if (m_deathEffect != null)
            Instantiate(m_deathEffect, transform.position, Quaternion.identity);

        if (m_destroyOnDeath)
            Destroy(gameObject);

        OnDeath?.Invoke();
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