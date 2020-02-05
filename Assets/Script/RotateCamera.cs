using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RotateCamera : MonoBehaviour {

    public GameObject player;
	public Transform target;
	private float speedMod = 0.4f;
	private Vector3 point;

	float countdown = 3.0f;
	float timeLeft = 14.97f;
    float x = 0.0f;

    private static int check;

    private float upSpeed = 4f;

	void Start () {
		point = target.transform.position;
	}

	void Update () {

		countdown -= Time.deltaTime;

        if (countdown <= 0)
        {
			timeLeft -= Time.deltaTime;
			if (timeLeft > x) {
                transform.RotateAround(point, new Vector3(0.0f, 1.0f, 0.0f), speedMod);
			}
		}

        if (timeLeft <= 0) {
            
            StartCoroutine(LoadLevel());
        
        }
	}

    public IEnumerator LoadLevel()
    {

        yield return new WaitForSeconds(2f);
        player.transform.Translate(Vector3.up * upSpeed * Time.deltaTime);
        yield return new WaitForSeconds(6f);
        float fadeTime = GameObject.Find("FadeManager").GetComponent<Fading>().BeginFade(1);
        yield return new WaitForSeconds(fadeTime);
        SceneManager.LoadScene(Application.loadedLevel + 1);

    }
}
