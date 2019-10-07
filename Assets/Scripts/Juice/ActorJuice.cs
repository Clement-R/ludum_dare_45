using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorJuice : MonoBehaviour
{
    [SerializeField] private HealthBehaviour m_health;

    void Start()
    {
        m_health.OnHitTaken += HitTaken;
    }

    protected virtual void HitTaken()
    {
        //TODO: Blink
    }
}
