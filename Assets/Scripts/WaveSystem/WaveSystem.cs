using System;
using System.Collections.Generic;
using UnityEngine;

public class WaveSystem : MonoBehaviour
{
    public Action OnEnd;

    public bool IsDone
    {
        get;
        private set;
    } = false;

    [SerializeField] List<Wave> m_waves;
    
    private Wave m_currentWave = null;
    private int m_currentWaveIndex = 0;
    private bool m_init = false;

    void Update()
    {
        if(!IsDone)
        {
            // Initialize
            if(!m_init)
            {
                m_currentWave = Instantiate(m_waves[0]);
                m_currentWaveIndex = 0;
                m_init = true;
            }

            // Wait for current wave to end, if so, start next one
            if(m_currentWave.IsDone)
            {
                if(IsLastWave())
                {
                    IsDone = true;
                    OnEnd?.Invoke();
                }
                else
                {
                    m_currentWaveIndex++;
                    m_currentWave = Instantiate(m_waves[m_currentWaveIndex]);
                }
            }
            else
            {
                m_currentWave.Update();
            }
        }
    }

    private bool IsLastWave()
    {
        return m_currentWaveIndex == m_waves.Count - 1;
    }
}
