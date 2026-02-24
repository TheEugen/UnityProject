using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsometricPlayerMovement : MonoBehaviour
{
    public float movementSpeed = 2f;
    Rigidbody2D rbody;
    IsometricCharacterRenderer isoRenderer;
    public InventoryObject inventory;
    public PlayerAttributesObject attributes;

    private void Awake()
    {
        rbody = GetComponent<Rigidbody2D>();
        isoRenderer = GetComponentInChildren<IsometricCharacterRenderer>();
    }

    public void OnCollisionStay2D(Collision2D collision)
    {
        var item = collision.collider.GetComponent<Item>();
        if (item && Input.GetKeyDown(KeyCode.E))
        {
            inventory.addItem(item.item, 1);
            Destroy(collision.collider.gameObject);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        var ai = collision.collider.GetComponentInParent<Basic_AI>();
        if (ai)
            attributes.changeCurrentHp(-1);
    }

    private void OnApplicationQuit()
    {
        System.Array.Clear(inventory.i_slots, 0, inventory.i_slots.Length);
    }
 
    void FixedUpdate()
    {
        Vector2 currentPos = rbody.position;
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector2 inputVector = new Vector2(horizontalInput, verticalInput);
        inputVector = Vector2.ClampMagnitude(inputVector, 1);
        Vector2 movement = inputVector * movementSpeed;
        Vector2 newPos = currentPos + movement * Time.fixedDeltaTime;
        isoRenderer.SetDirection(movement);
        rbody.MovePosition(newPos);
    }
}
