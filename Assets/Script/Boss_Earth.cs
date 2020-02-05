using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Boss_Earth : MonoBehaviour {

    public GameObject player_button_A;
    public GameObject player_button_B;
    public GameObject player_button_X;
    public GameObject player_button_Y;

    public GameObject Head_Red;
    public GameObject Head_Orange;
    public GameObject Head_White;
    public GameObject Head_Hurt;

    public AudioSource beat_1;
    public AudioSource beat_button_1;
    public AudioSource beat_button_2;
    public AudioSource beat_combo;
    public AudioSource beat_delay;

    public Image Health_Bar;

    int i = 0;
    float boss_hp = 100;
    float amount = 0;
    int time = 0;
    int check = 0;
    int combo = 0;
    bool ready;

    bool hurt;

    private static bool heal_low;
    private static bool heal_high;

    float heal_amount = 0;
	// Use this for initialization
	void Start () {

        InvokeRepeating("SetRhythm", 2.1f, 0.5f);
		InvokeRepeating("SetSound", 2.1f, 2f);
        InvokeRepeating("RemoveRhythm", 2.35f, 0.5f);

        player_button_A.SetActive(false);
        player_button_B.SetActive(false);
        player_button_X.SetActive(false);
        player_button_Y.SetActive(false);

        ready = true;

        Head_Orange.SetActive(false);
        Head_White.SetActive(false);
        Head_Hurt.SetActive(false);

	}
	
	// Update is called once per frame
	void Update () {

        heal_low = Health.heal_fireball;
        heal_high = Health.heal_fall;

        if (boss_hp < 100)
        {
            if (heal_low == true)
            {

                StartCoroutine(gen_low());

            }

            if (heal_high == true)
            {

                StartCoroutine(gen_high());

            }
        }

        if (heal_amount > 0 && boss_hp < 100 && boss_hp > 0) {

            boss_hp = boss_hp + 0.5f;
            heal_amount = heal_amount - 0.5f;

        }
        else if (boss_hp >= 100) {

            heal_amount = 0;

        }

        if (heal_amount <= 0)
        {

            heal_amount = 0;

        }

        if (amount > 0) {
            boss_hp = boss_hp - 0.125f;
            amount = amount - 0.125f;
        }

        if (amount <= 0)
        {
            amount = 0;
        }

        Health_Bar.fillAmount = boss_hp / 100f;

        if (boss_hp <= 0) {
            StartCoroutine(LoadLevel());
        }

        if (Input.GetKeyDown(KeyCode.Joystick1Button0)) {
            StartCoroutine(button_A());
        }

        if (Input.GetKeyDown(KeyCode.Joystick1Button1))
        {
            StartCoroutine(button_B());
        }

        if (Input.GetKeyDown(KeyCode.Joystick1Button2))
        {
            StartCoroutine(button_X());
        }

        if (Input.GetKeyDown(KeyCode.Joystick1Button3))
        {
            StartCoroutine(button_Y());
        }

        if (i == 1) {
            if (ready == true)
            {
                if (check == 0 )
                {
					if (Input.GetKeyDown(KeyCode.Joystick1Button0) && boss_hp > 0) {
                        check = 1;
                        time = 2;
                        Debug.Log("1");
                        StartCoroutine(White());

                    }
                }
                //------------------------------------------
                else if (check == 1)
                {
                    if (Input.GetKeyDown(KeyCode.Joystick1Button0) && time > 0)
                    {
                        Debug.Log("2");
                        time = 2;
                        check = 2;
                        StartCoroutine(White());


                    }
                    else if(Input.GetKeyDown(KeyCode.Joystick1Button1) || Input.GetKeyDown(KeyCode.Joystick1Button2) || Input.GetKeyDown(KeyCode.Joystick1Button3) || time <= 0){
                        fail();
                    }
                }
                //------------------------------------------
                else if (check == 2)
                {
                    if (Input.GetKeyDown(KeyCode.Joystick1Button2) && time > 0) {
                        Debug.Log("3");
                        time = 2;
                        check = 3;
                        StartCoroutine(White());

                    }
                    else if (Input.GetKeyDown(KeyCode.Joystick1Button0) || Input.GetKeyDown(KeyCode.Joystick1Button1) || Input.GetKeyDown(KeyCode.Joystick1Button3) || time <= 0)
                    {
                        fail();
                    }
                }
                //------------------------------------------
                else if (check == 3)
                {
                    if (Input.GetKeyDown(KeyCode.Joystick1Button0) && time > 0) {
                        check = 4;
                        combo++;
                        Debug.Log("Combo : " + combo);
                        Debug.Log("4");
                        StartCoroutine(White());
                        StartCoroutine(Delay());
                        StartCoroutine(Play_Delay());
                    }
                    else if (Input.GetKeyDown(KeyCode.Joystick1Button1) || Input.GetKeyDown(KeyCode.Joystick1Button2) || Input.GetKeyDown(KeyCode.Joystick1Button3) || time <= 0)
                    {
                        fail();
                    }
                }
            }
        }

        else if (i == 0 || !ready) {
            if (Input.GetKeyDown(KeyCode.Joystick1Button0) || Input.GetKeyDown(KeyCode.Joystick1Button1) || Input.GetKeyDown(KeyCode.Joystick1Button2) || Input.GetKeyDown(KeyCode.Joystick1Button3)) {
                fail();
            }
        }

        if (time == 0) {

            fail();
        
        }

	}

	void SetSound() {

		beat_1.Play();

	}

    void SetRhythm() {

        if (!hurt)
        {
            i = 1;
            time--;
            Head_Orange.SetActive(true);
            Head_Red.SetActive(false);
            Head_Hurt.SetActive(false);
        }

    }

    void RemoveRhythm()
    {


        if (!hurt)
        {
            i = 0;
            Head_Orange.SetActive(false);
            Head_Red.SetActive(true);
            Head_Hurt.SetActive(false);

        }
    }

    void fail() {

        check = 0;
        combo = 0;
        time = 0;

    }

    public IEnumerator White()
    {
        Head_White.SetActive(true);
        Head_Red.SetActive(false);
        Head_Orange.SetActive(false);
        yield return new WaitForSeconds(0.25f);
        Head_White.SetActive(false);

    }

    public IEnumerator button_A()
    {

        player_button_A.SetActive(true);
        beat_button_1.Play();
        yield return new WaitForSeconds(0.4f);
        player_button_A.SetActive(false);

    }

    public IEnumerator button_B()
    {

        player_button_B.SetActive(true);
        yield return new WaitForSeconds(0.4f);
        player_button_B.SetActive(false);

    }

    public IEnumerator button_X()
    {

        player_button_X.SetActive(true);
        beat_button_2.Play();
        yield return new WaitForSeconds(0.4f);
        player_button_X.SetActive(false);
    }

    public IEnumerator button_Y()
    {
        player_button_Y.SetActive(true);
        yield return new WaitForSeconds(0.4f);
        player_button_Y.SetActive(false);
    }

    public IEnumerator Play_Delay() {

        yield return new WaitForSeconds(0.4f);
        beat_combo.Play();

    }

    public IEnumerator Delay() {

        if (combo == 1) {
            amount = 8;
        }

        else if (combo == 2)
        {
            amount = 10;
        }

        else if (combo >= 3)
        {
            amount = 12;
        }

        Head_Orange.SetActive(false);
        Head_Red.SetActive(false);
        Head_White.SetActive(false);
        Head_Hurt.SetActive(true);
        hurt = true;
        yield return new WaitForSeconds(0.5f);
        hurt = false;
        ready = false;
        Debug.Log("Wait");
        time = 6;
        yield return new WaitForSeconds(1.5f);
        Head_Hurt.SetActive(false);

        Debug.Log("Ready");
        check = 0;
        ready = true;
    }

    public IEnumerator gen_low()
    {

        heal_amount = 1;
        yield return new WaitForSeconds(2f);

    }

    public IEnumerator gen_high()
    {

        heal_amount = 2;
        yield return new WaitForSeconds(2f);

    }

    public IEnumerator LoadLevel()
    {
        yield return new WaitForSeconds(3f);
        float fadeTime = GameObject.Find("FadeManager").GetComponent<Fading>().BeginFade(1);
        yield return new WaitForSeconds(fadeTime);
        SceneManager.LoadScene("Boss_Cutscene01");

    }

}
