using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lookat : MonoBehaviour {

    public GameObject Player;

    private GameObject target;
    private Vector3 targetPoint;
    private Quaternion targetRotation;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        targetPoint = new Vector3(Player.transform.position.x, transform.position.y, Player.transform.position.z) - transform.position;
        targetRotation = Quaternion.LookRotation(-targetPoint, Vector3.up);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 2.0f);
		
	}
}
