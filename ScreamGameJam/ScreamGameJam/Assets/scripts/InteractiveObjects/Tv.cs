
public class Tv : Interactive
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
}
