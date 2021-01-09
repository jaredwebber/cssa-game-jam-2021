using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public float speed = 10.0f;
    private Rigidbody2D rb;
    private Vector2 screenBounds;

    public GameObject platformPrefab;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.name = "ENEMY";
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    void OnCollisionEnter2D(Collision2D collision)
    {         
        if(collision.collider.name == "LASER")
        {
            Destroy(gameObject);
            makePlatform();
        }
            
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -screenBounds.x * 1.5) Destroy(this.gameObject);
    }

    void makePlatform()
    {
        GameObject platform = Instantiate(platformPrefab, transform.position, Quaternion.identity);
        Rigidbody2D rb = platform.GetComponent<Rigidbody2D>();
        //Physics.IgnoreCollision(platform.GetComponent<Collider>(), GetComponent<Collider>());

    }

}
