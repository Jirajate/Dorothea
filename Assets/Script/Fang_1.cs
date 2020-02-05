using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fang_1 : MonoBehaviour {

    public GameObject fang;
	// Use this for initialization
	void Start () {

        fang.SetActive(false);

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerStay(Collider other) {


        if (other.gameObject.tag == "Player") {

            fang.SetActive(true);

        }
    
    }

    void OnTriggerExit(Collider other) {

        if (other.gameObject.tag == "Player") {

            fang.SetActive(false);

        }

    }
}
