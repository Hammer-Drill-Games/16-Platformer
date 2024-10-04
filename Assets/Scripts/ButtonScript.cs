using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public GameObject spawnObject;
    public GameObject spawnLocation; // empty gameObject
    public Sprite bOff;
    public Sprite bOn;
    private GameObject player;
    private SpriteRenderer spriteRenderer;
    bool triggered = false;
    bool canPress = true;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.E) && triggered && canPress){
            canPress = false;
            spriteRenderer.sprite = bOn;
            Instantiate(spawnObject, spawnLocation.transform.position, Quaternion.identity);
            StartCoroutine(cor());
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject == player){
            triggered = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject == player){
            triggered = false;
        }
    }

    IEnumerator cor()
    {
        yield return new WaitForSeconds(2f);
        spriteRenderer.sprite = bOff;
        canPress = true;
    }
}
