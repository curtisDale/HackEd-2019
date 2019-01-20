using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class anyGun : MonoBehaviour {
    public Transform aimPoint;
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
    bool aiming;
    public float aimSpeed;
    Camera camera;
    public float aimAmount;
    float initFOV;

	// Use this for initialization
	void Start () {
		firePoint = this.transform.GetChild(0).transform;
		initPos = this.transform.localPosition;
        camera = this.transform.parent.gameObject.GetComponent<Camera>();
        initFOV = camera.fieldOfView;
        
	}

	// Update is called once per frame
	void Update () {
        if (Input.GetButton("Fire2"))
        {
            aiming = true;
        }
        if (!Input.GetButton("Fire2"))
        {
            aiming = false;
        }
        
        transform.localPosition = Vector3.Lerp(transform.localPosition, initPos, Time.deltaTime * recoilSpeed);
		//RecoilHandler
        if (!aiming)
        {
            
            camera.fieldOfView = Mathf.Lerp(camera.fieldOfView, initFOV, Time.deltaTime * aimSpeed);
        }
        if (aiming)
        {
            camera.fieldOfView = Mathf.Lerp(camera.fieldOfView, aimAmount, Time.deltaTime * aimSpeed);
            print("aiming");
            //transform.localPosition = Vector3.Lerp(transform.localPosition, aimPoint.localPosition, Time.deltaTime * aimSpeed);
        }


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
