using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDestroyer : MonoBehaviour
{
    private float BoundZ = 30;
    private float BoundX = 30;
    private float BoundY = 30;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > BoundX)
        {
            Destroy(gameObject);
        }
        else if (transform.position.x < -BoundX)
        {
            Destroy(gameObject);
        }

        if (transform.position.y > BoundY)
        {
            Destroy(gameObject);
        }
        else if (transform.position.y < -BoundY)
        {
            Destroy(gameObject);
        }

        if (transform.position.z > BoundZ)
        {
            Destroy(gameObject);
        }
        else if (transform.position.z < -BoundZ)
        {
            Destroy(gameObject);
        }


    }
}
