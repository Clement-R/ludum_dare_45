using System.Collections.Generic;

using UnityEngine;

public class SpawnZoneConfiguration : MonoBehaviour
{
    public static SpawnZoneConfiguration Instance = null;

    public List<SpawnZone> Zones
    {
        get
        {
            return m_zones;
        }
    }

    [SerializeField] private List<SpawnZone> m_zones;

    private void Awake()
    {
        if(Instance == null)    
            Instance = this;
        else
            Destroy(gameObject);
    }
}