using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ElevatorScript : MonoBehaviour
{
    public CubePlace cubePlace;
    public GameObject elevator;
    private bool alrdyActv = false;
    private bool loopActive = false;
    float yAxis;
    
    void Start()
    {
        yAxis = elevator.transform.position.y;
    }

    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(cubePlace.isCubeOnPlace)
        {
            if (!alrdyActv)
            {
                if (loopActive == false)
                {
                    StartCoroutine(Countdown());
                    loopActive = true;
                }
                
                elevator.transform.position = Vector2.Lerp(elevator.transform.position, new Vector2(elevator.transform.position.x, yAxis + 7.75f), 0.5f * Time.deltaTime);
            }
            else
            {
                elevator.transform.position = Vector2.Lerp(elevator.transform.position, new Vector2(elevator.transform.position.x, yAxis), 0.4f * Time.deltaTime);
            }
        }
    }

    IEnumerator Countdown()
    {
        Debug.Log("print");
        while(true)
        {
            yield return new WaitForSeconds(4f);
            alrdyActv = true;
            yield return new WaitForSeconds(4f);
            alrdyActv = false;
        }
        
    }

}
