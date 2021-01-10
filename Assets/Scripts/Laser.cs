using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    private Vector3 screenBounds;
    private Animator animator;

    private Rigidbody2D laserShape;

    void Start()
    {
        laserShape = GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
        animator.SetBool("laser_hit", false);
        gameObject.name = "LASER";
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    IEnumerator pauseForAnimation()
    {
        animator.SetBool("laser_hit", true);
        yield return new WaitForSeconds(0.4f);
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        /* Avoids Laser Shards Flying off on impact
        this.laserShape.constraints = RigidbodyConstraints2D.FreezePositionY;
        this.laserShape.constraints = RigidbodyConstraints2D.FreezePositionX;
        this.laserShape.constraints = RigidbodyConstraints2D.FreezeRotation;
        */
        StartCoroutine(pauseForAnimation());
    }

    void Update(){
        if (transform.position.y < -screenBounds.y * 1.5 ||
            transform.position.x < -screenBounds.x * 1.5 ||
            transform.position.y >  screenBounds.y * 1.5 ||
            transform.position.x >  screenBounds.x * 1.5) 
        {
            Destroy(this.gameObject);
        }
    }


}
