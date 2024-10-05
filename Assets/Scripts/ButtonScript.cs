using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class ButtonScript : MonoBehaviour
{
    public GameObject spawnObject;
    public GameObject spawnLocation; // empty gameObject
    public Sprite bOff;
    public Sprite bOn;
    private AudioSource clickSound;
    private GameObject player;
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider2D;
    private TextMeshPro text;
    private bool alreadyEdited = false;
    
    Vector2 colliderSize;
    bool triggered = false;
    bool canPress = true;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player");
        clickSound = GetComponent<AudioSource>();
        boxCollider2D = GetComponents<BoxCollider2D>()[1];
        colliderSize = boxCollider2D.size;
        if(SceneManager.GetActiveScene().name == "Level-1"){
            text = GetComponentInChildren<TextMeshPro>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.E) && triggered && canPress){
            canPress = false;
            spriteRenderer.sprite = bOn;
            Instantiate(spawnObject, spawnLocation.transform.position, Quaternion.identity);
            clickSound.Play();
            boxCollider2D.size = new Vector2(colliderSize.x, colliderSize.y/1.65f);
            if(SceneManager.GetActiveScene().name == "Level-1" && !alreadyEdited){
                text.text = "Combine The Blocks!";
                text.gameObject.transform.position = new Vector2(text.gameObject.transform.position.x + 5f, text.gameObject.transform.position.y);
                alreadyEdited = true;
            }
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
        boxCollider2D.size = colliderSize;
        canPress = true;
    }
}
