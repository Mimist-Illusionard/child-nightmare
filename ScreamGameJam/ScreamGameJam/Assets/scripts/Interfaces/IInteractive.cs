public interface IInteractive
{
    bool IsInteractiveByPlayer { get; set; }

    void InteractLogic();
    void BlockedInteractLogic();
}
