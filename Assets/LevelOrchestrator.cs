using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelOrchestrator : MonoBehaviour
{
    [SerializeField] WaveSystem m_waveSystem;
    [SerializeField] GameObject m_bossPrefab;

    private GameObject m_boss;
    private HealthBehaviour m_bossHealth;

    private void Start()
    {
        m_waveSystem.OnEnd += SpawnBoss;    
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
        Debug.Log("Level END !");
    }
}
