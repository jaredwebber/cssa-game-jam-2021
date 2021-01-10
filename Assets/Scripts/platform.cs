using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platform : MonoBehaviour
{
    private Vector3 screenBounds;
    private Vector2 position;
    private Rigidbody2D rb;
    private float speed;

    void Start()
    {

        speed = 3.5f;
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-speed, 0);
    }

    // Update is called once per frame
    void Update()
    {
         if (transform.position.x < -screenBounds.x * 2 ||
            transform.position.x >  screenBounds.x * 2) 
        {
            Destroy(this.gameObject);
        }
    }
}
