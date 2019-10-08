﻿using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

public class MapOrchestrator : MonoBehaviour
{
    public static MapOrchestrator Instance;

    private LevelOrchestrator m_levelToLoad = null;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }

    public void LaunchLevel(LevelOrchestrator p_level)
    {
        m_levelToLoad = p_level;

        SceneManager.activeSceneChanged += SceneLoaded;
        SceneManager.LoadScene("Level");
    }

    public void LevelWin(LevelOrchestrator p_level)
    {
        //TODO: Implement
        // Cross level and set is as not-playable
        // If is last level -> Win game and show score
    }

    private void SceneLoaded(Scene p_previous, Scene p_actual)
    {
        Instantiate(m_levelToLoad);
        SceneManager.activeSceneChanged -= SceneLoaded;
    }
}