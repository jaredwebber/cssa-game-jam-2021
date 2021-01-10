using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public Camera cam;

    Vector2 movement;
    Vector2 mousePos;

    private float jumpSpeed;


    // Update is called once per frame

    void Start()
    {
        jumpSpeed = 4f;
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }
    void Update()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        movement.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        Vector2 fixedMousePos;
        fixedMousePos.x = mousePos.x;
        fixedMousePos.y = mousePos.y-0.40f;

        Vector2 lookDirection = fixedMousePos - rb.position;
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
        rb.rotation = angle;

        
        rb.MovePosition(rb.position + movement * jumpSpeed * Time.fixedDeltaTime);
    }


}

