using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cubePlatform : MonoBehaviour
{
    private int cubeInt = 8;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            if (SceneManager.GetActiveScene().name == "Level1")
            {
                if (collision.gameObject.tag == "3")
                {
                   SceneManager.LoadSceneAsync("Level2");
                }               
            }
            else if (SceneManager.GetActiveScene().name == "Level2")
            {
                if (collision.gameObject.tag == "4")
                {
                    SceneManager.LoadSceneAsync("Level3");
                }
            }
            else if (SceneManager.GetActiveScene().name == "Level3")
            {
                if (collision.gameObject.tag == "3")
                {
                    SceneManager.LoadSceneAsync("Level4");
                }
            }
            else if (SceneManager.GetActiveScene().name == "Level4")
            {
                if (collision.gameObject.tag == "4")
                {
                    SceneManager.LoadSceneAsync("Level5");
                }
            }
            else if (SceneManager.GetActiveScene().name == "Level5")
            {
                if (collision.gameObject.tag == "3")
                {
                    SceneManager.LoadSceneAsync("Level6");
                }
            }
        }
    }
}
