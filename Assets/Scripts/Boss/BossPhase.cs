using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BossPhase
{
    [Tooltip("Represent life percentage, goes from 1 to 0")]
    public float HealthStep;
    public Phase Phase;
}
