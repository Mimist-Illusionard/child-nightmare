using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSettings : MonoBehaviour
{
    private GameObject Player;
    private AudioSource source;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        source = GetComponent<AudioSource>();
        GameObject.FindGameObjectWithTag("GameController").GetComponent<AuDIOController>().audios.Add(this);
    }

    public void AllVoids()
    {
        WallsError();
    }

    private void WallsError()
    {
        RaycastHit hit;
        if (Physics.Linecast(gameObject.transform.position,Player.transform.position,out hit))
        {
            if (hit.collider.tag == "Player")
            {
                source.minDistance = 1f;
            }
            else
            {
                source.minDistance = 0.2f;
            }
        }
    }
}
