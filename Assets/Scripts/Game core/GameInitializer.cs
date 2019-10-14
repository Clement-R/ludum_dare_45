using System;

using UnityEngine;
using UnityEngine.SceneManagement;

public class GameInitializer : MonoBehaviour
{
    [SerializeField] private GameConfiguration m_gameConfigurationPrefab;
    [SerializeField] private GameObject m_playerPrefab;
    [SerializeField] private SpawnZoneConfiguration m_spawnZoneConfigurationPrefab;

    private GameConfiguration m_gameConfiguration;
    private GameObject m_player;
    private SpawnZoneConfiguration m_spawnZoneConfiguration;

    private void Awake()
    {
        // Instantiate GameConfiguration
        m_gameConfiguration = Instantiate(m_gameConfigurationPrefab);
        DontDestroyOnLoad(m_gameConfiguration);

        // Instantiate player
        m_player = Instantiate(m_playerPrefab);
        DontDestroyOnLoad(m_player);
        m_player.GetComponent<PlayerRenderer>().Hide();

        // Assign player to game conf
        m_gameConfiguration.SetPlayer(m_player);

        m_spawnZoneConfiguration = Instantiate(m_spawnZoneConfigurationPrefab);
        DontDestroyOnLoad(m_spawnZoneConfiguration);

        SceneManager.LoadScene("MainMenu");
    }
}
