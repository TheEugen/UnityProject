using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;
    public float runSpeed = 40f;
    float horizontalMove = 0f;
    bool jump, crouch, paused;
    Vector2 playerStartPos, cameraStartPos;

    void Start()
    {
        getPlayerCamPos();
    }

    void Update()
    {
        paused = PauseMenu.paused;
        if (!(paused))
        {
            horizontalMove = Input.GetAxis("Horizontal") * runSpeed;
            animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

            if (Input.GetButtonDown("Jump"))
            {
                jump = true;
                animator.SetBool("Jump", true);
            }

            if (Input.GetButtonDown("Crouch"))
                crouch = true;
            else if (Input.GetButtonUp("Crouch"))
                crouch = false;
        }
    }

    private void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }

    public void getPlayerCamPos()
    {
        playerStartPos = GameObject.Find("Player").transform.position;
        cameraStartPos = GameObject.Find("CM vcam1").transform.position;
    }

    public void deathAndReset()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        transform.position = playerStartPos;
        GameObject.Find("CM vcam1").transform.position = cameraStartPos;
    }

    public void onLanding()
    {
        animator.SetBool("Jump", false);
    }

    public void onCrouching(bool isCrouching)
    {
        animator.SetBool("Crouch", isCrouching);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Deathzone")
            animator.Play("Player_Hurt");
        
        if (collision.collider.tag == "Moving")
        {
            if (collision.collider.transform.position.y <= transform.position.y)
                transform.SetParent(collision.collider.transform.parent);
        }

    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Moving")
            transform.SetParent(null);
    }
}
