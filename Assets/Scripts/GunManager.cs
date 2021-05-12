using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunManager : MonoBehaviour
{
    public AudioClip shoot;
    public AudioClip reload;
    public GameObject spawnManager;
    public Text bulletsAmount;
    public Material selected;
    public Material normal;
    public GameObject bulletShootPos;
    public GameObject bullet;
    public float bulletSpeed = 20f;
    public bool isGrabbed = false;
    public bool reloading = false;
    public int bullets = 12;

    // Start is called before the first frame update
    void Start()
    {
        spawnManager = GameObject.Find("Spawn Manager");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Grabbed()
    {
        isGrabbed = true;
        gameObject.GetComponent<Renderer>().material = normal;
    }

    public void Dropped()
    {
        isGrabbed = false;
    }

    public void Selected()
    {
        if (isGrabbed == false)
        {
            gameObject.GetComponent<Renderer>().material = selected;
        }
    }

    public void Deselected()
    {
        gameObject.GetComponent<Renderer>().material = normal;
    }

    public void Shoot()
    {
        if (bullets > 0 & reloading == false & spawnManager.gameObject.GetComponent<SpawnManager>().nextWave == false)
        {
            gameObject.GetComponent<AudioSource>().clip = shoot;
            gameObject.GetComponent<AudioSource>().Play();
            Vector3 spawnPos = bulletShootPos.gameObject.transform.position;
            var projectile = Instantiate(bullet, spawnPos, bullet.transform.rotation);
            projectile.transform.rotation = bulletShootPos.transform.rotation;
            projectile.GetComponent<Rigidbody>().velocity = (gameObject.transform.up * bulletSpeed);
            bullets = bullets - 1;
            bulletsAmount.text = bullets.ToString();
        }
        else
        {
            if (bullets == 0 & reloading == false & spawnManager.gameObject.GetComponent<SpawnManager>().nextWave == false)
            {
                reloading = true;
                gameObject.GetComponent<AudioSource>().clip = reload;
                gameObject.GetComponent<AudioSource>().Play();
                StartCoroutine(Reload());
            }
        }

    }

    IEnumerator Reload()
    {
        bulletsAmount.text = "R";
        yield return new WaitForSeconds(3);
        bullets = 12;
        bulletsAmount.text = bullets.ToString();
        reloading = false;
    }

}
