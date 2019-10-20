using System;

using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class PopupData
{
    public EPopup Type;
    public CanvasGroup Popup;
    public Button OkButton;
    public Button CancelButton;
}