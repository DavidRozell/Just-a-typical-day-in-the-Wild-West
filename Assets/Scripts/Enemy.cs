using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public AudioClip fall;
    public float speed;
    public bool hit = false;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (hit == false)
        {
            Vector3 lookDirection = (player.transform.position - transform.position).normalized;
            lookDirection.y = -90;
            transform.rotation = Quaternion.LookRotation(lookDirection);
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }
       
    }
}
