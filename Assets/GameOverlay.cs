using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class GameOverlay : MonoBehaviour
{
    [SerializeField] private Image m_playerHealthUI;
    [SerializeField] private ParticleSystem m_playerHealthDamageEffect;
    [SerializeField] private Image m_bossHealthUI;
    [SerializeField] private CanvasGroup m_bossHealthGroup;
    [SerializeField] private LevelOrchestrator m_levelOrchestrator;

    private bool m_isInBossFight = false;
    private HealthBehaviour m_playerHealth;
    private HealthBehaviour m_bossHealth;

    private void Start()
    {
        m_playerHealth = GameConfiguration.Instance.Player.GetComponent<HealthBehaviour>();

        m_playerHealth.OnHitTaken += PlayerDamaged;
        m_levelOrchestrator.OnBossAppear += ShowBossUI;
    }

    private void Update()
    {
        m_playerHealthUI.fillAmount = m_playerHealth.NormalizedHealth;

        // Update boss health if in boss fight
        if (m_isInBossFight)
        {
            m_bossHealthUI.fillAmount = m_bossHealth.NormalizedHealth;
        }
    }

    private void ShowBossUI()
    {
        StartCoroutine(_ShowBossUI());
    }

    private IEnumerator _ShowBossUI()
    {
        m_isInBossFight = true;

        m_bossHealth = m_levelOrchestrator.Boss.GetComponent<HealthBehaviour>();

        float t = 0f;
        float duration = 1f;

        m_bossHealthGroup.alpha = 0f;

        while (t < 1f)
        {
            t += Time.deltaTime / duration;
            m_bossHealthGroup.alpha = Mathf.Lerp(0f, 1f, t);
            yield return null;
        }

        m_bossHealth.OnDeath += BossEnd;
    }

    private void BossEnd()
    {
        m_bossHealthGroup.alpha = 0f;
    }

    private void PlayerDamaged()
    {
        m_playerHealthDamageEffect.Play();
    }
}