using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeCollision : MonoBehaviour {
    public GameObject cube;

    void Start() {
        
    }

    void Update() {
        
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if(!gameObject.CompareTag("Cube16")){
            Vector2 contactPoint = collision.GetContact(0).point;
            contactPoint.y += 1f;
            if(collision.gameObject.CompareTag(gameObject.tag)) {
                if(collision.gameObject.GetComponent<Rigidbody2D>().velocity.y > gameObject.GetComponent<Rigidbody2D>().velocity.y) {
                    GameObject newCube = Instantiate(cube, contactPoint, Quaternion.identity);
                    newCube.GetComponent<ParticleSystem>().Play();
                    newCube.GetComponent<AudioSource>().Play();
                }
                Destroy(gameObject);
            }
        }
    }
}
