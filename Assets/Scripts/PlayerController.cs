using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class PlayerController : MonoBehaviour
{
    /*XRIDefaultInputActions controller;
    public Material selected;
    public Material normal;
    public GameObject gun;
    public GameObject RHand;
    public GameObject gunHoldPos;
    public GameObject bulletStartPos;
    public GameObject bullet;
    public bool isHoldingGun = false;
    public bool pickingUpCooldown;
    private float bulletSpeed = 20f;
    private float detectionradius = 0.6f;*/

    private void Awake()
    {
        /*controller = new XRIDefaultInputActions();
        controller.XRIRightHand.PickUp.performed += ctx => PickUp();
        controller.XRIRightHand.Drop.performed += ctx => Drop();
        controller.XRIRightHand.Shoot.performed += ctx => Shoot();*/
    }

    // Start is called before the first frame update
    void Start()
    {
        /*RHand = GameObject.Find("RHand");
        gun = GameObject.Find("Gun");
        gunHoldPos = GameObject.Find("GunHoldPos");
        bulletStartPos = GameObject.Find("BulletStartPos");*/
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Vector3.Distance(RHand.transform.position, gun.gameObject.transform.position) <= detectionradius & isHoldingGun == false & pickingUpCooldown == false)
        {
            gun.gameObject.GetComponent<Renderer>().material = selected;
        }
        if (Vector3.Distance(RHand.transform.position, gun.gameObject.transform.position) > detectionradius | isHoldingGun == true)
        {
            gun.gameObject.GetComponent<Renderer>().material = normal;
        }*/
    }

    /*void PickUp()
    {
        if (isHoldingGun == false & pickingUpCooldown == false & Vector3.Distance(RHand.gameObject.transform.position, gun.gameObject.transform.position) <= detectionradius)
        {
            isHoldingGun = true;
            gun.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            gun.gameObject.transform.rotation = gunHoldPos.transform.rotation;
            gun.gameObject.transform.position = gunHoldPos.gameObject.transform.position;
            gun.gameObject.transform.parent = RHand.gameObject.transform;
        }
    }

    void Drop()
    {
        if (gameObject.GetComponent<PlayerController>().isHoldingGun == true)
        {
            gameObject.GetComponent<PlayerController>().isHoldingGun = false;
            gun.gameObject.GetComponent<Rigidbody>().isKinematic = false;
            gun.gameObject.transform.parent = null;
            StartCoroutine(PickupCooldown());
        }
    }
    private IEnumerator PickupCooldown()
    {
        gameObject.GetComponent<PlayerController>().pickingUpCooldown = true;
        yield return new WaitForSeconds(1);
        gameObject.GetComponent<PlayerController>().pickingUpCooldown = false;
    }

    void Shoot()
    {
        if (isHoldingGun == true)
        {
            Vector3 spawnPos = bulletStartPos.gameObject.transform.position;
            var projectile = Instantiate(bullet, spawnPos, bullet.transform.rotation);
            projectile.transform.rotation = RHand.gameObject.transform.rotation;
            projectile.GetComponent<Rigidbody>().velocity = (gun.gameObject.transform.up * bulletSpeed);
        }
    }

    void OnEnable()
    {
        controller.XRIRightHand.Enable();
    }

    void OnDisable()
    {
        controller.XRIRightHand.Disable();
    }*/
}
