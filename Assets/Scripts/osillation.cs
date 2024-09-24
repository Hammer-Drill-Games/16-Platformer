using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class osillation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y + Mathf.Sin(Time.time * 7f) * 0.004f);
        Vector2 pos = new Vector2(transform.position.x + 7.5f, transform.position.y);
        transform.position = Vector2.Lerp(transform.position, pos, 0.5f * Time.deltaTime);
    }

}
