using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class PopupsManager : MonoBehaviour
{
    public static PopupsManager Instance;

    [SerializeField] private List<PopupData> m_popups;

    private PopupData p_visiblePopup = null;

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

    public void ShowPopup(EPopup p_popup, Action p_onValidate = null, Action p_onCancel = null)
    {
        PopupData popupData = m_popups.Find(p => p.Type == p_popup);
        popupData.Popup.alpha = 1f;
        popupData.Popup.interactable = true;
        popupData.Popup.blocksRaycasts = true;

        if (p_onValidate != null && popupData.OkButton != null)
        {
            popupData.OkButton.onClick.AddListener(() =>
            {
                p_onValidate?.Invoke();
            });
        }

        if (p_onCancel != null && popupData.CancelButton != null)
        {
            popupData.CancelButton.onClick.AddListener(() =>
            {
                p_onCancel?.Invoke();
            });
        }
    }

    public void ClosePopup()
    {
        p_visiblePopup.Popup.alpha = 0f;
        p_visiblePopup.Popup.interactable = false;
        p_visiblePopup.Popup.blocksRaycasts = false;

        if (p_visiblePopup.OkButton != null)
        {
            p_visiblePopup.OkButton.onClick.RemoveAllListeners();
        }

        if (p_visiblePopup.CancelButton != null)
        {
            p_visiblePopup.CancelButton.onClick.RemoveAllListeners();
        }

        p_visiblePopup = null;
    }
}