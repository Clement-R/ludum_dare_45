using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class PlayerRenderer : MonoBehaviour
{
    [SerializeField] private List<SpriteRenderer> m_renderers;

    public void Show()
    {
        foreach (var renderer in m_renderers)
        {
            renderer.enabled = true;
        }
    }

    public void Hide()
    {
        foreach (var renderer in m_renderers)
        {
            renderer.enabled = false;
        }
    }
}