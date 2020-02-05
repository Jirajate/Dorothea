using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Health : MonoBehaviour {

    bool immue;
    public static bool heal_fireball;
    public static bool heal_fall;

	// Use this for initialization
	void Start () {

        heal_fireball = false;
        heal_fall = false;

	}
	
	// Update is called once per frame
	void Update () {

	}

    void OnTriggerEnter(Collider other) {

        if (!immue)
        {
			if (other.gameObject.tag == "fireball") {
				StartCoroutine(hurt());
                StartCoroutine(fireball());

			}
			if (other.gameObject.tag == "Check") {
				StartCoroutine(hurt());
                StartCoroutine(fall());

			}
        }
    }

    public IEnumerator hurt()
    {

        immue = true;
        yield return new WaitForSeconds(2f);
        immue = false;

    }

    public IEnumerator fireball()
    {

        heal_fireball = true;
        yield return new WaitForSeconds(0.25f);
        heal_fireball = false;

    }

    public IEnumerator fall()
    {

        heal_fall = true;
        yield return new WaitForSeconds(0.25f);
        heal_fall = false;


    }

    public IEnumerator LoadLevel()
    {
        yield return new WaitForSeconds(3f);
        float fadeTime = GameObject.Find("FadeManager").GetComponent<Fading>().BeginFade(1);
        yield return new WaitForSeconds(fadeTime);
        SceneManager.LoadScene("Boss");

    }

}
