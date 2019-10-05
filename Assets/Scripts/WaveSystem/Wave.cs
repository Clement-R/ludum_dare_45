using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Wave", menuName = "Waves/Wave")]
public class Wave : ScriptableObject
{
    public bool IsDone
    {
        get;
        private set;
    }

    [SerializeField] List<WaveElement> m_waveElements;

    private float m_nextSpawn = 0f;
    private GameObject m_lastSpawned;
    private float m_lastSpawnTime = 0f;
    private int m_currentIndex = -1;
    private bool m_init = false;

    public void Update()
    {
        if(!IsDone)
        {
            // Initialize
            if(!m_init)
            {
                Spawn();
                m_init = true;
            }

            if(!IsCurrentTheLastElement())
            {
                if(TimeIsOver() || LastIsDead())
                    Spawn();
            }
            else
            {
                if(LastIsDead())
                    IsDone = true;
            }
        }
    }

    private void Spawn()
    {
        m_currentIndex++;
        WaveElement element = m_waveElements[m_currentIndex];

        // Get Zone
        SpawnZone zone = SpawnZoneConfiguration.Instance.Zones.Find(z => z.Tag == element.SpawnZone);
        
        // Spawn object
        m_lastSpawned = Instantiate(element.UnitPrefab, zone.GetRandomPointInZone(), Quaternion.identity);

        m_lastSpawnTime = Time.time;
        m_nextSpawn = Time.time + element.TimeBeforeNext;
    }

    private bool TimeIsOver()
    {
        return Time.time >= m_nextSpawn;
    }

    private bool LastIsDead()
    {
        return m_lastSpawned == null;
    }

    private bool IsCurrentTheLastElement()
    {
        return m_currentIndex == m_waveElements.Count - 1;
    }
}
