using System;
using System.Collections;

using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelOrchestrator : MonoBehaviour
{
    public Action OnBossAppear;

    public GameObject Boss
    {
        get
        {
            return m_boss;
        }
    }

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

        // Show player
        m_playerRenderer = GameConfiguration.Instance.Player.GetComponent<PlayerRenderer>();
        m_playerRenderer.Show();
    }

    private void SpawnBoss()
    {
        SpawnZone zone = SpawnZoneConfiguration.Instance.Zones.Find(z => z.Tag == EZoneTag.NORTH);
        m_boss = Instantiate(m_actualLevel.BossPrefab, zone.Area.transform.position, Quaternion.identity);

        StartCoroutine(_SpawnBossEffect());
    }

    private IEnumerator _SpawnBossEffect()
    {
        // Disable boss weapon
        EnemyShoot enemyShoot = m_boss.GetComponent<EnemyShoot>();
        enemyShoot.enabled = false;

        // Disable player weapon
        PlayerShoot playerShoot = GameConfiguration.Instance.Player.GetComponent<PlayerShoot>();
        playerShoot.enabled = false;

        //TODO: Clear all bullets

        GameOrchestrator.Instance.DisablePlayerControl();

        //TODO: Maybe move player away to avoid overlaping with boss

        float t = 0f;
        float duration = 2f;

        Vector2 startPosition = m_boss.transform.position;
        Vector2 endPosition = startPosition + new Vector2(0f, -2f);

        while (t < 1f)
        {
            t += Time.deltaTime / duration;
            m_boss.transform.position = Vector2.Lerp(startPosition, endPosition, t);
            yield return null;
        }

        OnBossAppear?.Invoke();

        yield return new WaitForSeconds(0.5f);

        GameOrchestrator.Instance.EnablePlayerControl();

        // Re-enable boss & player weapon
        enemyShoot.enabled = true;
        playerShoot.enabled = true;

        m_bossHealth = m_boss.GetComponent<HealthBehaviour>();
        m_bossHealth.OnDeath += LevelEnd;
    }

    private void LevelEnd()
    {
        //TODO: Win effect (popup and co)
        GameOrchestrator.Instance.LevelWin();

        // GameConfiguration.Instance.Player.GetComponent<HealthBehaviour>().OnDeath -= LevelLose;
        // m_playerRenderer.Hide();

        // // Apply upgrade to player
        // PlayerUpgrader upgrader = GameConfiguration.Instance.Player.GetComponent<PlayerUpgrader>();

        // if(m_actualLevel.ArmorUpgrade != 0)
        //     for (int i = 0; i < m_actualLevel.ArmorUpgrade; i++)
        //         upgrader.AddArmor();

        // if(m_actualLevel.PowerUpgrade != 0)
        //     for (int i = 0; i < m_actualLevel.PowerUpgrade; i++)
        //         upgrader.AddPower();

        // if(m_actualLevel.SpeedUpgrade != 0)
        //     for (int i = 0; i < m_actualLevel.SpeedUpgrade; i++)
        //         upgrader.AddSpeed();

        // //TODO: Play win effect

        // //TODO: Load Map level
        // StartCoroutine(_WinEffect());
    }
}