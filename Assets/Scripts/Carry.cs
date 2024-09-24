using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carry : MonoBehaviour
{
    public GameObject playerObj;
    cubeHold cubeHold;
    
    void Start()
    {
        playerObj = GameObject.FindWithTag("Player");
        cubeHold = playerObj.GetComponent<cubeHold>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        cubeHold.carryFunc(gameObject);
    }
}
