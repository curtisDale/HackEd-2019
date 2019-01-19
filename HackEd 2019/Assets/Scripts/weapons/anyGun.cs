using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class anyGun : MonoBehaviour {
	public Transform firePoint;
	public GameObject bullet;
	public float bulletSpeed;
	public float timeBetweenBullets;
	public float bulletDamage;
	public float bulletPenetration;
	bool fired;

	// Use this for initialization
	void Start () {
		firePoint = this.transform.GetChild(0).transform;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButton("Fire1") && !fired)
		{
			StartCoroutine(FireGun());
		}
		
	}
	IEnumerator FireGun ()

	{
		fired = true;
		Instantiate(bullet, firePoint.position, firePoint.rotation);
		yield return new WaitForSeconds(timeBetweenBullets);
		fired = false;
	}
}
