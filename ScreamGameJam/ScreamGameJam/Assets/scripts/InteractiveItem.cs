using UnityEngine;


public abstract class InteractiveItem : MonoBehaviour, IInteractive
{
    public void Start()
    {
        Initialize();
    }

    public abstract bool IsInteractiveByPlayer { get; set; }

    public abstract void InteractLogic();
    public abstract void BlockedInteractLogic();
    public abstract void Initialize();  
}
