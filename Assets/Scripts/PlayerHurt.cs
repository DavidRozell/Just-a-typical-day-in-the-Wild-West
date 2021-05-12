using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHurt : MonoBehaviour
{
    public GameObject spawnManager;

    // Start is called before the first frame update
    void Start()
    {
        spawnManager = GameObject.Find("Spawn Manager");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (spawnManager.gameObject.GetComponent<SpawnManager>().amount >= 0)
            {
                spawnManager.gameObject.GetComponent<SpawnManager>().amount = spawnManager.gameObject.GetComponent<SpawnManager>().amount - 1;
            }
            Destroy(gameObject);
        }
    }
}
