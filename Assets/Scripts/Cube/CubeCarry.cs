using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeCarry : MonoBehaviour
{
    public GameObject playerObj;
    CubeHold cubeHold;
    
    void Start()
    {
        playerObj = GameObject.FindWithTag("Player");
        cubeHold = playerObj.GetComponent<CubeHold>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        cubeHold.CarryFunc(gameObject);
    }
}
