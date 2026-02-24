using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinkingPillar : MonoBehaviour
{
    Animator animator;

    private void Start()
    {
        animator = transform.parent.GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
            animator.Play("M_Sinking_Pillar_4");
    }
}
