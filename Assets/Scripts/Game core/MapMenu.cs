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

    [Header("Levels")]
    [SerializeField] private List<MapMenuLevel> m_levels;

    [Header("Days")]
    [SerializeField] private TMPro.TextMeshProUGUI m_days;

    private void Start()
    {
        // Display current game state
        UpdateUI();

        // Listen to all events of level finished
        GameConfiguration.Instance.PlayerUpgrader.OnUpgrade += UpgradeEffect;
        GameOrchestrator.Instance.OnLevelCleared += LevelCleared;
    }

    private void OnDestroy()
    {
        GameConfiguration.Instance.PlayerUpgrader.OnUpgrade -= UpgradeEffect;
        GameOrchestrator.Instance.OnLevelCleared -= LevelCleared;
    }

    public void LevelClicked(Level p_level)
    {
        GameOrchestrator.Instance.LaunchLevel(p_level);
    }

    private void UpdateUI()
    {
        // Show upgrades
        int maxUpgrade = GameConfiguration.Instance.PlayerUpgrader.MaxUpgrade;
        DisplayUpgrades(m_powerFirstPosition, GameConfiguration.Instance.PlayerUpgrader.Power, maxUpgrade);
        DisplayUpgrades(m_speedFirstPosition, GameConfiguration.Instance.PlayerUpgrader.Speed, maxUpgrade);
        DisplayUpgrades(m_armorFirstPosition, GameConfiguration.Instance.PlayerUpgrader.Armor, maxUpgrade);

        // Cross finished levels
        CrossFinishedLevels();

        m_days.text = GameOrchestrator.Instance.Day.ToString();
    }

    private void CrossFinishedLevels()
    {
        foreach (MapMenuLevel level in m_levels)
        {
            if (GameOrchestrator.Instance.FinishedLevels.Exists(l => level.Level.ID == l.ID))
            {
                //TODO: Cross level
                level.UIElement.alpha = 0.5f;
                level.UIElement.interactable = false;
            }
        }
    }

    private void DisplayUpgrades(RectTransform p_startPosition, int p_stat, int p_max)
    {
        Vector2 nextPosition = p_startPosition.anchoredPosition;
        Vector2 margin = new Vector2(m_horizontalMargin, m_verticalMargin);

        for (int i = 1; i <= p_max; i++)
        {
            GameObject obj;
            if (i <= p_stat)
                obj = Instantiate(m_filledUpgrade, this.transform);
            else
                obj = Instantiate(m_emptyUpgrade, this.transform);

            RectTransform rect = obj.GetComponent<RectTransform>();
            rect.anchoredPosition = nextPosition;

            nextPosition += margin;
        }
    }

    private void LevelCleared(Level p_level)
    {
        StartCoroutine(_LevelCleared(p_level));
    }

    private IEnumerator _LevelCleared(Level p_level)
    {
        yield return new WaitForSeconds(0.75f);

        MapMenuLevel level = m_levels.Find(l => l.Level.ID == p_level.ID);
        level.UIElement.alpha = 0.5f;
        level.UIElement.interactable = false;

        yield return new WaitForSeconds(0.25f);

        m_days.text = GameOrchestrator.Instance.Day.ToString();

        //TODO: Juice it!
    }

    private void UpgradeEffect(EStats p_stat)
    {
        StartCoroutine(_UpgradeEffect(p_stat));
    }

    private IEnumerator _UpgradeEffect(EStats p_stat)
    {
        yield return new WaitForSeconds(1.25f);

        int maxUpgrade = GameConfiguration.Instance.PlayerUpgrader.MaxUpgrade;
        DisplayUpgrades(m_powerFirstPosition, GameConfiguration.Instance.PlayerUpgrader.Power, maxUpgrade);
        DisplayUpgrades(m_speedFirstPosition, GameConfiguration.Instance.PlayerUpgrader.Speed, maxUpgrade);
        DisplayUpgrades(m_armorFirstPosition, GameConfiguration.Instance.PlayerUpgrader.Armor, maxUpgrade);

        //TODO: Juice it!
    }
}