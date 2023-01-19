public interface IInteractable
{
    public delegate void interactable(bool isInteractable);
    public void InteractableControl(bool isInteractable);

    public interactable Interactable { get;}
}