using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Cutscene_4 : MonoBehaviour
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

		yield return new WaitForSeconds(7f);
		SceneManager.LoadScene("Menu_cube");

	}

}
