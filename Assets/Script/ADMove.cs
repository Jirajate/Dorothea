using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ADMove : MonoBehaviour
{

    private int horizontal = 0;
    private int vertical = 0;
    public Animator anim;
    public float MovementSpeed = 5f;
    public float Gravity = 1f;
    public CharacterController charController;
    public float JumpHeight = 0f;
    public bool _jumping = false;
    private float degree = 0;

    private int jumpcount = 0;
    private bool isGrounded;
    private bool _climb;
    private bool check;

    public AudioSource audio_jump;
    public AudioSource audio_interact;

    bool canSwitchTarget;
    bool canSwitchTarget_2;
    bool canSwitchTarget_3;
    // Update is called once per frame

    void Start() {

        canSwitchTarget = true;
        canSwitchTarget_2 = true;
        canSwitchTarget_3 = true;
    
    }

    void Update()
    {

        if (Input.GetAxis("Horizontal") < 0)
            horizontal = -1;
        else if (Input.GetAxis("Horizontal") > 0)
            horizontal = 1;
        else
            horizontal = 0;

        if (Input.GetAxis("Vertical") < 0)
            vertical = -1;
        else if (Input.GetAxis("Vertical") > 0)
            vertical = 1;
        else
            vertical = 0;
        /*
        if (Input.GetKeyDown(KeyCode.Space) && jumpcount == 0)
        {
            _jumping = true;
            StartCoroutine(JumpingWait());
            jumpcount = 1;
        }
        */
		// Trigger || Right_Trigger_Mac
		if ((Input.GetAxis("Trigger") == -1) && jumpcount == 0)
        {
            StartCoroutine(SwitchTargetRoutine_3(1.0f));
        }

        if (anim)
        {

                anim.SetInteger("Horizontal", horizontal);
                anim.SetInteger("Vertical", vertical);
                anim.SetBool("Check", check);

            float moveFactor = MovementSpeed * Time.deltaTime * 10f;
            MoveCharacter(moveFactor);

        }

        CharacterController controller = GetComponent<CharacterController>();
        if (controller.isGrounded)
        {
            jumpcount = 0;
        }

        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, degree, 0), 8 * Time.deltaTime);
		//Trigger || Left_Trigger_Mac

        if (Input.GetAxisRaw("Trigger") == 1)
        {

            StartCoroutine(SwitchTargetRoutine(1.0f));

        }

    }

    private void MoveCharacter(float moveFactor)
    {
        Vector3 trans = Vector3.zero;
        trans = new Vector3(horizontal * moveFactor, -Gravity * moveFactor, 0f);

        if (_jumping)
        {
            transform.Translate(Vector3.up * JumpHeight * Time.deltaTime);
        }
        charController.SimpleMove(trans);
    }

    public IEnumerator JumpingWait()
    {
        yield return new WaitForSeconds(0.35f);
        _jumping = false;
    }

    void OnTriggerEnter(Collider other) {

        if (other.gameObject.tag == "Check") {

            check = true;
        
        }

    }

    void OnTriggerStay(Collider other)
    {

        if (other.gameObject.tag == "Ladder")
        {

            jumpcount = 1;

            if (_climb == true)
            {
                anim.SetBool("Climb", _climb);

                if (Input.GetAxis("Vertical") > 0)
                {
                    transform.Translate(Vector3.up * 0.8f * Time.deltaTime);
                    Physics.gravity = new Vector3(0, 0F, 0);

                }

                if (Input.GetAxis("Vertical") < 0)
                {
                    transform.Translate(Vector3.down * 0.8f * Time.deltaTime);
                    Physics.gravity = new Vector3(0, 0F, 0);

                }

                if (Input.GetAxis("Horizontal") > 0)
                {
                    transform.Translate(Vector3.right * 0.7f * Time.deltaTime);
                    Physics.gravity = new Vector3(0, 0F, 0);

                }

                if (Input.GetAxis("Horizontal") < 0)
                {
                    transform.Translate(Vector3.left * 0.7f * Time.deltaTime);
                    Physics.gravity = new Vector3(0, 0F, 0);

                }
            }
        }

        if (other.gameObject.tag == "Door")
        {

			if (Input.GetAxis("Trigger") == 1)
            {

                StartCoroutine(SwitchTargetRoutine_2(1.0f));

            }
        }

        if (other.gameObject.tag == "Ladblock")
        {

            Physics.gravity = new Vector3(0, -10F, 0);
            _climb = false;

        }

    }

    void OnTriggerExit(Collider other)
    {
		if (other.gameObject.tag == "Ladder") {
			Physics.gravity = new Vector3 (0, -10F, 0);
			jumpcount = 0;
			anim.SetBool ("Climb", _climb);
		}
    }

        public IEnumerator LoadLevel()
    {
        float fadeTime = GameObject.Find("FadeManager").GetComponent<Fading>().BeginFade(1);
        yield return new WaitForSeconds(fadeTime);
        SceneManager.LoadScene(Application.loadedLevel + 1);

    }

        public IEnumerator SwitchTargetRoutine(float duration)
        {

            if (canSwitchTarget)
            {
                canSwitchTarget = false;
                SwitchTarget();
                yield return new WaitForSeconds(duration);
                canSwitchTarget = true;
            }
            else
            {
                yield return new WaitForSeconds(0f);
            }

        }

        public void SwitchTarget()
        {

            if (_climb == false)
            {

                _climb = true;

            }

            else if (_climb == true)
            {

                _climb = false;

            }

        }

        public IEnumerator SwitchTargetRoutine_2(float duration)
        {

            if (canSwitchTarget_2)
            {
                canSwitchTarget_2 = false;
                SwitchTarget_2();
                yield return new WaitForSeconds(duration);
                canSwitchTarget_2 = true;
            }
            else
            {
                yield return new WaitForSeconds(0f);
            }

        }

        public void SwitchTarget_2()
        {

            StartCoroutine(LoadLevel());
            audio_interact.Play();

        }

        public IEnumerator SwitchTargetRoutine_3(float duration)
        {

            if (canSwitchTarget_3)
            {
                canSwitchTarget_3 = false;
                SwitchTarget_3();
                yield return new WaitForSeconds(duration);
                canSwitchTarget_3 = true;
            }
            else
            {
                yield return new WaitForSeconds(0f);
            }

        }

        public void SwitchTarget_3()
        {

            _jumping = true;
            StartCoroutine(JumpingWait());
            jumpcount = 1;
            audio_jump.Play();

        }

}