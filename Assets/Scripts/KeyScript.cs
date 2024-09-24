using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class KeyScript : MonoBehaviour
{
    public int hasKey = 0;
    public TextMeshProUGUI keyText;
    GameObject keySound;
    

    void Start()
    {
        keySound = GameObject.FindWithTag("ksp");
    }

    void FixedUpdate()
    {
        keyText.text = hasKey.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Key")
        {
            keySound.GetComponent<AudioSource>().Play();
            Destroy(collision.gameObject);
            hasKey++;
        }
    }
}
