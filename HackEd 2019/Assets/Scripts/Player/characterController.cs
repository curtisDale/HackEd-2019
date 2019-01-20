using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterController : MonoBehaviour {
	public int jumpCounter = 5;

	public bool grounded;
	public float health;
	public float healSpeed;
	[Range(0,10)]
	public float walkingSpeed;
	float speed;
    [Range(1,3)]
	public float runMultipllier;
	bool running;
    [Range(1,50)]
	public float acceleration;
    [Range(3,100)]
	public float jumpPower;
	int initJumpCounter;
	bool goingDown;
	public float slamPower;
	public float timeMultiplier;
	AudioSource aS;
	public AudioClip airRelease;
    
	// Use this for initialization
	void Start () {
		aS = this.GetComponent<AudioSource>();
		Time.timeScale = timeMultiplier;
		Time.fixedDeltaTime = 0.02f * Time.timeScale;
		initJumpCounter = jumpCounter;
		Cursor.lockState = CursorLockMode.Locked;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("run") && !grounded)
		{
			aS.volume = 0.1f;
			aS.clip = airRelease;
			aS.Play();
		}
		if (Input.GetButtonDown("Fire1") && !grounded)
        {
			aS.volume = 0.1f;
            aS.clip = airRelease;
            aS.Play();
		}

		if (!Input.GetButton("run") && !grounded)
        {
            aS.clip = airRelease;
            aS.Stop();
        }

		if (Input.GetButtonDown("Fire1") && !grounded)
		{
			goingDown = true;
			this.GetComponent<Rigidbody>().AddForce(Vector3.down * slamPower, ForceMode.Impulse);
		}

        if (grounded)
		{
			goingDown = false;
			jumpCounter = initJumpCounter;
		}
        


		//health = Mathf.Lerp(health, 30, Time.deltaTime * healSpeed);

		if (Input.GetButtonDown("Jump") && jumpCounter > 0)
		{
			this.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * (jumpPower), ForceMode.Impulse);
			jumpCounter -= 1;
		}

		if (Input.GetButton("run"))
		{
			running = true;
		}
		if (!Input.GetButton("run"))
        {
            running = false;
        }
        if (running)
		{
			speed = Mathf.Lerp(speed, (walkingSpeed * runMultipllier), Time.deltaTime * acceleration);
		}
		if (!running)
		{
			speed = walkingSpeed;
		}
       

		float translation = Input.GetAxis("Vertical") * speed;
		float straffe = Input.GetAxis("Horizontal") * speed;
		translation *= Time.deltaTime;
		straffe *= Time.deltaTime;

		transform.Translate(straffe, 0, translation);

       
	}
	private void OnCollisionStay(Collision collision)
	{
		if (collision.transform.tag == "platform")
		{
			grounded = true;
		}
	}
	private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.tag == "platform")
        {
            grounded = false;
        }
    }
}
