using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public float speed = 10.0f;
    private float platformSpeed = 10f;
    private Rigidbody2D rb;
    private Vector2 screenBounds;

    public GameObject platformPrefab;

    private Rigidbody2D enemyBody;

    private Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        enemyBody = GetComponent<Rigidbody2D>();
        gameObject.name = "ENEMY";
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        animator = gameObject.GetComponent<Animator>();
        animator.SetBool("enemyDeath", false);
    }
     
    void OnCollisionEnter2D(Collision2D collision)
    {         
        if(collision.collider.name == "LASER")
        {
            this.enemyBody.constraints = RigidbodyConstraints2D.FreezePositionY;
            this.enemyBody.constraints = RigidbodyConstraints2D.FreezePositionX;
            this.enemyBody.constraints = RigidbodyConstraints2D.FreezeRotation;
            this.enemyBody.gravityScale = 0;
            this.enemyBody.mass = 99999999;//makes inertia/momentum of lazer shot inconsequential
            
            animator.SetBool("enemyDeath", true);            
            //Destroy(gameObject);
            //makePlatform();
        }
            
    }

    // Update is called once per frame
    void Update()
    {
        if ((transform.position.x < -screenBounds.x * 1.5) || transform.position.y < -screenBounds.y * 1.5)
        {
            Destroy(gameObject);
        }

       
    }

    void makePlatform()
    {
        GameObject platform = Instantiate(platformPrefab, transform.position, Quaternion.identity);
        Rigidbody2D rbp = platform.GetComponent<Rigidbody2D>();
        rbp.AddForce(transform.up * platformSpeed, ForceMode2D.Impulse);
    }

}
