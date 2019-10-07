using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRenderer : MonoBehaviour
{
    [SerializeField] private SpriteRenderer m_renderer;

public void Show()
    {
        m_renderer.enabled = true;
    }

    public void Hide()
    {
        m_renderer.enabled = false;
    }
}
