using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Fire : MonoBehaviour {

    public GameObject bullet;
    public GameObject barrel;
    public float speed = 100f;
    int ammo;
    bool fire;
    bool reload;
	// Use this for initialization
	void Start ()
    {
        fire = true;
        ammo = 6;
        reload = true;

    }
	
	// Update is called once per frame
	void Update ()
    {
		if((Input.GetAxis("Fire1") > 0 ) && fire == true && ammo > 0)
        {
            GameObject instBullet = Instantiate(bullet, barrel.transform.position, Quaternion.identity) as GameObject;
            Rigidbody instBulletRigidbody = instBullet.GetComponent<Rigidbody>();
            instBulletRigidbody.AddForce(barrel.transform.forward * speed);
            fire = false;
            ammo--;
           
        }

        if ((Input.GetAxis("Fire1") == 0) && fire == false)
        {
            fire = true;
        }

        if (Input.GetAxis("Reload") > 0 && reload == true && ammo < 6)
        {
            ammo++;
            reload = false;
        }

        if ((Input.GetAxis("Reload") == 0) && reload == false)
        {
            reload = true;
        }


    }
}
