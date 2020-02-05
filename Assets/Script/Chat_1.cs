using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chat_1 : MonoBehaviour {

	public GameObject Dialog;
	bool click;
	// Use this for initialization
	void Start () {
		
		Dialog.SetActive (false);

	}
	
	// Update is called once per frame
	void Update () {

		if (click == true) {
		
			Dialog.SetActive (true);
		
		} else if (!click) {
		
			Dialog.SetActive (false);
		
		}

	}

	void OnTriggerStay(Collider other){

        if (Input.GetAxis("Trigger") == 1) {
			
			if (!click) {
				
				click = true;

			} 
		}
	
	}

	void OnTriggerExit(Collider other){

		click = false;

	}

}
