using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    Animator animator;
    bool paused;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        paused = PauseMenu.paused;

        if (!(paused))
        {
            if (Input.GetButtonDown("Fire1"))
            {
                animator.Play("Player_Shoot");
                Shoot();
            }
        }
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
