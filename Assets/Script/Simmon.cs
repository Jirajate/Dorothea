using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Simmon : MonoBehaviour {

    public GameObject A;
    public GameObject B;
    public GameObject X;
    public GameObject Y;
    public GameObject mon;

    public GameObject movePlat;

    int i = 0;

	// Use this for initialization
	void Start () {

        A.SetActive(true);
        B.SetActive(false);
        X.SetActive(false);
        Y.SetActive(false);

        movePlat.SetActive(false);

	}
	
	// Update is called once per frame
	void Update () {

		//Joystick1Button0
        if (Input.GetKeyDown(KeyCode.Joystick1Button0) && i == 0) {

            i++;
            A.SetActive(false);
            B.SetActive(true);

        }

		//Joystick1Button1
        if (Input.GetKeyDown(KeyCode.Joystick1Button1) && i == 1)
        {

            i++;
            B.SetActive(false);
            X.SetActive(true);


        }

		//Joystick1Button2
        if (Input.GetKeyDown(KeyCode.Joystick1Button2) && i == 2)
        {

            i++;
            X.SetActive(false);
            Y.SetActive(true);


        }

		//Joystick1Button3
        if (Input.GetKeyDown(KeyCode.Joystick1Button3) && i == 3)
        {

            i++;
            Y.SetActive(false);

        }

        if (i == 4) {

            movePlat.SetActive(true);
            mon.SetActive(false);

        }
	}

}
