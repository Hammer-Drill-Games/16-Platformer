using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class PressureButtonScript : MonoBehaviour
{
    public GameObject triggerObject;
    public Sprite bOff;
    public Sprite bOn;
    private AudioSource clickSound;
    public UnityEvent onButtonPressed;
    public UnityEvent onButtonReleased;
    private SpriteRenderer spriteRenderer;
    
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        clickSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(triggerObject.CompareTag(other.gameObject.tag)){
            onButtonPressed.Invoke();
            spriteRenderer.sprite = bOn;
            clickSound.Play();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(triggerObject.CompareTag(other.gameObject.tag)){
            onButtonReleased.Invoke();
            spriteRenderer.sprite = bOff;
            clickSound.Play();
        }
    }
}
