using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class GameOverlay : MonoBehaviour
{
    [SerializeField] private Image m_health;

    private HealthBehaviour m_playerHealth;

    private void Start()
    {
        m_playerHealth = GameConfiguration.Instance.Player.GetComponent<HealthBehaviour>();
    }

    private void Update()
    {
        m_health.fillAmount = m_playerHealth.NormalizedHealth;
    }
}