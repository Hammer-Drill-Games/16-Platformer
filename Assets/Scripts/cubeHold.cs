using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class cubeHold : MonoBehaviour
{
    GameObject holdedCube;
    public GameObject cubePrefab;
    public Transform point;
    public Transform point2;
    private GameObject control;
    private PrefabControl controlPrefab;

    void Start()
    {
        control = GameObject.FindWithTag("bc");
        controlPrefab = control.GetComponent<PrefabControl>();

    }

     void Update()
    {

        
        if(holdedCube != null)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0; // Ensure it's on the same plane

            float maxDistance = 1.5f; // Set your maximum distance here
            Vector3 direction = mousePos - point.position;

            // Calculate angle
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Debug.Log(angle - 66.6f);
            if (angle-66.6f < -170f)
            {
                angle = 100f + 66.6f;
            }
            if(angle-66.6f < -90f) {

                angle = -90f+66.6f;
            }
            
            point.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 66.6f));

            // Calculate distance and position
            float distance = direction.magnitude;
            
            {
                
                holdedCube.transform.position = point2.position;// + direction.normalized * maxDistance;
            }
        }
    }

    public void carryFunc(GameObject cube)
    {
        if ((holdedCube == null)){
            this.gameObject.GetComponent<ParticleSystem>().Play();
            cube.GetComponent<BoxCollider2D>().isTrigger = true;
            holdedCube = cube;
            holdedCube.transform.SetParent(this.gameObject.transform);
            holdedCube.transform.localScale = new Vector3(holdedCube.transform.localScale.x, holdedCube.transform.localScale.y, holdedCube.transform.localScale.z);
        }
        else if (holdedCube != null)    
        {
            
           

            GameObject newObj = Instantiate(controlPrefab.cubePrefabs[0], new Vector2(holdedCube.transform.position.x, transform.position.y + 2), Quaternion.identity);
            Destroy(holdedCube);


            holdedCube = null;

        }
  
    }

}