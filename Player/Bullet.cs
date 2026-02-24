using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rbody;
    public GameObject bulletHit;

    void Start()
    {
        rbody.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Enemy")
        {
            var enemy = collider.GetComponent<EnemyFrogCollider>();
            enemy.Die();
        }

        Instantiate(bulletHit, transform.position, transform.rotation);
        Destroy(gameObject);
    }

}
