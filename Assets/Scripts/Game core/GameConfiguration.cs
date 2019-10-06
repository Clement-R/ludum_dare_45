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
    [SerializeField] private GameObject m_player;

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
    }
}
