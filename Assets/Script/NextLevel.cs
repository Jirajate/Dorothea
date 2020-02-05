using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour {

    public GameObject MovePlat;
    public GameObject player;
    private float MoveSpeed = 3f;

    bool Move;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Move == true) {

            MovePlat.transform.Translate(Vector3.back * MoveSpeed * Time.deltaTime);
            player.transform.Translate(Vector3.right * MoveSpeed * Time.deltaTime);

        }

	}

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {

            Debug.Log("Enter");
            StartCoroutine(LoadLevel());

        }

    }

    public IEnumerator LoadLevel()
    {

        yield return new WaitForSeconds(1f);
        Move = true;
        yield return new WaitForSeconds(5f);
        float fadeTime = GameObject.Find("FadeManager").GetComponent<Fading>().BeginFade(1);
        yield return new WaitForSeconds(fadeTime);
        SceneManager.LoadScene(Application.loadedLevel + 1);

    }
}
