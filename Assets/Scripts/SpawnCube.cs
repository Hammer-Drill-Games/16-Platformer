using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCube : MonoBehaviour
{
    private bool canPressC = false;
    private bool pressAble = true;
    public GameObject cube;

    private void Start()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            canPressC = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            canPressC = false;
        }
    }

    private void Update()
    {

      if (Input.GetKeyDown(KeyCode.C)&&pressAble)
        {
            pressAble = false;
            Vector2 pos = new Vector2(transform.position.x, transform.position.y + 9);
            Instantiate(cube, pos, Quaternion.identity);
            StartCoroutine(cor());
        }
    }

    IEnumerator cor()
    {
            yield return new WaitForSeconds(2f);
            pressAble = true;
    }
}
