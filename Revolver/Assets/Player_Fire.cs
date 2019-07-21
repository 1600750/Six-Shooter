using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Fire : MonoBehaviour {

    public GameObject[] bullet;
    GameObject[] cylander;
    public GameObject barrel;
    public float speed = 100f;
    public int ammo;
    bool fire;
    bool reload;
    bool next_Round;
    int j;
    int r;
	// Use this for initialization
	void Start ()
    {
        fire = true;
        ammo = 6;
        reload = true;
        next_Round = true;
        cylander = new GameObject[6];
       
        j = 0;
        r = 0;

        for(int i = 0; i < 6; i++)
        {
            cylander[i] = bullet[0];
            
        }
        cylander[1] = bullet[1];
        cylander[3] = bullet[1];
        cylander[5] = bullet[1];


    }
	
	// Update is called once per frame
	void Update ()
    {
        if(j == 6)
        {
            j = 0;
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

        if(Input.GetAxis("Next-Bullet") > 0 && next_Round == true)
        {
            j++;
            next_Round = false;
        }

        if (Input.GetAxis("Next-Bullet") == 0 && next_Round == false)
        {
           
            next_Round = true;
        }

        if ((Input.GetAxis("Fire1") == 0) && fire == false)
        {
            fire = true;
        }

        if (Input.GetAxis("Reload") > 0 && reload == true && ammo < 6)
        {
            do
            {
                r++;

                if (r == 6)
                {
                    r = 0;
                }

            } while (cylander[r] != null);
            
            
            if (cylander[r] == null)
            {
                if(r == 0 || r == 2 || r== 4)
                {
                    cylander[r] = bullet[0];
                    ammo++;
                }
                if (r == 1 || r == 3 || r == 5)
                {
                    cylander[r] = bullet[1];
                    ammo++;
                }

            }

            reload = false;
        }

        if ((Input.GetAxis("Reload") == 0) && reload == false)
        {
            reload = true;
        }


    }
}
