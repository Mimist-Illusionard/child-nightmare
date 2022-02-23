using UnityEngine;


[RequireComponent(typeof(Light))]
public class FlashLightEventLogic : EventLogic
{
    public Light Light => GetComponent<Light>();
    public float Intencity;

    public override void Logic()
    {
        Light.intensity = Intencity;
        TimerManager.Singleton.StartTimer(0.1f, () => Light.intensity = 0f);
    }
}
