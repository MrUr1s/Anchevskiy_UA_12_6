using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class SettingManager : MonoBehaviour,IInteractable
{
    public delegate void Back();
    public Back back;
    [SerializeField,Range(0f, 1f)]
    private float _volume;
    [SerializeField]
    private bool _isSound;
    [SerializeField]
    private ToggleGroup _difficulty;
    private Slider _volumeSlider;

    private List<Selectable> _buttons;
    private IInteractable.interactable _interactable;
    public float Volume { get => _volume;
       private set
        {
            _volume = value;
            if (_volume < 0)
                _volume = 0;
            else if(_volume > 1)
                _volume = 1;
        }
    }

    public IInteractable.interactable Interactable => _interactable;

    private void Awake()
    {
        _interactable += InteractableControl;
        _buttons = GetComponentsInChildren<Selectable>().ToList();
        _difficulty = GetComponentInChildren<ToggleGroup>();
        _volumeSlider = GetComponentInChildren<Slider>();
        LoadSetting();
    }
    public void BackIsClick()
    {
        back?.Invoke();
    }

    public void SaveSetting()
    {

    }
    public void LoadSetting()
    {
        SoundChanged(true);
        VolumeChanged();
    }
    public void SoundChanged(bool IsSound)=>_isSound=IsSound;
    public void VolumeChanged()
    {
        Volume = _volumeSlider.value;
    }

    public void InteractableControl(bool isInteractable)
    {
        _buttons.ForEach(button => button.interactable = isInteractable);
    }
}
