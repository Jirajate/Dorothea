using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Falling : MonoBehaviour {

    public GameObject platform;
    public Animation anim;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other) {

        if (other.gameObject.tag == "Player") {

            StartCoroutine(PlatDes());

        }

    }

    IEnumerator PlatDes()
    {

        anim.Play();
        yield return new WaitForSeconds(1);
        platform.SetActive(false);

    }
}
