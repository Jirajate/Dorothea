using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tu_Check : MonoBehaviour {

	public GameObject Tu_Img;
	public static bool ready;

	// Use this for initialization
	void Start () {

		StartCoroutine (Freeze ());
		Tu_Img.SetActive (false);

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Joystick1Button7)) {
			Time.timeScale=1;
			Tu_Img.SetActive (false);
		}
	}
	public IEnumerator Freeze()
	{
		
		yield return new WaitForSeconds(2f);
		Tu_Img.SetActive (true);
		Time.timeScale=0;

	}
}
