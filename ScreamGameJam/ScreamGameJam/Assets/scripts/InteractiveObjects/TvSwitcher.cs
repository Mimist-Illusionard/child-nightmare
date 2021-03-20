using UnityEngine;


public class TvSwitcher : Interactive
{
    [SerializeField] private Interactive _tv;

    public override bool IsInteractiveByPlayer { get; set; }

    public override void Initialize()
    {
        IsInteractiveByPlayer = true;
    }

    public override void InteractLogic()
    {
        _tv.InteractLogic();
    }
}

