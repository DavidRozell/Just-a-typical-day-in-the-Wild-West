using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTarget : MonoBehaviour
{
    public AudioClip fall;
    public GameObject spawnManager;
    private bool isHit = false;
    private float BoundZ = 30;
    private float BoundX = 30;
    private float BoundY = 30;

    // Start is called before the first frame update
    void Start()
    {
        spawnManager = GameObject.Find("Spawn Manager");
    }

    // Update is called once per frame
    void Update()
    {

        if (spawnManager.gameObject.GetComponent<SpawnManager>().remainingEnemies <= 0 & isHit == false & gameObject.GetComponent<Enemy>().hit == false)
        {
            gameObject.GetComponent<Enemy>().hit = true;
            isHit = true;
            for (int i = 0; i < 20; i++)
            {
                gameObject.transform.Rotate(Vector3.left * 80 * Time.deltaTime);
            }
            StartCoroutine(Death());
        }

        if (transform.position.x > BoundX)
        {
            if (spawnManager.gameObject.GetComponent<SpawnManager>().amount > 0)
            {
                spawnManager.gameObject.GetComponent<SpawnManager>().amount = spawnManager.gameObject.GetComponent<SpawnManager>().amount - 1;
            }
            Destroy(gameObject);
        }
        else if (transform.position.x < -BoundX)
        {
            if (spawnManager.gameObject.GetComponent<SpawnManager>().amount > 0)
            {
                spawnManager.gameObject.GetComponent<SpawnManager>().amount = spawnManager.gameObject.GetComponent<SpawnManager>().amount - 1;
            }
            Destroy(gameObject);
        }

        if (transform.position.y > BoundY)
        {
            if (spawnManager.gameObject.GetComponent<SpawnManager>().amount > 0)
            {
                spawnManager.gameObject.GetComponent<SpawnManager>().amount = spawnManager.gameObject.GetComponent<SpawnManager>().amount - 1;
            }
            Destroy(gameObject);
        }
        else if (transform.position.y < -BoundY)
        {
            if (spawnManager.gameObject.GetComponent<SpawnManager>().amount > 0)
            {
                spawnManager.gameObject.GetComponent<SpawnManager>().amount = spawnManager.gameObject.GetComponent<SpawnManager>().amount - 1;
            }
            Destroy(gameObject);
        }

        if (transform.position.z > BoundZ)
        {
            if (spawnManager.gameObject.GetComponent<SpawnManager>().amount > 0)
            {
                spawnManager.gameObject.GetComponent<SpawnManager>().amount = spawnManager.gameObject.GetComponent<SpawnManager>().amount - 1;
            }
            Destroy(gameObject);
        }
        else if (transform.position.z < -BoundZ)
        {
            if (spawnManager.gameObject.GetComponent<SpawnManager>().amount > 0)
            {
                spawnManager.gameObject.GetComponent<SpawnManager>().amount = spawnManager.gameObject.GetComponent<SpawnManager>().amount - 1;
            }
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet") & gameObject.GetComponent<Enemy>().hit == false)
        {
            if (spawnManager.gameObject.GetComponent<SpawnManager>().amount >= 0)
            {
                spawnManager.gameObject.GetComponent<SpawnManager>().amount = spawnManager.gameObject.GetComponent<SpawnManager>().amount - 1;
                spawnManager.gameObject.GetComponent<SpawnManager>().remainingEnemies = spawnManager.gameObject.GetComponent<SpawnManager>().remainingEnemies - 1;
            }
            Destroy(collision.gameObject);
            gameObject.GetComponent<Enemy>().hit = true;
            for (int i = 0; i < 20; i++)
            {
                gameObject.transform.Rotate(Vector3.left * 80 * Time.deltaTime);
            }
            gameObject.GetComponent<AudioSource>().clip = fall;
            gameObject.GetComponent<AudioSource>().Play();
            StartCoroutine(Death());
        }
    }
    private void OnTriggerEnter(Collider other)
    { 
        if (other.gameObject.CompareTag("player") & spawnManager.gameObject.GetComponent<SpawnManager>().playerHealth > 0 & gameObject.GetComponent<Enemy>().hit == false)
        {
            spawnManager.gameObject.GetComponent<SpawnManager>().playerHealth = spawnManager.gameObject.GetComponent<SpawnManager>().playerHealth - 1;
            Destroy(gameObject);
        }
    }

    IEnumerator Death()
    {
        yield return new WaitForSeconds(4);
        Destroy(gameObject);
    }
}
