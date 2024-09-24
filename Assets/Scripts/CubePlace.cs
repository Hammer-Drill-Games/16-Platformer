using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubePlace : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isCubeOnPlace = false;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "3")
        {
            isCubeOnPlace = true;
            Destroy(collision.gameObject);
        }
    }
}
