using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpening : MonoBehaviour
{
    // Start is called before the first frame update

    public KeyScript keyControl;
    public GameObject doorObj;
    public Sprite doorSprite;
    private bool canOpen = false;
    private bool alrdyOpened = false;
    void Start()
    {
        keyControl = keyControl.GetComponent<KeyScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (keyControl.hasKey > 0 && Input.GetKey(KeyCode.E) && canOpen)
        {
            canOpen = false;
            alrdyOpened = true;
            doorObj.GetComponent<SpriteRenderer>().sprite = doorSprite;
            doorObj.GetComponent<Collider2D>().isTrigger = true;
            keyControl.hasKey -= 1;

        }
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && !alrdyOpened)
        {
            canOpen = true;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            canOpen = false;
        }

    }
}
