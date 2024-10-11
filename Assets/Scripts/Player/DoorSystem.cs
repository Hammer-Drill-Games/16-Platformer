using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DoorSystem : MonoBehaviour
{
    // Start is called before the first frame update
    private int KeyCount = 0;
    public TextMeshProUGUI KeyCountText;
    private AudioSource audioSource;
    public Sprite doorOpen;
    public bool newSystem = false;
    public GameObject[] doors;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void KeyCollect(){
        KeyCount++;
        KeyCountText.text = KeyCount.ToString();
        audioSource.Play();
        try {
            if(newSystem){
                GameObject d = doors[0];
                d.GetComponent<SpriteRenderer>().sprite = doorOpen;
                d.GetComponent<BoxCollider2D>().enabled = false;
                doors = doors[1..];
            } else {
                GameObject door = GameObject.FindWithTag("Door" + KeyCount.ToString());
                door.GetComponent<SpriteRenderer>().sprite = doorOpen;
                door.GetComponent<BoxCollider2D>().enabled = false;
            }
        } catch {
            Debug.Log("Door not found");
        }
    }
}
