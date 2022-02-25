using UnityEngine;


public class TeleportSystem : MonoBehaviour
{
    public Player Player;
    public Transform SpawnPoint;

    public void RefreshPlayerPosition()
    {
        Player.GetComponent<CharacterController>().enabled = false;
        Player.gameObject.transform.rotation = SpawnPoint.rotation;
        Player.transform.position = SpawnPoint.position;
        Camera.main.transform.rotation = SpawnPoint.rotation;
        Player.GetComponent<CharacterController>().enabled = true;
    }
}