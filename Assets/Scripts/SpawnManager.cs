using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SpawnManager : MonoBehaviour
{
    public int playerHealth;
    public Text health;
    public GameObject gun;
    public Text bullets;
    public Text waveNumText;
    public Text remainingText;
    public GameObject enemyPrefab;
    public GameObject Player;
    public int amount = 0;
    public int remainingEnemies = 7;
    public int remainingInterval = 7;
    public int waveNum = 1;
    public bool nextWave;
    private float spawnRangeX = 10f;
    private float spawnRangeZ = 10f;
    private float startDelay = 1f;
    private float offset = 5f;

    // Start is called before the first frame update
    void Start()
    {
        gun = GameObject.Find("Gun");
        InvokeRepeating("SpawnEnemy", startDelay, Random.Range(1f, 1.6f));
    }

    // Update is called once per frame
    void Update()
    {

        if (remainingEnemies >= 0)
        {
            remainingText.text = remainingEnemies.ToString();
            waveNumText.text = "Wave " + waveNum.ToString();
        }

        health.text = playerHealth.ToString();

        if (playerHealth <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

    }

    void SpawnEnemy()
    {
        if (amount != remainingInterval & amount >= 0 & remainingInterval < remainingInterval + 1 & remainingEnemies > 0)
        {
            amount = amount + 1;
            var randomZ = Random.Range(-spawnRangeZ, spawnRangeZ);
            if (randomZ < 5)
            {
                randomZ += spawnRangeZ;
            }
            Vector3 spawnPosEnemy = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), offset, randomZ);
            var enemy = Instantiate(enemyPrefab, spawnPosEnemy, enemyPrefab.transform.rotation);
            enemy.transform.LookAt(Player.transform);
        }
        else
        {
            if (remainingEnemies <= 0 & nextWave == false)
            {
                nextWave = true;
                StartCoroutine(NextWave());
            }
        }
    }

    IEnumerator NextWave()
    {
        remainingInterval = remainingInterval + 7;
        yield return new WaitForSeconds(10);
        waveNum = waveNum + 1;
        remainingEnemies = remainingInterval;
        gun.gameObject.GetComponent<GunManager>().bullets = 12;
        bullets.text = "12";
        nextWave = false;
        amount = 0;
    }
}
