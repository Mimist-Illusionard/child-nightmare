using UnityEngine;


public class TeleportSystem : MonoBehaviour
{
    public Player Player;
    public Transform SpawnPoint;

    public void RefreshPlayerPosition()
    {
        Player.GetComponent<CharacterController>().enabled = false;
        Player.transform.position = SpawnPoint.position;
        Player.GetComponent<CharacterController>().enabled = true;
    }
}