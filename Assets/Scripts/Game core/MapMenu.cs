using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapMenu : MonoBehaviour
{
    [Header("Upgrades")]
    [SerializeField] private GameObject m_emptyUpgrade;
    [SerializeField] private GameObject m_filledUpgrade;
    [SerializeField] private float m_horizontalMargin;
    [SerializeField] private float m_verticalMargin;

    [Header("Upgrades positions")]
    [SerializeField] private RectTransform m_powerFirstPosition;
    [SerializeField] private RectTransform m_speedFirstPosition;
    [SerializeField] private RectTransform m_armorFirstPosition;

    private void Start()
    {
        // Display current game state
        UpdateUI();

        //TODO: Listen to all events of level finished    
    }

    public void LevelClicked(Level p_level)
    {
        GameOrchestrator.Instance.LaunchLevel(p_level);
    }

    private void UpdateUI()
    {
        //TODO: Implement

        // Show upgrades
        int maxUpgrade = GameConfiguration.Instance.PlayerUpgrader.MaxUpgrade;
        DisplayUpgrades(m_powerFirstPosition, GameConfiguration.Instance.PlayerUpgrader.Power, maxUpgrade);
        DisplayUpgrades(m_speedFirstPosition, GameConfiguration.Instance.PlayerUpgrader.Speed, maxUpgrade);
        DisplayUpgrades(m_armorFirstPosition, GameConfiguration.Instance.PlayerUpgrader.Armor, maxUpgrade);

        // Cross level done
        // Cross level and set is as not-playable
    }

    private void DisplayUpgrades(RectTransform p_startPosition, int p_stat, int p_max)
    {
        Vector2 nextPosition = p_startPosition.anchoredPosition;
        Vector2 margin = new Vector2(m_horizontalMargin, m_verticalMargin);

        for (int i = 1; i <= p_max; i++)
        {
            GameObject obj;
            if(i <= p_stat)
                obj = Instantiate(m_filledUpgrade, this.transform);
            else
                obj = Instantiate(m_emptyUpgrade, this.transform);

            RectTransform rect = obj.GetComponent<RectTransform>();
            rect.anchoredPosition = nextPosition;

            nextPosition += margin;
        }
    }
}
