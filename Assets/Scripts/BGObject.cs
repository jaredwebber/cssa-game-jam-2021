using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;

public class BGObject : MonoBehaviour
{
    public float speed, spinLimit, sizeLimit;
    private float randSpin, randScale;
    private Vector3 scaleVector;
    private Rigidbody2D rb;
    private Vector2 screenBounds;

    // Start is called before the first frame update
    void Start()
    {
        randSpin = Random.Range(-spinLimit, spinLimit);
        randScale = Random.Range(-sizeLimit, sizeLimit);
        scaleVector = new Vector3(randScale, randScale, 0f);

        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-speed, 0);
        transform.Rotate(new Vector3(0, 0, Random.Range(-100, 100) * spinLimit));
        transform.localScale += scaleVector;
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, randSpin));
        if (transform.position.x < -screenBounds.x * 1.5) Destroy(this.gameObject);
    }

}
