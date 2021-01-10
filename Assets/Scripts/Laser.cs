using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    private Vector3 screenBounds;
    private Animator animator;

    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        animator.SetBool("laser_hit", false);
        gameObject.name = "LASER";
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        animator.SetBool("laser_hit", true);
        //Destroy(gameObject);
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
