using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Level3BreakingWalls : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] walls;
    public AudioSource breakingSound;
    public ScreenShake ShakeScript;
    private GameObject player;
    private GameObject camerac;
    public Transform cameraTransform;
    public GameObject key;
    private bool cutscene = false;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        camerac = GameObject.FindWithTag("MainCamera");
    }

    // Update is called once per frame
    void Update()
    {
        if(key.IsDestroyed() && !cutscene){
            StartCoroutine(CutScene());
            cutscene = true;
        }
    }

    public IEnumerator CutScene()
    {
        player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
    
        float elapsedTime = 0f;
        float duration = 0.8f; 
        Vector3 startingPos = camerac.transform.position;  
        Vector3 targetPos = cameraTransform.position;      
    
        camerac.transform.SetParent(null);
    
        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
    
            float t = Mathf.Clamp01(elapsedTime / duration);
    
            camerac.transform.position = Vector3.Lerp(startingPos, targetPos, t);
    
            yield return null;  // Wait for the next frame
        }
    
        camerac.transform.position = targetPos;
    
        yield return new WaitForSeconds(0.8f);
    
        breakingSound.Play();
        StartCoroutine(ShakeScript.Shake());
    
        yield return new WaitForSeconds(1.0f);
    
        foreach (GameObject wall in walls)
        {
            Rigidbody2D wallRb = wall.GetComponent<Rigidbody2D>();
            wallRb.bodyType = RigidbodyType2D.Dynamic;
            wallRb.constraints = RigidbodyConstraints2D.None;
            wallRb.velocity = new Vector2(0, -5);  // Add some downward force
            wallRb.AddTorque(5f);  // Add some rotation
    
            wall.GetComponent<CompositeCollider2D>().enabled = false;
            wall.GetComponentInChildren<BoxCollider2D>().enabled = false;
        }
    
        camerac.transform.position = targetPos;
    
        yield return new WaitUntil(() => !ShakeScript.isShaking);
    
        player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None | RigidbodyConstraints2D.FreezeRotation;
    
        camerac.transform.SetParent(player.transform, false);
        camerac.transform.position = startingPos;
    
        yield return new WaitForSeconds(3.0f);
    
        foreach (GameObject wall in walls)
        {
            Destroy(wall);
        }
    
        Destroy(gameObject);
    }

}
