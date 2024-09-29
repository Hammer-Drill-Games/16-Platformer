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
    private ParticleSystem dust;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private AudioSource jump;
    
    void Start() {
        rb = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        dust = gameObject.GetComponentInChildren<ParticleSystem>();
        jump = gameObject.GetComponent<AudioSource>();
    }

    void Update() {
        float xAxis = Input.GetAxis("Horizontal");
        float yAxis = rb.velocity.y;
        
        rb.velocity += new Vector2(xAxis * speed * Time.deltaTime, 0);
        rb.velocity = new Vector2(Mathf.Clamp(rb.velocity.x, -maxVelocity, maxVelocity), yAxis);

        if (xAxis < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (xAxis > 0)
        {
            spriteRenderer.flipX = false;
        }

        if(xAxis == 0 || !canJump) {
            dust.Stop();
            animator.SetBool("isWalking", false);
        } else if(xAxis < 0 && canJump) {
            if(dust.isStopped){
                dust.Play();
            }
            animator.SetBool("isWalking", true);
            dust.transform.rotation = new Quaternion(0, 0, 0, 0);
        } else if(xAxis > 0 && canJump) {
            if(dust.isStopped){
                dust.Play();
            }
            animator.SetBool("isWalking", true);
            dust.transform.rotation = new Quaternion(0, 180, 0, 0);
        }

        // originally used yAxis to check if in air but upon collision with objects, the yAxis gets bugged

        if(Input.GetKeyDown(KeyCode.Space) & canJump)
        {
            // this.gameObject.GetComponent<AudioSource>().Play();
            rb.AddForce(Vector2.up * jumpForce);
            speed = 6f;
            canJump = false;
            jump.Play();
        }
    }

        
    private void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.CompareTag("Ground") || other.gameObject.tag.StartsWith("Cube")) { // turns out using "==" is not the best way to compare tags
            canJump = true;
            speed = 10f;
        }
    }
}