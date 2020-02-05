using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



[RequireComponent(typeof(AudioSource))]

public class Cutscene_3 : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
		StartCoroutine (LoadLevel ());
    }

    // Update is called once per frame
    void Update()
    {

    }

    public IEnumerator LoadLevel()
    {
		
		yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("Boss_Cutscene02");

    }

}
