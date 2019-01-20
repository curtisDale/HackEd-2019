using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class winGame : MonoBehaviour {
	public GameObject winText1;
	public GameObject winText2;
	AudioSource src;
    
    
    
	// Use this for initialization
	void Start () {
		winText1.GetComponent<Text>().enabled = false;
		winText2.GetComponent<Text>().enabled = false;
		src = this.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter (Collider other)
	{
		src.Play();
		winText1.GetComponent<Text>().enabled = true;
		winText2.GetComponent<Text>().enabled = true;
	}
}
