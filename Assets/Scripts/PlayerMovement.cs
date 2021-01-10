using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public Camera cam;

    Vector2 movement;
    Vector2 mousePos;

    private float jumpSpeed;
    private Vector2 jump;
    private int collisionCount;
    private Vector2 screenBounds;
    private bool canJump = false;
    private bool notOnCooldown = true;

    // Update is called once per frame

    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

        jumpSpeed = 4.0f;
        jump = new Vector2(0f, 10.0f);
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }
    void Update()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        movement.y = Input.GetAxisRaw("Vertical");

        /*
        if(collisionCount > 0 && Input.GetKeyDown(KeyCode.UpArrow))
        {
            rb.AddForce(jump * jumpSpeed, ForceMode2D.Impulse);
        }*/

        if (transform.position.y < -screenBounds.y)
            SceneManager.LoadScene("EndGame");
    }

    void FixedUpdate()
    {
        Vector2 fixedMousePos;
        fixedMousePos.x = mousePos.x;
        fixedMousePos.y = mousePos.y-0.40f;

        Vector2 lookDirection = fixedMousePos - rb.position;
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
        rb.rotation = angle;

        if (collisionCount > 0 || (canJump && notOnCooldown))
        {
            rb.gravityScale = 0;
            rb.MovePosition(rb.position + movement * jumpSpeed * Time.fixedDeltaTime);
        }            
        else{
            rb.gravityScale = 9.8f;
            rb.MovePosition(rb.position + movement * jumpSpeed/6 * Time.fixedDeltaTime);
        }

            
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "platform")
        {
            collisionCount++;
            Debug.Log(collisionCount);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "platform")
        {
            collisionCount--;
            Debug.Log(collisionCount);
            StartCoroutine(wasSwimming());
        }
    }

    IEnumerator wasSwimming()
    {
        canJump = true;
        yield return new WaitForSeconds(0.6f);
        canJump = false;
        StartCoroutine(startCooldown());
    }

     IEnumerator startCooldown()
    {
        notOnCooldown = false;
        yield return new WaitForSeconds(2f);
        notOnCooldown = true;
    }

}

