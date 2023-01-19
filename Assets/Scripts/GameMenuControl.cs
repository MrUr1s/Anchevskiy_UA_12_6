using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GameMenuControl : MonoBehaviour, IInteractable
{
    public delegate void d_ContinueGame();
    public d_ContinueGame continueGame;
    public delegate void d_ResetGame();
    public d_ResetGame resetGame;
    public delegate void d_Exit();
    public d_Exit exit;

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

    public void ContinueGameIsClick()
    {
        Interactable?.Invoke(false);
        continueGame?.Invoke();
    }

    public void ResetGame()
    {
        Interactable?.Invoke(false);
        resetGame?.Invoke();
    }

    public void InteractableControl(bool isInteractable)
    {
        _interactableGO.ForEach(button => button.interactable = isInteractable);
    }
}
