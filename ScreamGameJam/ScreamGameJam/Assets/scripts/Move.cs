using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public GameObject player;
    public float Sens;
    public float Speed;

    private float x;
    private float y;
    private float xM;
    private float yM;
    private RaycastHit hit;
    // Update is called once per frame
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    private void FixedUpdate()
    {
        move();
        look();
        RaySeartch();
    }


    private void RaySeartch()
    {
        if (Physics.Raycast(gameObject.transform.position, transform.forward, out hit, 30))
        {
            if (hit.collider.gameObject.tag == "Interact")
            {
                Debug.DrawRay(gameObject.transform.position, transform.forward * hit.distance, Color.red);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Debug.DrawRay(gameObject.transform.position, transform.forward * hit.distance, Color.green,1);
                    hit.collider.gameObject.GetComponent<IInteractive>().InteractLogic();
                }
            }
        }
    }

    private void look()
    {
        xM -= Input.GetAxis("Mouse Y");
        yM += Input.GetAxis("Mouse X");
        xM *= Sens;
        yM *= Sens;
        transform.localRotation = Quaternion.Euler(xM, 0, 0);
        player.transform.rotation = Quaternion.Euler(0, yM, 0);
    }

    private void move()
    {
        x = Input.GetAxis("Vertical");
        y = Input.GetAxis("Horizontal");
        player.transform.position += player.transform.forward * x * Speed;
        player.transform.position += player.transform.right * y * Speed;
    }
}
