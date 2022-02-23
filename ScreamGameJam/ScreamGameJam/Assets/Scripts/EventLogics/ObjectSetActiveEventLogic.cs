using UnityEngine;


public class ObjectSetActiveEventLogic : EventLogic
{
    public GameObject Object;
    public bool Enable;
    public override void Logic()
    {
        Object.SetActive(Enable);
    }
}
