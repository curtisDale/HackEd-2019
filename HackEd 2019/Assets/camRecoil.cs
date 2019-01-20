using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camRecoil : MonoBehaviour {
	public GameObject gun;
	public float recoilSpeed;
	Vector3 initPos;
	public Vector3 camRecoilPoint;

	// Use this for initialization
	void Start () {
		initPos = this.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		transform.localPosition = Vector3.Lerp(transform.localPosition, initPos, Time.deltaTime * recoilSpeed);
		if (gun.GetComponent<anyGun>().fired == true)
		{
			transform.localPosition = camRecoilPoint;	
		}
	}
}
