using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Movement : MonoBehaviour {
    private Rigidbody2D rb;
    public float speed = 10f;
    public float maxVelocity = 10f;
    public float jumpForce = 300f;
    public bool canJump = true;
    public ParticleSystem dust;
    
    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update() {
        float xAxis = Input.GetAxis("Horizontal");
        float yAxis = rb.velocity.y;
        Vector2 move = new Vector2(xAxis * speed, yAxis);
        
        rb.velocity += new Vector2(move.x * Time.deltaTime, 0);
        rb.velocity = new Vector2(Mathf.Clamp(rb.velocity.x, -maxVelocity, maxVelocity), rb.velocity.y);
        
        if(xAxis == 0 || yAxis != 0) {
            dust.Stop();
        } else if(xAxis < 0 && yAxis == 0) {
            if(dust.isStopped){
                dust.Play();
            }
            dust.transform.rotation = new Quaternion(0, 0, 0, 0);
        } else if(xAxis > 0 && yAxis == 0) {
            if(dust.isStopped){
                dust.Play();
            }
            dust.transform.rotation = new Quaternion(0, 180, 0, 0);
        }

        if(Input.GetKeyDown(KeyCode.Space) & canJump)
        {
            // this.gameObject.GetComponent<AudioSource>().Play();
            rb.AddForce(Vector2.up * jumpForce);
            speed = 6f;
            canJump = false;
        }
    }

        
    private void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.CompareTag("Ground")) { // turns out using "==" is not the best way to compare tags
            canJump = true;
            speed = 10f;
        }
    }
}
