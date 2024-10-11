using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScript : MonoBehaviour
{
    public GameObject target;
    public float speed = 2f;
    public bool IsMoving { get; set; } = false;
    public bool setMove = false;
    public bool cylce = true;
    Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
        if(setMove){
            IsMoving = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(IsMoving){
            if(cylce){
                transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
                if(transform.position == target.transform.position){
                    cylce = false;
                }
            } else {
                transform.position = Vector3.MoveTowards(transform.position, startPos, speed * Time.deltaTime);
                if(transform.position == startPos){
                    cylce = true;
                }
            }
        }
    }
}
