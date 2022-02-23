using UnityEngine;


public class MultipleObjectSetActiveEventLogic : EventLogic
{
    public GameObject[] GameObjects;
    public bool Enable;
    public override void Logic()
    {
        for (int i = 0; i < GameObjects.Length; i++)
        {
            GameObjects[i].SetActive(Enable);
        }
    }
}
