using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StompingPillar : MonoBehaviour
{
    public PlayerMovement p_movement;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
            p_movement.deathAndReset();
    }
}
