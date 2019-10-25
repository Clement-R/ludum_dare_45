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

    public bool PlayerCanMove
    {
        get
        {
            return m_playerCanMove;
        }
    }

    public bool LevelRunning
    {
        get;
        private set;
    }

    public List<Level> FinishedLevels
    {
        get;
        private set;
    } = new List<Level>();

    private Level m_levelToLoad = null;
    private HealthBehaviour m_playerHealth;
    private bool m_playerCanMove = true;

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
        m_playerHealth = GameConfiguration.Instance.Player.GetComponent<HealthBehaviour>();
    }

    public void DisablePlayerControl()
    {
        m_playerCanMove = false;
    }

    public void EnablePlayerControl()
    {
        m_playerCanMove = true;
    }

    public void LaunchLevel(Level p_level)
    {
        m_levelToLoad = p_level;
        m_playerHealth.FullHeal();
        GameConfiguration.Instance.Player.transform.position = Vector2.zero;

        SceneManager.LoadScene("Level");
        LevelRunning = true;
        m_playerHealth.OnDeath += LevelLose;
    }

    public void LevelWin()
    {
        LevelRunning = false;
        LevelEnd();
    }

    private void LevelEnd()
    {
        m_playerHealth.OnDeath -= LevelLose;
        GameConfiguration.Instance.PlayerRenderer.Hide();

        //TODO: Play win effect

        //TODO: Load Map level
        StartCoroutine(_WinEffect());
    }

    private IEnumerator _WinEffect()
    {
        if (ActualLevel.LastLevel)
        {
            GameWin();
            yield break;
        }

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

    private void GameWin()
    {
        //TODO: Do a end game effect
        PopupsManager.Instance.ShowPopup(EPopup.WIN, EndGame);
    }

    private void EndGame()
    {
        Debug.Log("Game win !");
        ResetGame();
        SceneManager.LoadScene("MainMenu");
    }

    private void LevelLose()
    {
        LevelRunning = false;
        Time.timeScale = 0f;
        PopupsManager.Instance.ShowPopup(EPopup.LOSE, Lose);
    }

    private void Lose()
    {
        GameConfiguration.Instance.PlayerRenderer.Hide();
        GameConfiguration.Instance.Player.GetComponent<HealthBehaviour>().OnDeath -= LevelLose;
        StartCoroutine(_LoseEffect());
    }

    private IEnumerator _LoseEffect()
    {
        //TODO: Implement
        yield return null;

        Debug.Log("Level LOSE");
        ResetGame();
        SceneManager.LoadScene("MainMenu");
    }

    private void ResetGame()
    {
        Day = 1;
        GameConfiguration.Instance.PlayerUpgrader.Reset();
        FinishedLevels.Clear();
        m_levelToLoad = null;
    }
}