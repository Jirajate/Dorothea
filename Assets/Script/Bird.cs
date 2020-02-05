using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour {

    public GameObject target;

    private int x = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (x == 1)
        {
            target.transform.Translate(Vector3.up * 2f * Time.deltaTime);
            target.transform.Translate(Vector3.right * 2f * Time.deltaTime);
        }

	}

    void OnTriggerEnter(Collider other) {

        if (other.gameObject.tag == "Player") {

            x = 1;


        }
    
    }
}
