using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    Rigidbody2D rb;
    float speed = 10f;
    float jumpForce = 300;
    bool canJump = true;
    private GameObject gameobj;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        float xAxis = Input.GetAxis("Horizontal");
        Vector2 move = new Vector2(xAxis, 0);

        transform.Translate(move * speed * Time.deltaTime);
         
        if(xAxis != 0)
        {
            GetComponent<Animator>().SetBool("isWalking", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("isWalking", false);

        }

        if (xAxis < 0)
        {
            this.gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (xAxis > 0)
        {
            this.gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }

        if(Input.GetKeyDown(KeyCode.Space) & canJump)
        {
            this.gameObject.GetComponent<AudioSource>().Play();
            rb.AddForce(Vector2.up * jumpForce);
            speed = 6f;
            canJump = false;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform" || collision.gameObject.layer == 6)
        {
            canJump = true;
            speed = 10f;
        }
        
    }
}
