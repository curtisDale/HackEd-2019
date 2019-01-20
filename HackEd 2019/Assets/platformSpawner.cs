using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformSpawner : MonoBehaviour {
	public GameObject platform;
	public float timer = 0.01f;
	public float masterTimer = 10;
	public int randomX;
	public int randomY;
	public int randomZ;
	public  Vector3 randPos;
	float initTimer;

	// Use this for initialization
	void Start () {
		initTimer = timer;
	}
	
	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime;
		randPos = new Vector3(Random.Range(-randomX, randomX), Random.Range(-randomY, randomY), Random.Range(0, randomZ));
		masterTimer -= Time.deltaTime;
		if (masterTimer > 0)
		{
			
            if (timer < 0)
			{
				Instantiate(platform, randPos, transform.rotation);
				timer = initTimer;
			}
		}
	}
}
