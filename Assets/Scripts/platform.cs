using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platform : MonoBehaviour
{
    private Vector3 screenBounds;
    private Vector2 position;
    private float speed;

    void Start()
    {

        speed = 10;
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        position.x = transform.position.x;
        position.y = transform.position.y;

        //Physics.IgnoreCollision(enemy.GetComponent<Collider>(), GetComponent<Collider>());
    }

    // Update is called once per frame
    void Update()
    {
         if (transform.position.x < -screenBounds.x * 1.5 ||
            transform.position.x >  screenBounds.x * 1.5) 
        {
            Destroy(this.gameObject);
        }

        position.x -= speed;

    }
}
