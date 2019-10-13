using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapMenu : MonoBehaviour
{
    private void Start()
    {
        UpdateUI();    
    }

    public void LevelClicked(Level p_level)
    {
        GameOrchestrator.Instance.LaunchLevel(p_level);
    }

    private void UpdateUI()
    {
        //TODO: Implement
        // Show upgrades
        // Cross level done
        // Cross level and set is as not-playable
    }
}
