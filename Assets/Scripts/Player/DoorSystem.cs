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
            GameObject door = GameObject.FindWithTag("Door" + KeyCount.ToString());
            door.GetComponent<SpriteRenderer>().sprite = doorOpen;
            door.GetComponent<BoxCollider2D>().enabled = false;
        } catch {
            Debug.Log("Door not found");
        }
    }
}
