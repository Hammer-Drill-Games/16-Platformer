using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class CubeHold : MonoBehaviour
{
    private GameObject holdedCube;
    public Transform point;
    public Transform point2;
    public GameObject cube;

    void Start()
    {

    }

     void Update()
    {

        
        if(holdedCube != null)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;

            // float maxDistance = 1.5f; 
            Vector3 direction = mousePos - point.position;

            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            if (angle-66.6f < -170f){
                angle = 100f + 66.6f;
            }
            if(angle-66.6f < -90f) {

                angle = -90f+66.6f;
            }
            
            point.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 66.6f));

            // float distance = direction.magnitude;
            
            holdedCube.transform.position = point2.position;// + direction.normalized * maxDistance;
        }
    }

    public void CarryFunc(GameObject cubec)
    {
        if (holdedCube == null){
            gameObject.GetComponent<ParticleSystem>().Play();
            cubec.GetComponent<AudioSource>().Play();
            holdedCube = cubec;
            holdedCube.GetComponent<BoxCollider2D>().isTrigger = true;
            holdedCube.transform.SetParent(gameObject.transform);
        }
        else if (holdedCube != null)    
        {
            holdedCube.GetComponent<BoxCollider2D>().isTrigger = false;
            holdedCube.transform.SetParent(null);
            holdedCube.transform.position = new Vector3(holdedCube.transform.position.x, holdedCube.transform.position.y+2f, 0);
            holdedCube.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);

            holdedCube = null;
        }
  
    }

}