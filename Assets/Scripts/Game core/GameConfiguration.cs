using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameConfiguration : MonoBehaviour
{
    public static GameConfiguration Instance;

    public GameObject Player
    {
        get
        {
            return m_player;
        }
    }

    public PlayerRenderer PlayerRenderer
    {
        get
        {
            return m_playerRenderer;
        }
    }

    public PlayerUpgrader PlayerUpgrader
    {
        get
        {
            return m_playerUpgrader;
        }
    }

    [SerializeField] private GameObject m_player;
    private PlayerRenderer m_playerRenderer;
    private PlayerUpgrader m_playerUpgrader;

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

    public void SetPlayer(GameObject p_player)
    {
        m_player = p_player;
        m_playerRenderer = m_player.GetComponent<PlayerRenderer>();
        m_playerUpgrader = m_player.GetComponent<PlayerUpgrader>();
    }
}
