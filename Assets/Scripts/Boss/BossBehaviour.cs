using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehaviour : MonoBehaviour
{
    [Tooltip("First one in list will be taken as default")]
    [SerializeField] private List<BossPhase> m_phases;

    [SerializeField] private HealthBehaviour m_health;

    private BossPhase m_currentPhase = null;
    private BossPhase m_nextPhase;
    private int m_currentPhaseIndex = 0;

    private void Start()
    {
        m_currentPhase = m_phases[0];
        if(!CurrentIsLastPhase())
            m_nextPhase = m_phases[m_currentPhaseIndex + 1];
    }

    void Update()
    {
        if(!CurrentIsLastPhase())
        {
            if(m_health.Percent <= m_nextPhase.HealthStep)
                GoToNextPhase();
        }

        m_currentPhase.Phase.Update();
    }

    private bool CurrentIsLastPhase()
    {
        return m_currentPhaseIndex == m_phases.Count - 1;
    }

    private void GoToNextPhase()
    {
        m_currentPhaseIndex ++;
        m_currentPhase = m_phases[m_currentPhaseIndex];

        if(!CurrentIsLastPhase())
            m_nextPhase = m_phases[m_currentPhaseIndex + 1];
    }
}
