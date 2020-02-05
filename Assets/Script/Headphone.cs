using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Headphone : MonoBehaviour {

    public GameObject press;
    public GameObject remove;

	// Use this for initialization
	void Start () {

        press.SetActive(false);

	}

    void OnTriggerStay(Collider other) {

        if (other.gameObject.tag == "Player") {

            press.SetActive(true);

            if (Input.GetAxis("Trigger") == 1)
            {
                StartCoroutine(LoadLevel());
            }

        }

    }

    void OnTriggerExit(Collider other) {

        press.SetActive(false);


    }

    public IEnumerator LoadLevel()
    {

        remove.SetActive(false);
        press.SetActive(false);
        float fadeTime = GameObject.Find("FadeManager").GetComponent<Fading>().BeginFade(1);
        yield return new WaitForSeconds(fadeTime);
        SceneManager.LoadScene(Application.loadedLevel + 1);

    }
}
