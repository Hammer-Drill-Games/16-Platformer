using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class CloudSpawner : MonoBehaviour
{
    public GameObject cloud;
    public float spawnRate = 10f;
    void Start()
    {
        StartCoroutine(SpawnCloud());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator SpawnCloud() {

        while (true)
        {
            yield return new WaitForSeconds(spawnRate);
            float yPos = Random.Range(-0.5f, 0.5f);
            GameObject clone = Instantiate(cloud, new Vector2(transform.position.x, transform.position.y + yPos), Quaternion.identity);
            yield return new WaitForSeconds(3f);
        }
    
    }

}
