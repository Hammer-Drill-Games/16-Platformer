using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
    public GameObject cube;
    public string sceneName;
    
    void OnTriggerEnter2D(Collider2D other){
        if (other.CompareTag(cube.tag)){
            SceneManager.LoadSceneAsync(sceneName);
        }
    }
}
