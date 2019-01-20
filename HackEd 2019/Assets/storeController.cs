using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class storeController : MonoBehaviour {
	public GameObject store;
	public bool storeOpen;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.U))
        {
			
			storeOpen = !storeOpen;
			store.GetComponent<Canvas>().enabled = !store.GetComponent<Canvas>().enabled;
        }
		if (!storeOpen)
		{
			Cursor.lockState = CursorLockMode.None;
		}
		if (storeOpen)
        {
			Cursor.lockState = CursorLockMode.Locked;
        }

	}
}
