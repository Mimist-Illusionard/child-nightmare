using UnityEngine;


public abstract class Interactive : MonoBehaviour, IInteractive
{
    public void Start()
    {
        Initialize();
    }

    public abstract bool IsInteractiveByPlayer { get; set; }

    public abstract void InteractLogic();
    public abstract void Initialize();
}
