using System;
using System.Collections;

using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelOrchestrator : MonoBehaviour
{
    private Level m_actualLevel;
    private GameObject m_boss;
    private HealthBehaviour m_bossHealth;
    private PlayerRenderer m_playerRenderer;

    private void Start()
    {
        m_actualLevel = Instantiate(GameOrchestrator.Instance.ActualLevel);
        
        m_actualLevel.WaveSystem.OnEnd += SpawnBoss;

        // Reset player position
        GameConfiguration.Instance.Player.transform.position = Vector2.zero;

        GameConfiguration.Instance.Player.GetComponent<HealthBehaviour>().OnDeath += LevelLose;

        // Show player
        m_playerRenderer = GameConfiguration.Instance.Player.GetComponent<PlayerRenderer>();
        m_playerRenderer.Show();
    }

    private void SpawnBoss()
    {
        SpawnZone zone = SpawnZoneConfiguration.Instance.Zones.Find(z => z.Tag == EZoneTag.NORTH);
        m_boss = Instantiate(m_actualLevel.BossPrefab, zone.Area.transform.position, Quaternion.identity);
        m_bossHealth = m_boss.GetComponent<HealthBehaviour>();
        m_bossHealth.OnDeath += LevelEnd;
    }

    private void LevelEnd()
    {
        GameConfiguration.Instance.Player.GetComponent<HealthBehaviour>().OnDeath -= LevelLose;
        m_playerRenderer.Hide();

        // Apply upgrade to player
        PlayerUpgrader upgrader = GameConfiguration.Instance.Player.GetComponent<PlayerUpgrader>();
        
        if(m_actualLevel.ArmorUpgrade != 0)
            for (int i = 0; i < m_actualLevel.ArmorUpgrade; i++)
                upgrader.AddArmor();

        if(m_actualLevel.PowerUpgrade != 0)
            for (int i = 0; i < m_actualLevel.PowerUpgrade; i++)
                upgrader.AddPower();

        if(m_actualLevel.SpeedUpgrade != 0)
            for (int i = 0; i < m_actualLevel.SpeedUpgrade; i++)
                upgrader.AddSpeed();

        //TODO: Play win effect

        //TODO: Load Map level
        StartCoroutine(_WinEffect());
    }

    private void LevelLose()
    {
        GameConfiguration.Instance.Player.GetComponent<HealthBehaviour>().OnDeath -= LevelLose;
        StartCoroutine(_LoseEffect());
    }

    private IEnumerator _WinEffect()
    {
        //TODO: Implement
        yield return null;
        
        // GameOrchestrator.Instance.LevelWin(this);
        SceneManager.LoadScene("Map");
    }

    private IEnumerator _LoseEffect()
    {
        //TODO: Implement
        yield return null;

        Debug.Log("Level LOSE");
        SceneManager.LoadScene("Map");
    }
}
