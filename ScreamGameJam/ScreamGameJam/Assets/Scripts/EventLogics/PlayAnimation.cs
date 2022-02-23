using UnityEngine;


public class PlayAnimation : EventLogic
{
    public Animation Animation;
    public override void Logic()
    {
        Animation.Play();
    }
}
