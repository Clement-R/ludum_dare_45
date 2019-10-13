using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOrchestrator : MonoBehaviour
{
    public static GameOrchestrator Instance;

    public Level ActualLevel
    {
        get { return m_levelToLoad; }
    }

    private Level m_levelToLoad = null;

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

    public void LaunchLevel(Level p_level)
    {
        m_levelToLoad = p_level;
        SceneManager.LoadScene("Level");
    }

    public void LevelWin(Level p_level)
    {
        //TODO: Implement
        // If is last level -> Win game and show score
    }
}
