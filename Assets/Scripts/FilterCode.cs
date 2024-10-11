using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FilterCode : MonoBehaviour
{
    public GameObject cube;
    private CubeHold cubeHold;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        cubeHold = GameObject.FindWithTag("Player").GetComponent<CubeHold>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, Mathf.PingPong(Time.time, 1));
    }

    void OnTriggerEnter2D(Collider2D obj){
        if (obj.CompareTag(cube.tag)){
            if(cubeHold.holdedCube == obj.gameObject){
                cubeHold.holdedCube = null;
            }

            Destroy(obj.gameObject);
        }
    }
}
