using System;
using UnityEngine.UI;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class MenuControl : MonoBehaviour, IInteractable
{
    public delegate void NewGame();
    public NewGame newGame;
    public delegate void Setting();
    public Setting setting;
    public delegate void Exit();
    public Exit exit;

    private List<Selectable> _interactableGO;
    IInteractable.interactable _interactable;
    public IInteractable.interactable Interactable => _interactable;

    private void Awake()
    {
        _interactableGO = GetComponentsInChildren<Selectable>().ToList();
        _interactable += InteractableControl;
    }
  

    public void ExitIsClick()
    {
        Interactable?.Invoke(false);
           exit?.Invoke(); 
    }
    public void NewGameIsClick()
    {
        Interactable?.Invoke(false);
        newGame?.Invoke();
    }
    public void SettingIsClick()
    {
        Interactable?.Invoke(false);
        setting?.Invoke();
    }

    public void InteractableControl(bool isInteractable)
    {
        _interactableGO.ForEach(button => button.interactable = isInteractable);
    }
}
