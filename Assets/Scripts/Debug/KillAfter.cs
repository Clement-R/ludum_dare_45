using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillAfter : MonoBehaviour
{
    [SerializeField] private float m_time = 2f;

    void Start()
    {
        Destroy(gameObject, m_time);
    }
}
