using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class PopupsManager : MonoBehaviour
{
    public static PopupsManager Instance;

    [SerializeField] private List<PopupData> m_popups;

    private CanvasGroup p_visiblePopup = null;

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
        DontDestroyOnLoad(gameObject);
    }

    public void ShowPopup(EPopup p_popup)
    {
        PopupData popupData = m_popups.Find(p => p.Type == p_popup);
        popupData.Popup.alpha = 1f;
        popupData.Popup.interactable = true;
    }

    public void ClosePopup()
    {
        p_visiblePopup.alpha = 0f;
        p_visiblePopup.interactable = false;
        p_visiblePopup = null;
    }
}