using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class characterController : MonoBehaviour {
	public int jumpCounter = 5;
	public AudioSource noBoost;
	public Text pointsText;
	public Transform spawnPoint;
	public Text jPtext;
	int jPlvl;
	int jPcost;
	public Text bUtext;
	int bUlvl;
	int bUcost;
	public Text bPtext;
	int bPlvl;
	int bPcost;
	public Text sText;
	int slvl;
	int sCost;

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
	public float boostAmount;
	float initBoostAmount;
	public float boostRefillRate;
	public float burnRate;
	public int platformPoints;
	public int distance;
	public int points;
	public int distancePoints;
	//public int storedPoints;
	//public GameObject storeController;

    
	// Use this for initialization
	void Start () {
		Cursor.visible = false;
		aS = this.GetComponent<AudioSource>();
		Time.timeScale = timeMultiplier;
		Time.fixedDeltaTime = 0.02f * Time.timeScale;
		initJumpCounter = jumpCounter;
		Cursor.lockState = CursorLockMode.Locked;
	}

	// Update is called once per frame
	void Update () {
	//	jPtext.text = jPcost.ToString();
	//	bUtext.text = bUcost.ToString();
	//	bPtext.text = bPcost.ToString();
	//	sText.text = sCost.ToString();
        
//		pointsText.text = points.ToString();
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			Cursor.visible = true;
			Cursor.lockState = CursorLockMode.None;
		}


		distancePoints = distance / 4;
		distance = Mathf.RoundToInt(Vector3.Distance(spawnPoint.position, this.transform.position));
		boostAmount = Mathf.Lerp(boostAmount, 1, Time.deltaTime * boostRefillRate);
		if (Input.GetButton("run"))
		{
			boostAmount -= Time.deltaTime * burnRate;
		}
		if (Input.GetButtonDown("run") && boostAmount <= 0)
		{
			noBoost.Play();
		}
		if (Input.GetButtonDown("run") && !grounded && boostAmount > 0)
		{
			aS.volume = 0.1f;
			aS.clip = airRelease;
			aS.Play();
		}
		if (Input.GetButtonDown("Fire1") && !grounded && boostAmount >0)
        {
			aS.volume = 0.1f;
            aS.clip = airRelease;
            aS.Play();
		}

		//if (!Input.GetButton("run") && !grounded &&!Input)
      //  {
       //     aS.clip = airRelease;
       //     aS.Stop();
       // }

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
			aS.volume = 0.05f;
			aS.clip = airRelease;
            aS.Play();
		}

		if (Input.GetButton("run") )
		{
			running = true;
		}
		if (!Input.GetButton("run"))
        {
            running = false;
        }
		if (running && boostAmount >0)
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
	private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "platform")
        {
			platformPoints = platformPoints + 2;
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
