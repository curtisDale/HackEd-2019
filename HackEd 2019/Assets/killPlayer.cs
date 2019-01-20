using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killPlayer : MonoBehaviour {
	public GameObject player;
	Vector3 initPlayerPos;
	public GameObject startingText;
	public GameObject canvas;
	public GameObject camera;
	public Transform ship;

	// Use this for initialization
	void Start () {
		initPlayerPos = player.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	private void OnCollisionEnter(Collision collision)
	{
		if (collision.transform.tag == "player")
		{
			player.transform.position = initPlayerPos;
            player.GetComponent<characterController>().enabled = false;
            player.GetComponent<Rigidbody>().useGravity = false;
            startingText.GetComponent<startGame>().beganOnce = false;
            canvas.SetActive(true);
			camera.GetComponent<fpLookControl>().enabled = false;
			player.GetComponent<characterController>().boostAmount = 1;
			//player.GetComponent<characterController>().storedPoints += player.GetComponent<characterController>().points;
			camera.transform.LookAt(ship);
		}

	}
}
