using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomRotate : MonoBehaviour {

	// Use this for initialization
	void Start () {
		this.transform.localRotation = Quaternion.EulerAngles(Random.Range(-1,1), Random.Range(-5, 5), Random.Range(-1, 1));
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
