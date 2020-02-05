using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundCheck : MonoBehaviour {

    public GameObject SimMon;

    public static int check = 0;
	// Use this for initialization
	void Start () {

        SimMon.SetActive(false);

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other) {

        if (other.gameObject.tag == "Player") {

            SimMon.SetActive(true);

        }
    
    }
}
