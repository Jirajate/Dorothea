using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enter : MonoBehaviour {

    public GameObject Player;
    public GameObject movePlat_1;
    public GameObject movePlat_2;

    public GameObject active1;
    public GameObject active2;

    float MoveSpeed = 3.0f;

    float count = 8f;

	// Use this for initialization
	void Start () {

        active1.SetActive(false);
        active2.SetActive(false);

	}
	
	// Update is called once per frame
	void Update () {

        count -= Time.deltaTime;

        if (count > 0)
        {
            movePlat_1.transform.Translate(Vector3.right * MoveSpeed * Time.deltaTime);
            movePlat_2.transform.Translate(Vector3.right * MoveSpeed * Time.deltaTime);
            Player.transform.Translate(Vector3.right * MoveSpeed * Time.deltaTime);
        }

        if (count <= 0) {

            movePlat_1.SetActive(false);
            movePlat_2.SetActive(false);
            active1.SetActive(true);
            active2.SetActive(true);
        
        }

	}
}
