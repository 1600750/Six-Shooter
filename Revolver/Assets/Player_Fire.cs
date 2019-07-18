using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Fire : MonoBehaviour {

    public GameObject bullet;
    GameObject[] cylander;
    public GameObject barrel;
    public float speed = 100f;
    public int ammo;
    bool fire;
    bool reload;
    int j;
    int r;
	// Use this for initialization
	void Start ()
    {
        fire = true;
        ammo = 6;
        reload = true;
        cylander = new GameObject[6];
        j = 0;
        r = 0;

        for(int i = 0; i < 6; i++)
        {
            cylander[i] = bullet;
            
        }

       
    }
	
	// Update is called once per frame
	void Update ()
    {
        if(j == 6)
        {
            j = 0;
        }

        if (r == 6)
        {
            r = 0;
        }

        if ((Input.GetAxis("Fire1") > 0 ) && fire == true && ammo > 0)
        {
            if(cylander[j] != null)
            {
                GameObject instBullet = Instantiate(cylander[j], barrel.transform.position, Quaternion.identity) as GameObject;
                Rigidbody instBulletRigidbody = instBullet.GetComponent<Rigidbody>();
                instBulletRigidbody.AddForce(barrel.transform.forward * speed);
                ammo--;
                cylander[j] = null;
            }

            fire = false;
            j++;
           
        }

        if ((Input.GetAxis("Fire1") == 0) && fire == false)
        {
            fire = true;
        }

        if (Input.GetAxis("Reload") > 0 && reload == true && ammo < 6)
        {
            
            if (cylander[r] == null)
            {
                cylander[r] = bullet;
                ammo++;
            }
            
            r++;
            
            reload = false;
        }

        if ((Input.GetAxis("Reload") == 0) && reload == false)
        {
            reload = true;
        }


    }
}
