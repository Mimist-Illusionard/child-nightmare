using UnityEngine;


public class TvSwitcher : InteractiveItem
{
    [SerializeField] private InteractiveItem _tv;

    public override bool IsInteractiveByPlayer { get; set; }

    public override void Initialize()
    {
        IsInteractiveByPlayer = true;
    }

    public override void InteractLogic()
    {
        _tv.InteractLogic();
    }
    public override void BlockedInteractLogic()
    {

    }
}

