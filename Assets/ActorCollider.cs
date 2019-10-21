using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class ActorCollider : MonoBehaviour
{
    [SerializeField] private LayerMask m_collisionLayers;

    private void OnTriggerEnter2D(Collider2D p_other)
    {
        if (m_collisionLayers == (m_collisionLayers | (1 << p_other.gameObject.layer)))
        {
            p_other.GetComponent<HealthBehaviour>().TakeDamage(5);
            gameObject.GetComponent<HealthBehaviour>().TakeDamage(5);
        }
    }
}