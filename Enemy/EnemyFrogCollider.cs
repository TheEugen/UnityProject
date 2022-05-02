using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFrogCollider : MonoBehaviour
{
    public PlayerMovement p_movement;
    bool destroyed, grounded;
    Rigidbody2D rbody;
    float jumpforce = 900f;
    int invert = -1;
    Animator animator;

    private void Start()
    {
        rbody = transform.parent.GetComponent<Rigidbody2D>();
        animator = transform.parent.GetComponentInChildren<Animator>();
    }

    private void FixedUpdate()
    {
        if (grounded)
            rbody.AddForce(new Vector2(jumpforce*invert/3, jumpforce)); grounded = false; animator.SetBool("Jump", true);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
            Destroy(transform.parent.gameObject); destroyed = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        grounded = true;
        animator.SetBool("Jump", false);
        invert *= -1;
        transform.parent.Rotate(0f, 180f, 0f);
        if (collision.collider.tag == "Player" && !(destroyed))
            p_movement.deathAndReset();
    }

    public void Die()
    {
        rbody.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
        animator.SetBool("Dead", true);
    }

}
