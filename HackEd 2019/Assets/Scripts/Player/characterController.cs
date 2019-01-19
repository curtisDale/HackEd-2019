using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterController : MonoBehaviour {
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
    
	// Use this for initialization
	void Start () {
		
		Cursor.lockState = CursorLockMode.Locked;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Jump"))
		{
			this.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * (jumpPower), ForceMode.Impulse);
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
}
