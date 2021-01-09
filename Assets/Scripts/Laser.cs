using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{

    public Vector3 screenBounds;

    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //kill enemy & spawn platform?
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
