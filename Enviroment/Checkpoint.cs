using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public PlayerMovement p_movement;
    bool triggered;

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (!(triggered))
        {
            if (collider.tag == "Player")
            {
                p_movement.getPlayerCamPos();
                triggered = true;
            }
        }
    }
}
