using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



[RequireComponent(typeof(AudioSource))]

public class Cutscene_2 : MonoBehaviour
{

    public MovieTexture movie;
    private AudioSource audio;

    float countdown = 9f;

    // Use this for initialization
    void Start()
    {

        GetComponent<RawImage>().texture = movie as MovieTexture;
        audio = GetComponent<AudioSource>();
        audio.clip = movie.audioClip;
        movie.Play();
        audio.Play();

    }

    // Update is called once per frame
    void Update()
    {

        countdown -= Time.deltaTime;
        Debug.Log(countdown);

        if (countdown <= 0)
        {

            StartCoroutine(LoadLevel());

        }

        if (Input.GetKeyDown(KeyCode.Joystick1Button9))
        {

            StartCoroutine(LoadLevel());

        }

    }

    public IEnumerator LoadLevel()
    {
        float fadeTime = GameObject.Find("FadeManager").GetComponent<Fading>().BeginFade(1);
        yield return new WaitForSeconds(fadeTime);
        SceneManager.LoadScene(Application.loadedLevel + 1);

    }

}
