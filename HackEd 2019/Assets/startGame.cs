using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;

public class startGame : MonoBehaviour {
	public GameObject player;
	public GameObject camera;
	public Transform spawnPoint;
	public GameObject canvas;
	bool gameTriggered;
	public float travelSpeed;
	public float sequenceTime;
	public bool beganOnce;
	public GameObject timer;
	public GameObject explosion;
	public Transform exPoint;
	public GameObject winText1;
    public GameObject winText2;
	public ColorGrading colorGrading;

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
		winText1.GetComponent<Text>().enabled = false;
        winText2.GetComponent<Text>().enabled = false;
		Instantiate(explosion, exPoint.position, exPoint.rotation);
		yield return new WaitForSeconds(0.5f);
		timer.GetComponent<timerAndBar>().timeToComplete = 1.1f;
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
