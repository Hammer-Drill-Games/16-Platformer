using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Movement : MonoBehaviour {
    private Rigidbody2D rb;
    public float speed = 10f;
    public float jumpForce = 300f;
    public bool canJump = true;
    
    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update() {
        float xAxis = Input.GetAxis("Horizontal");
        Vector2 move = new(xAxis, 0);
        
        transform.Translate(move * speed * Time.deltaTime);

        if(Input.GetKeyDown(KeyCode.Space) & canJump)
        {
            // this.gameObject.GetComponent<AudioSource>().Play();
            rb.AddForce(Vector2.up * jumpForce);
            speed = 6f;
            canJump = false;
        }
    }

        
    private void OnTriggerEnter2D(Collider2D other){
        print("Collided with " + other.gameObject.name);
        if(other.gameObject.CompareTag("Ground")) { // turns out using "==" is not the best way to compare tags
            canJump = true;
            speed = 10f;
        }
    }
}
