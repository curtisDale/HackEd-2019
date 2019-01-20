using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class startGame : MonoBehaviour {
	public GameObject player;
	public GameObject camera;
	public Transform spawnPoint;
	public GameObject canvas;
	bool gameTriggered;
	public float travelSpeed;
	public float sequenceTime;
	public bool beganOnce;


	// Use this for initialization
	void Start () {
		player.GetComponent<Rigidbody>().useGravity = false;
		player.GetComponent<characterController>().enabled = false;
        camera.GetComponent<fpLookControl>().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetButtonDown("Jump") && gameTriggered == false && !beganOnce)
		{
			StartCoroutine(StartSequence());
		}
		if (gameTriggered)
		{
			player.transform.position = Vector3.Lerp(player.transform.position, spawnPoint.position, Time.deltaTime * travelSpeed);
		}
		if (player.transform.position == spawnPoint.position)
		{
			gameTriggered = false;
		}
	}
	IEnumerator StartSequence ()
	{
		beganOnce = true;
		gameTriggered = true;
		yield return new WaitForSeconds(sequenceTime);
		canvas.SetActive(false);
		player.GetComponent<characterController>().enabled = true;
		camera.GetComponent<fpLookControl>().enabled = true;
		player.GetComponent<Rigidbody>().useGravity = true;
		gameTriggered = false;
	}
}
