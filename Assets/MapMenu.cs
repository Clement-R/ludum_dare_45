using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapMenu : MonoBehaviour
{
    public void LevelClicked(LevelOrchestrator p_level)
    {
        MapOrchestrator.Instance.LaunchLevel(p_level);
    }
}
