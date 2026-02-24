using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basic_AI : MonoBehaviour
{
    public float movementSpeed = 1f;
    public float patrolSpeed = 0.5f;
    Rigidbody2D rbody;
    IsometricCharacterRenderer isoRenderer;
    private Transform playerTransform;
    private int ATT_DISTANCE = 5;
    private Vector3 startPosition;
    private Vector3[] patrolPoints;
    private bool pointSet;
    private int index;

    void Awake()
    {
        rbody = GetComponent<Rigidbody2D>();
        isoRenderer = GetComponentInChildren<IsometricCharacterRenderer>();
        playerTransform = GameObject.Find("Player_Isometric_Witch").transform;
        startPosition = transform.position;
        patrolPoints = new Vector3[4];
        patrolPoints[0] = new Vector3(transform.position.x + 3, transform.position.y, transform.position.z);
        patrolPoints[1] = new Vector3(transform.position.x - 3, transform.position.y, transform.position.z);
        patrolPoints[2] = new Vector3(transform.position.x, transform.position.y + 3, transform.position.z);
        patrolPoints[3] = new Vector3(transform.position.x, transform.position.y - 3, transform.position.z);
    }

    void Update()
    {
        if (Vector2.Distance(playerTransform.position, rbody.position) < ATT_DISTANCE)
            chasePlayer();
        else
            doPatrol();
    }

    void doPatrol()
    {  
        if (!(pointSet))
            index = Random.Range(0, 3);

        Vector2 movement = (new Vector2(patrolPoints[index].x, patrolPoints[index].y) - rbody.position).normalized * patrolSpeed;
        Vector2 newPos = rbody.position + movement * Time.fixedDeltaTime;
        isoRenderer.SetDirection(movement);
        rbody.MovePosition(newPos);

        if (!(pointSet))
            pointSet = true;

        if (Vector2.Distance(transform.position, patrolPoints[index]) < 0.25f)
            pointSet = false;
    }

    void chasePlayer()
    {
        Vector2 movement = (new Vector2(playerTransform.position.x, playerTransform.position.y) - rbody.position).normalized * movementSpeed;
        Vector2 newPos = rbody.position + movement * Time.fixedDeltaTime;
        isoRenderer.SetDirection(movement);
        rbody.MovePosition(newPos);
    }

}
