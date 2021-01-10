using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject laserPrefab;

    public float laserForce = 20f;

    public AudioSource audioSource;
    public AudioClip shootSound;

    const int COOLDOWN_TICKS = 90;
    static int fireCooldown = 0;

    void Update()
    {
        if(Input.GetButtonDown("Fire1") && fireCooldown == 0)
        {
            fireCooldown = COOLDOWN_TICKS;
            Shoot();
        }

        if (fireCooldown > 0) fireCooldown--;
    }

    void Shoot()
    {
        GameObject laser = Instantiate(laserPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = laser.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.right * laserForce, ForceMode2D.Impulse);


        // Play laser sound
        audioSource.PlayOneShot(shootSound, 0.5f);        
    }
    

}
