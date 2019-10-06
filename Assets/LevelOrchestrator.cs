using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelOrchestrator : MonoBehaviour
{
    [SerializeField] WaveSystem m_waveSystem;
    [SerializeField] GameObject m_bossPrefab;

    [Header("Upgrade")]
    [SerializeField] private int m_powerUpgrade = 0;
    [SerializeField] private int m_armorUpgrade = 0;
    [SerializeField] private int m_speedUpgrade = 0;

    private GameObject m_boss;
    private HealthBehaviour m_bossHealth;
    private PlayerRenderer m_playerRenderer;

    private void Start()
    {
        m_waveSystem.OnEnd += SpawnBoss;

        // Reset player position
        GameConfiguration.Instance.Player.transform.position = Vector2.zero;

        // Show player
        m_playerRenderer = GameConfiguration.Instance.Player.GetComponent<PlayerRenderer>();
        m_playerRenderer.Show();
    }

    private void SpawnBoss()
    {
        SpawnZone zone = SpawnZoneConfiguration.Instance.Zones.Find(z => z.Tag == EZoneTag.NORTH);
        m_boss = Instantiate(m_bossPrefab, zone.Area.transform.position, Quaternion.identity);
        m_bossHealth = m_boss.GetComponent<HealthBehaviour>();
        m_bossHealth.OnDeath += LevelEnd;
    }

    private void LevelEnd()
    {
        m_playerRenderer.Hide();

        // Apply upgrade to player
        PlayerUpgrader upgrader = GameConfiguration.Instance.Player.GetComponent<PlayerUpgrader>();
        
        if(m_armorUpgrade != 0)
            for (int i = 0; i < m_armorUpgrade; i++)
                upgrader.AddArmor();

        if(m_powerUpgrade != 0)
            for (int i = 0; i < m_powerUpgrade; i++)
                upgrader.AddPower();

        if(m_speedUpgrade != 0)
            for (int i = 0; i < m_speedUpgrade; i++)
                upgrader.AddSpeed();

        //TODO: Show end menu

        //TODO: Load Map level
    }
}
