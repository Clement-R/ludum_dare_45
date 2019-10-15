using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOrchestrator : MonoBehaviour
{
    public static GameOrchestrator Instance;

    public Action<Level> OnLevelCleared;

    public int Day = 1;

    public Level ActualLevel
    {
        get
        {
            return m_levelToLoad;
        }
    }

    public List<Level> FinishedLevels
    {
        get;
        private set;
    } = new List<Level>();
    private Level m_levelToLoad = null;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        GameConfiguration.Instance.Player.GetComponent<HealthBehaviour>().OnDeath += LevelLose;
    }

    public void LaunchLevel(Level p_level)
    {
        m_levelToLoad = p_level;
        SceneManager.LoadScene("Level");
    }

    public void LevelWin()
    {
        //TODO: Implement
        // If is last level -> Win game and show score

        LevelEnd();
    }

    private void LevelEnd()
    {
        GameConfiguration.Instance.Player.GetComponent<HealthBehaviour>().OnDeath -= LevelLose;
        GameConfiguration.Instance.PlayerRenderer.Hide();

        //TODO: Play win effect

        //TODO: Load Map level
        StartCoroutine(_WinEffect());
    }

    private void LevelLose()
    {
        GameConfiguration.Instance.Player.GetComponent<HealthBehaviour>().OnDeath -= LevelLose;
        StartCoroutine(_LoseEffect());
    }

    private IEnumerator _WinEffect()
    {
        yield return SceneManager.LoadSceneAsync("Map");

        yield return null;

        // Apply upgrade to player
        PlayerUpgrader upgrader = GameConfiguration.Instance.Player.GetComponent<PlayerUpgrader>();

        if (ActualLevel.ArmorUpgrade != 0)
            for (int i = 0; i < ActualLevel.ArmorUpgrade; i++)
                upgrader.AddArmor();

        if (ActualLevel.PowerUpgrade != 0)
            for (int i = 0; i < ActualLevel.PowerUpgrade; i++)
                upgrader.AddPower();

        if (ActualLevel.SpeedUpgrade != 0)
            for (int i = 0; i < ActualLevel.SpeedUpgrade; i++)
                upgrader.AddSpeed();

        FinishedLevels.Add(ActualLevel);
        Day++;
        OnLevelCleared?.Invoke(ActualLevel);
    }

    private IEnumerator _LoseEffect()
    {
        //TODO: Implement
        yield return null;

        Debug.Log("Level LOSE");
        SceneManager.LoadScene("Map");
    }
}