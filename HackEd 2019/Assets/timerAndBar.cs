using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timerAndBar : MonoBehaviour {
	public float timeToComplete = 1;
	public float timeFactor = 1;
	public GameObject player;
	public GameObject startingText;
	public GameObject canvas;
	public GameObject camera;
	public Transform ship;
	Vector3 initPlayerPos;

	// Use this for initialization
	void Start () {
		initPlayerPos = player.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (player.transform.position != initPlayerPos)
		{
			timeToComplete -= (Time.deltaTime) * timeFactor;
            if (timeToComplete < 0)
            {
                timeToComplete = 1;
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
            this.GetComponent<Image>().fillAmount = timeToComplete;
		}

	}
}
