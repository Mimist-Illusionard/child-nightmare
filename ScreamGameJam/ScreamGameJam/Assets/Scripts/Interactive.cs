using UnityEngine.Events;

public class Interactive : EventLogic
{
    public UnityEvent OnInteract;
 
    private bool IsInteracted = false;

    public override void Logic()
    {
        if (IsInteracted) return;

        OnInteract?.Invoke();
        IsInteracted = true;
    }
}