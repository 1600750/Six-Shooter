using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ammo_display : MonoBehaviour {

    // Use this for initialization
    public GameObject player;
    Player_Fire pf;
    public Text ammoText;
    
	void Start ()
    {
        pf = player.GetComponent<Player_Fire>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        ammoText.text = "Ammo : " + pf.ammo;


	}
}
