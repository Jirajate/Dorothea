using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Boss : MonoBehaviour {

    public GameObject button_1;
    public GameObject button_2;
    public GameObject button_3;

    public GameObject button_4;
    public GameObject button_5;
    public GameObject button_6;

    public GameObject button_7;
    public GameObject button_8;
    public GameObject button_9;

    public static bool move_1;
    public static bool move_2;
    public static bool move_3;
    public static bool move_4;
    public static bool move_5;

    public GameObject player_button_1;
    public GameObject player_button_2;
    public GameObject player_button_3;
    public GameObject player_button_4;

    public AudioSource beat_1;
    public AudioSource pattern_1;
    public AudioSource pattern_2;
    public AudioSource pattern_3;

    public GameObject border;

    int i = 0;
    int time = 0;
    int check_combo_1 = 0;
    int check_combo_2 = 0;
    int check_combo_3 = 0;
    int check_combo_4 = 0;
    int check_combo_5 = 0;

    bool boss_start;
    bool dmg;

	// Use this for initialization
	void Start () {

        InvokeRepeating("SetRhythm", 0f, 0.8f);
        InvokeRepeating("RemoveRhythm", 0.4f, 0.8f);

        border.SetActive(false);

        button_1.SetActive(false);
        button_2.SetActive(false);
        button_3.SetActive(false);
        button_4.SetActive(false);
        button_5.SetActive(false);
        button_6.SetActive(false);
        button_7.SetActive(false);
        button_8.SetActive(false);
        button_9.SetActive(false);

        player_button_1.SetActive(false);
        player_button_2.SetActive(false);
        player_button_3.SetActive(false);
        player_button_4.SetActive(false);

        boss_start = false;
        dmg = false;

        move_1 = false;
        move_2 = false;
        move_3 = false;
        move_4 = false;
        move_5 = false;

        StartCoroutine(Check_0());


	}
	
	// Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Joystick1Button0)) {
            StartCoroutine(Key_1());
        }

        if (Input.GetKeyDown(KeyCode.Joystick1Button1))
        {
            StartCoroutine(Key_2());
        }

        if (Input.GetKeyDown(KeyCode.Joystick1Button2))
        {
            StartCoroutine(Key_3());
        }

        if (Input.GetKeyDown(KeyCode.Joystick1Button3))
        {
            StartCoroutine(Key_4());
        }

        if (i == 1)
        {
            //First Combo --------------------------------------BAX
            if (check_combo_1 == 0 && boss_start == true) {
                if (Input.GetKeyDown(KeyCode.Joystick1Button1)) {
                    check_combo_1 = 1;
                    button_1.SetActive(false);
                }
            }
            else if (check_combo_1 == 1)
            {
                if (Input.GetKeyDown(KeyCode.Joystick1Button0))
                {
                    check_combo_1 = 2;
                    button_2.SetActive(false);
                }
                else if (Input.GetKeyDown(KeyCode.Joystick1Button1) || Input.GetKeyDown(KeyCode.Joystick1Button2) || Input.GetKeyDown(KeyCode.Joystick1Button3))
                {
                    check_combo_1 = 0;
                    button_1.SetActive(true);
                    button_2.SetActive(true);
                    button_3.SetActive(true);
                }
            }
            else if (check_combo_1 == 2)
            {
                if (Input.GetKeyDown(KeyCode.Joystick1Button2))
                {
                    check_combo_1 = 3;
                    button_3.SetActive(false);
                    dmg = true;
                    pattern_1.Play();
                    StartCoroutine(Check_1());
                }
                else if (Input.GetKeyDown(KeyCode.Joystick1Button0) || Input.GetKeyDown(KeyCode.Joystick1Button1) || Input.GetKeyDown(KeyCode.Joystick1Button3))
                {
                    check_combo_1 = 0;
                    button_1.SetActive(true);
                    button_2.SetActive(true);
                    button_3.SetActive(true);
                }

            }

            // Second Combo --------------------------------------YYX

            if (check_combo_1 == 3 && check_combo_2 == 0) {
                if (Input.GetKeyDown(KeyCode.Joystick1Button3)) {
                    check_combo_2 = 1;
                    button_4.SetActive(false);
                }
            }
            else if (check_combo_2 == 1) {
                if (Input.GetKeyDown(KeyCode.Joystick1Button3)) {
                    check_combo_2 = 2;
                    button_5.SetActive(false);
                }
                else if (Input.GetKeyDown(KeyCode.Joystick1Button0) || Input.GetKeyDown(KeyCode.Joystick1Button1) || Input.GetKeyDown(KeyCode.Joystick1Button2))
                {
                    check_combo_2 = 0;
                    button_4.SetActive(true);
                    button_5.SetActive(true);
                    button_6.SetActive(true);
                }
            }
            else if (check_combo_2 == 2) {
                if (Input.GetKeyDown(KeyCode.Joystick1Button2)) {
                    check_combo_2 = 3;
                    button_6.SetActive(false);
                    dmg = true;
                    pattern_2.Play();
                    StartCoroutine(Check_2());
                }
                else if (Input.GetKeyDown(KeyCode.Joystick1Button0) || Input.GetKeyDown(KeyCode.Joystick1Button1) || Input.GetKeyDown(KeyCode.Joystick1Button3))
                {
                    check_combo_2 = 0;
                    button_4.SetActive(true);
                    button_5.SetActive(true);
                    button_6.SetActive(true);
                }
            }

            // Third Combo --------------------------------------ABA

            if (check_combo_2 == 3 && check_combo_3 == 0)
            {
                if (Input.GetKeyDown(KeyCode.Joystick1Button0))
                {
                    check_combo_3 = 1;
                    button_7.SetActive(false);
                }
            }
            else if (check_combo_3 == 1)
            {
                if (Input.GetKeyDown(KeyCode.Joystick1Button1))
                {
                    check_combo_3 = 2;
                    button_8.SetActive(false);
                }
                else if (Input.GetKeyDown(KeyCode.Joystick1Button0) || Input.GetKeyDown(KeyCode.Joystick1Button2) || Input.GetKeyDown(KeyCode.Joystick1Button3))
                {
                    check_combo_3 = 0;
                    button_7.SetActive(true);
                    button_8.SetActive(true);
                    button_9.SetActive(true);
                }
            }
            else if (check_combo_3 == 2)
            {
                if (Input.GetKeyDown(KeyCode.Joystick1Button0))
                {
                    check_combo_3 = 3;
                    button_9.SetActive(false);
                    dmg = true;
                    pattern_3.Play();
                    StartCoroutine(End());
                }
                else if (Input.GetKeyDown(KeyCode.Joystick1Button1) || Input.GetKeyDown(KeyCode.Joystick1Button2) || Input.GetKeyDown(KeyCode.Joystick1Button3))
                {
                    check_combo_3 = 0;
                    button_7.SetActive(true);
                    button_8.SetActive(true);
                    button_9.SetActive(true);
                }
            }
        }

        else if (i == 0)
        {
            if (check_combo_1 < 3 && boss_start == true)
            {
                if (Input.GetKeyDown(KeyCode.Joystick1Button0) || Input.GetKeyDown(KeyCode.Joystick1Button1) || Input.GetKeyDown(KeyCode.Joystick1Button2) || Input.GetKeyDown(KeyCode.Joystick1Button3))
                {
                    check_combo_1 = 0;
                    button_1.SetActive(true);
                    button_2.SetActive(true);
                    button_3.SetActive(true);

                }
            }
            else if (check_combo_1 == 3 && check_combo_2 < 3)
            {
                if (Input.GetKeyDown(KeyCode.Joystick1Button0) || Input.GetKeyDown(KeyCode.Joystick1Button1) || Input.GetKeyDown(KeyCode.Joystick1Button2) || Input.GetKeyDown(KeyCode.Joystick1Button3))
                {
                    check_combo_2 = 0;
                    button_4.SetActive(true);
                    button_5.SetActive(true);
                    button_6.SetActive(true);

                }
            }
            else if (check_combo_2 == 3 && check_combo_3 < 3)
            {
                if (Input.GetKeyDown(KeyCode.Joystick1Button0) || Input.GetKeyDown(KeyCode.Joystick1Button1) || Input.GetKeyDown(KeyCode.Joystick1Button2) || Input.GetKeyDown(KeyCode.Joystick1Button3))
                {
                    check_combo_3 = 0;
                    button_7.SetActive(true);
                    button_8.SetActive(true);
                    button_9.SetActive(true);

                }
            }
        }

    }

    void SetRhythm()
    {

        border.SetActive(true);
        i = 1;
        time++;
        Debug.Log("Time : " + time);
        beat_1.Play();
    }

    void RemoveRhythm()
    {

        border.SetActive(false);
        i = 0;

    }

    public IEnumerator Check_0()
    {

        yield return new WaitForSeconds(3f);
        button_1.SetActive(true);
        button_2.SetActive(true);
        button_3.SetActive(true);
        move_1 = true;
        boss_start = true;

    }

    public IEnumerator Check_1()
    {

        move_2 = true;
        yield return new WaitForSeconds(1f);
        dmg = false;
        yield return new WaitForSeconds(2f);
        button_4.SetActive(true);
        button_5.SetActive(true);
        button_6.SetActive(true);

    }

    public IEnumerator Check_2()
    {

        move_3 = true;
        move_4 = true;
        move_5 = true;
        yield return new WaitForSeconds(1f);
        dmg = false;
        yield return new WaitForSeconds(2f);
        button_7.SetActive(true);
        button_8.SetActive(true);
        button_9.SetActive(true);

    }


    public IEnumerator End()
    {

        move_1 = false;
        move_2 = false;
        move_3 = false;
        move_4 = false;
        move_5 = false;
        yield return new WaitForSeconds(1f);
        dmg = false;
        yield return new WaitForSeconds(3f);
        float fadeTime = GameObject.Find("FadeManager").GetComponent<Fading>().BeginFade(1);
        yield return new WaitForSeconds(fadeTime);
        SceneManager.LoadScene("Stage_Portal");

    }

    public IEnumerator Key_1()
    {

        player_button_1.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        player_button_1.SetActive(false);

    }

    public IEnumerator Key_2()
    {

        player_button_2.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        player_button_2.SetActive(false);

    }

    public IEnumerator Key_3()
    {

        player_button_3.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        player_button_3.SetActive(false);

    }

    public IEnumerator Key_4()
    {

        player_button_4.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        player_button_4.SetActive(false);

    }

}
