using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.EventSystems;

using TMPro;

public class TooltipDisplay : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Transform m_tooltip;
    [SerializeField] private string m_textInfo = "Some text explaining things";

    [SerializeField] private CanvasGroup m_tooltipGroup;
    [SerializeField] private TextMeshProUGUI m_tooltipText;

    private bool m_pointerOver = false;

    public void OnPointerEnter(PointerEventData eventData)
    {
        m_tooltip.transform.SetAsLastSibling();
        m_tooltipText.text = m_textInfo;

        m_pointerOver = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        m_tooltipGroup.alpha = 0f;

        m_pointerOver = false;
    }

    private void Update()
    {
        if (m_pointerOver)
        {
            if (m_tooltipGroup.alpha == 0f)
                m_tooltipGroup.alpha = 1f;

            m_tooltip.position = Input.mousePosition;
        }
    }
}