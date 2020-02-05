using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Boss_Cutscene : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        StartCoroutine(LoadLevel());
    }

    // Update is called once per frame
    void Update()
    {

    }

    public IEnumerator LoadLevel()
    {

        yield return new WaitForSeconds(13f);
        SceneManager.LoadScene("Boss");

    }

}
