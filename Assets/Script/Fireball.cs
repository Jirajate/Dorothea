using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour {

    public GameObject fireball;
    public Transform Return;
    private GameObject instantiatedObj;

    private bool isCreate;

	// Use this for initialization
	void Start () {

        instantiatedObj = Instantiate(fireball, Return.position, Quaternion.Euler(0, 0, 0));

    }
	
	// Update is called once per frame
	void Update () {

	}

    void OnTriggerEnter(Collider other) {

        if (other.gameObject.tag == "fireball") {
           
            isCreate = false;
            StartCoroutine(Reset());

        }    
    }

    public IEnumerator Reset()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(GameObject.FindWithTag("fireball"));
        yield return new WaitForSeconds(0.5f);
        if (isCreate == false)
        {
            Instantiate(fireball, Return.position, Quaternion.Euler(0, 0, 0));
            isCreate = true;
        }
    }
}
