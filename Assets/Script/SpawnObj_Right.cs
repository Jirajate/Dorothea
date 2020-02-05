using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObj_Right : MonoBehaviour {

	public GameObject fireball;
	public Vector3 center;
	public Vector3 size;

	private static FacingDirection face;
	int Toint;

    int i = -18;
	// Use this for initialization
	void Start () {

		InvokeRepeating ("spawn", 2f, 0.75f);
        InvokeRepeating ("Rage_Trigger", 40f, 80f);

	}

	// Update is called once per frame
	void Update () {

		face = FezManager.facingDirection;
		Toint = (int)face;

	}

	public void spawn(){
		if (Toint == 1) {
			Vector3 pos = center + new Vector3 (Random.Range (-size.x / 2, size.x / 2), Random.Range (-size.y / 2, size.y / 2), Random.Range (-size.z / 2, size.z / 2));
			Instantiate (fireball, pos, Quaternion.identity);
		}
	}

	void OnDrawGizmos(){

		Gizmos.color = Color.red;
		Gizmos.DrawCube (center, size);

	}

    public void Rage_Trigger()
    {

        InvokeRepeating("Rage_Spawn", 0f, 0.125f);

    }

    public void Rage_Spawn()
    {

        if (i <= 0)
        {
            Instantiate(fireball, new Vector3(11, 70, i), Quaternion.Euler(0, 0, 0));
            i++;
        }

        else if (i > 0)
        {

            CancelInvoke("Rage_Spawn");
            i = -18;
        }
    }
}
