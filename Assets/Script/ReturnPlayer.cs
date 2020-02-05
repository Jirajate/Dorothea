using UnityEngine;
using System.Collections;

public class ReturnPlayer : MonoBehaviour {

	public Transform ReturnPoint_1;
	public Transform ReturnPoint_2;
	public Transform ReturnPoint_3;
	public Transform ReturnPoint_4;
	private static FacingDirection face;

    int Toint;

	void Update () {
		
		face = FezManager.facingDirection;
        Toint = (int)face;
	}

	public void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.name == "Player") {
            if (Toint == 0)
            {
				other.transform.position = ReturnPoint_1.position;
			}
            if (Toint == 1)
            {
                other.transform.position = ReturnPoint_2.position;
            }
            if (Toint == 2)
            {
                other.transform.position = ReturnPoint_3.position;
            }
            if (Toint == 3)
            {
                other.transform.position = ReturnPoint_4.position;
            }
		}
	}
}