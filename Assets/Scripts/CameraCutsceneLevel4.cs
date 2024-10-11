using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraCutsceneLevel4 : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject player;
    private GameObject camerac;
    public Transform[] cameraTransforms;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        camerac = GameObject.FindWithTag("MainCamera");
        StartCoroutine(CutScene());
    }

    public IEnumerator CutScene()
    {
        player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
        
        Vector3 startingPos = new(0f, 0.1505752f, -15.05752f);
        for(int i = 0; i < cameraTransforms.Length; i++){
            Vector3 targetPos = cameraTransforms[i].position;      
            float elapsedTime = 0f;
            float duration = 4f; 
        
            while (elapsedTime < duration)
            {
                elapsedTime += Time.deltaTime;
        
                float t = Mathf.Clamp01(Time.deltaTime / duration);
        
                camerac.transform.position = Vector3.Lerp(camerac.transform.position, targetPos, t);
        
                yield return null;  // Wait for the next frame
            }
        
            // camerac.transform.position = targetPos;
        }
    
        player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None | RigidbodyConstraints2D.FreezeRotation;
    
        camerac.transform.SetParent(player.transform, false);
        camerac.transform.position = new Vector3(0f, 0f, -15.05752f);
        camerac.transform.localPosition = startingPos;
    }

}
