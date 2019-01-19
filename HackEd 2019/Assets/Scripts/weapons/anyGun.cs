using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class anyGun : MonoBehaviour {
	public Transform firePoint;
	public GameObject bullet;
	[Range(0, 100)]
	public float bulletSpeed;
	[Range(0, 1)]
	public float timeBetweenBullets;
	[Range(0, 100)]
	public float bulletDamage;
	[Range(0, 10)]
	public float bulletPenetration;
    [Range(0,20)]
	public float recoilSpeed;
	bool fired;
	public Vector3 recoilPosition;
	Vector3 initPos;

	// Use this for initialization
	void Start () {
		firePoint = this.transform.GetChild(0).transform;
		initPos = this.transform.localPosition;
        
	}

	// Update is called once per frame
	void Update () {
		//RecoilHandler
		transform.localPosition = Vector3.Lerp(transform.localPosition, initPos, Time.deltaTime * recoilSpeed);

        //FiresTheWeapon
		if (Input.GetButton("Fire1") && !fired)
		{
			StartCoroutine(FireGun());
		}
		
	}
	IEnumerator FireGun ()

	{
		
		fired = true;
		GameObject b = Instantiate(bullet, firePoint.position, firePoint.rotation);
		b.GetComponent<bullet>().speed = bulletSpeed;
		b.GetComponent<bullet>().damage = bulletDamage;
		b.GetComponent<bullet>().health = bulletPenetration;
		this.transform.localPosition = recoilPosition;
		yield return new WaitForSeconds(timeBetweenBullets);
		fired = false;
	}
}
