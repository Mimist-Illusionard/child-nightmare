
public class Tv : InteractiveItem
{
    public override bool IsInteractiveByPlayer { get; set; }

    public override void Initialize()
    {
        IsInteractiveByPlayer = false;
    }

    public override void InteractLogic()
    {
        UnityEngine.Debug.LogWarning("TelevisorLogic");
    }

    public override void BlockedInteractLogic()
    {

    }
}
