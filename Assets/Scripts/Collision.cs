using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class Collision : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject control;
    private PrefabControl controlPrefab;
    public bool DoWork = false;
    GameObject audioGameObject;
    Vector2 spawnPos;
    void Start()
    {
        control = GameObject.FindWithTag("bc");
        controlPrefab = control.GetComponent<PrefabControl>();
        audioGameObject = GameObject.FindGameObjectWithTag("sp");
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (DoWork)
        {
            int tagrn = int.Parse(gameObject.tag.ToString());

            if (collision.gameObject.tag == this.gameObject.tag)
            {
                audioGameObject.GetComponent<AudioSource>().Play();

                spawnPos = collision.gameObject.transform.position;
                print("Same cubes");

                Destroy(collision.gameObject);
                Debug.LogError(controlPrefab.name);
                Debug.LogError(controlPrefab.cubePrefabs[tagrn].name);


                GameObject clone = Instantiate(controlPrefab.cubePrefabs[tagrn], spawnPos, Quaternion.identity);
                ParticleSystem explosion = clone.GetComponent<ParticleSystem>();
                explosion.Play();

                Destroy(this.gameObject);



            }
        }

    }
}