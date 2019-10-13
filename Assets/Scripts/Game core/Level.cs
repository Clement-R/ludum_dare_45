using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public WaveSystem WaveSystem;
    public GameObject BossPrefab;

    [Header("Upgrade")]
    public int PowerUpgrade = 0;
    public int ArmorUpgrade = 0;
    public int SpeedUpgrade = 0;
}
