using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class FezMove_Mac : MonoBehaviour {

	private int Horizontal = 0;

	public Animator anim;
	public float MovementSpeed = 5f;
	public float Gravity = 1f;
	public CharacterController charController;
	private FacingDirection _myFacingDirection;
	public float JumpHeight = 0f;
	public bool _jumping = false;
	private float degree = 0;

	private int jumpcount = 0;
	private bool isGrounded;

	public AudioSource audio_jump;
	public AudioSource audio_interact;

	public FacingDirection CmdFacingDirection {

		set{ _myFacingDirection = value; 
		}

	}

	// Update is called once per frame
	void Update () {

		if (Input.GetAxis ("Horizontal") < 0)
			Horizontal = -1;
		else if (Input.GetAxis ("Horizontal") > 0)
			Horizontal = 1;
		else
			Horizontal = 0;
		/*
		if (Input.GetKeyDown (KeyCode.Space) && jumpcount == 0) 
		{
			_jumping = true;
			StartCoroutine(JumpingWait());
			jumpcount = 1;

		}
        */
		if ((Input.GetAxis("Right_Trigger_Mac") == 1) && jumpcount == 0) 
		{
			_jumping = true;
			StartCoroutine(JumpingWait());
			jumpcount = 1;
			audio_jump.Play();
		}

		if(anim)
		{
			anim.SetInteger("Horizontal", Horizontal);

			float moveFactor = MovementSpeed * Time.deltaTime * 10f;
			MoveCharacter(moveFactor);

		}

		if (charController.isGrounded) {
			jumpcount = 0;
		}

		transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, degree, 0), 8 * Time.deltaTime);

	}

	private void MoveCharacter(float moveFactor)
	{
		Vector3 trans = Vector3.zero;
		if(_myFacingDirection == FacingDirection.Front)
		{
			trans = new Vector3(Horizontal* moveFactor, -Gravity * moveFactor, 0f);
		}
		else if(_myFacingDirection == FacingDirection.Right)
		{
			trans = new Vector3(0f, -Gravity * moveFactor, Horizontal* moveFactor);
		}
		else if(_myFacingDirection == FacingDirection.Back)
		{
			trans = new Vector3(-Horizontal* moveFactor, -Gravity * moveFactor, 0f);
		}
		else if(_myFacingDirection == FacingDirection.Left)
		{
			trans = new Vector3(0f, -Gravity * moveFactor, -Horizontal* moveFactor);
		}
		if(_jumping)
		{
			transform.Translate( Vector3.up * JumpHeight * Time.deltaTime);
		}


		charController.SimpleMove (trans);
	}
	public void UpdateToFacingDirection(FacingDirection newDirection, float angle)
	{

		_myFacingDirection = newDirection;
		degree = angle;

	}

	public IEnumerator JumpingWait()
	{
		yield return new WaitForSeconds (0.35f);
		//Debug.Log ("Returned jump to false");
		_jumping = false;
	}

	public void OnTriggerStay(Collider other){

		if (other.gameObject.tag == "Lock") { 

			transform.parent = other.transform;

		}

		if (other.gameObject.name == "door_main_1")
		{

			if (Input.GetAxis("Right_Trigger_Mac") == 1)
			{

				StartCoroutine(LoadLevel_Portal_1());
				audio_interact.Play();

			}
		}

		if (other.gameObject.name == "door_boss_1")
		{

			if (Input.GetAxis("Right_Trigger_Mac") == 1)
			{

				StartCoroutine(LoadLevel_Boss_1());
				audio_interact.Play();

			}
		}

	}

	public void OnTriggerExit(Collider other) {

		if (other.gameObject.tag == "Lock")
		{
			transform.parent = null;

		}

	}

	public IEnumerator LoadLevel_Portal_1()
	{
		float fadeTime = GameObject.Find("FadeManager").GetComponent<Fading>().BeginFade(1);
		yield return new WaitForSeconds(fadeTime);
		SceneManager.LoadScene("Stage_earth-01");

	}

	public IEnumerator LoadLevel_Boss_1()
	{
		float fadeTime = GameObject.Find("FadeManager").GetComponent<Fading>().BeginFade(1);
		yield return new WaitForSeconds(fadeTime);
		SceneManager.LoadScene("Boss");

	}
}