using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    Rigidbody2D rbody;
    public float movementSpeed = 2f;
    public float offset_x = 6f;
    float m_MovementSmoothing = .05f;
    Vector2 m_Velocity = Vector2.zero;
    Vector2 startPosition, targetVelocity, destination;
    int invert = -1;


    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        startPosition = transform.position;
        destination = new Vector2(transform.position.x - offset_x, transform.position.y);
    }

    void FixedUpdate()
    {
        if (transform.position.x > startPosition.x + offset_x + 2 || transform.position.x < startPosition.x - offset_x - 2)
            transform.position = startPosition;

        targetVelocity = new Vector2(movementSpeed * invert, rbody.velocity.y);

        if (transform.position.y < startPosition.y)
            targetVelocity.y = 2f;
        else
            targetVelocity.y = 0;

        if (Vector2.Distance(rbody.position, destination) < 0.1f)
        {
            invert *= -1;
            destination.x += offset_x * 2 * invert;
        }

        rbody.velocity = Vector2.SmoothDamp(rbody.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);
    }
}
