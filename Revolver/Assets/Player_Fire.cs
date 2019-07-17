using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Fire : MonoBehaviour {

    public GameObject bullet;
    public GameObject barrel;
    public float speed = 100f;
    bool fire;
	// Use this for initialization
	void Start ()
    {
        fire = true;

    }
	
	// Update is called once per frame
	void Update ()
    {
		if((Input.GetAxis("Fire1") > 0 ) && fire == true)
        {
            GameObject instBullet = Instantiate(bullet, barrel.transform.position, Quaternion.identity) as GameObject;
            Rigidbody instBulletRigidbody = instBullet.GetComponent<Rigidbody>();
            instBulletRigidbody.AddForce(barrel.transform.forward * speed);
            fire = false;
           
        }

        if ((Input.GetAxis("Fire1") == 0) && fire == false)
        {
            fire = true;
        }
    }
}
