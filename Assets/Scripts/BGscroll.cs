using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;

public class BGscroll : MonoBehaviour
{
    private float length, startpos, time, speed;
    public GameObject cam;
    
    // Start is called before the first frame update
    void Start()
    {
        speed = 0.01f;
        startpos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        time += 1;
        float temp = (cam.transform.position.x * (1 - speed));
        float dist = (startpos - (time * speed));

        transform.position = new Vector3(dist, transform.position.y, transform.position.z);
        if (dist < -1 * length) startpos += 2 * length;
        //else if (temp < startpos - length) startpos -= length;
    }
}
