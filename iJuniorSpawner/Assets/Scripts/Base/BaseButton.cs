using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
[RequireComponent(typeof(Image))]
public class BaseButton : BaseMonoBehaviour
{
    #region Fields

    private Button _button;
    private Image _image;
    private TextMeshProUGUI _text;
    private event Action _action = default;

    #endregion

    #region Properties

    public Color ClrThis
    {
        private set
        {
            _image.color = value;
        }
        get
        {
            return _image.color;
        }
    }
    
    #endregion

    #region UnityLifeCycleMethods

    private void OnDestroy()
    {
        _button.onClick.RemoveAllListeners();
    }

    #endregion

    #region Methods

    public void Init(Action action, string text="")
    {
        Initialize();
        AddListener(action);
        SetText(text);
    }

    private void Initialize()
    {
        _button = GetComponent<Button>();
        _image = GetComponent<Image>();
        _text = GetComponentInChildren<TextMeshProUGUI>();
    }

    private void AddListener(Action action)
    {
        _action = action;
        _button.onClick.AddListener(() => { _action?.Invoke();});
    }

    private void SetText(string text)
    {
        if (text != "")
        {
            _text.text = text;
        }
        
    }

    public void SetButtonColor(Color color)
    {
        ClrThis = color;
    }


    #endregion
}
