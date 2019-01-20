using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class footStepController : MonoBehaviour {
	public AudioClip[] sounds;
	AudioSource src;

	// Use this for initialization
	void Start () {
		src = this.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	private void OnTriggerEnter(Collider collision)
	{
		if (collision.transform.tag == "ground")
		{
			src.clip = sounds[Random.Range(0, sounds.Length)];
            src.Play();
		}

	}
}
