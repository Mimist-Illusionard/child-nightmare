using UnityEngine;


public class TeleportSystem : MonoBehaviour
{
    public Player Player;
    public Transform SpawnPoint;

    public void RefreshPlayerPosition()
    {
        Player.GetComponent<CharacterController>().enabled = false;
        Player.gameObject.transform.rotation = new Quaternion(0f, 180f, 0f, 0f);
        Player.transform.position = SpawnPoint.position;
        Player.GetComponent<CharacterController>().enabled = true;
    }
}