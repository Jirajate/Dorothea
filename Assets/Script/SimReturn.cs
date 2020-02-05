using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimReturn : MonoBehaviour {

    public Transform ReturnPoint;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            other.transform.position = ReturnPoint.position;
        }
    }
}
