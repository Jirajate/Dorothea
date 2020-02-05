using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combo : MonoBehaviour {

    public static int fightable = 0;
    public GameObject target;
    public GameObject boss;
    public Animator anim;
    public AudioSource audio;

    public GameObject button_1;
    public GameObject button_2;
    public GameObject button_3;

    private static int check;

    public static int movecheck = 1;

    int i = 0;
    int time = 0;
    int check_1 = 0;

    int moncount = 0;

	// Use this for initialization
	void Start () {

        InvokeRepeating("SetRhythm", 0f, 1.1f);
        InvokeRepeating("RemoveRhythm", 0.55f, 1.1f);
        fightable = 0;

        target.SetActive(false);
        anim = boss.GetComponent<Animator>();

        movecheck = 1;

        check = SoundCheck.check;
	}
	
	// Update is called once per frame
	void Update () {

        if (check == 1) {

            audio.Play();

        }

        if (i == 1)
        {
            if (check_1 == 0 ) {

                if (Input.GetKeyDown(KeyCode.Joystick1Button0))
                {

                    check_1 = 1;
                    Destroy(button_1);
                    Debug.Log(check_1);

                }
            }

            else if (check_1 == 1) {

                if (Input.GetKeyDown(KeyCode.Joystick1Button0)) {

                    check_1 = 2;
                    Destroy(button_2);
                    Debug.Log(check_1);

                }
            }

            else if (check_1 == 2)
            {

                if (Input.GetKeyDown(KeyCode.Joystick1Button1))
                {

                    anim.Play("Monster1_walkright");
                    StartCoroutine(MonDes1());
                    fightable = 0;
                    check_1 = 3;
                    movecheck = 0;
                    Destroy(button_3);
                    moncount = 1;
                    Debug.Log(check_1);

                }
            }


        }
		
	}

    IEnumerator MonDes1()
    {

        yield return new WaitForSeconds(1);
        Destroy(boss);
        target.SetActive(true);

    }

    void SetRhythm() {

        i = 1;
        time++;
        Debug.Log("Time : " + time);

    }

    void RemoveRhythm() {

        i = 0;

    }
}
