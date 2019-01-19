using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour {
	public float speed = 28;
	public float damage = 10;
	public float health = 5;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector3.forward * (Time.deltaTime * speed));
		if (health <= 0)
		{
			Destroy(this.gameObject);
		}
	}
	private void OnCollisionEnter(Collision collision)
	{
		health -= 1;
		if (collision.transform.tag == "enemy")
		{
			if (collision.gameObject.GetComponent<enemyHealth>().health > 0)
            {
                collision.gameObject.GetComponent<enemyHealth>().health -= damage;
            }

			if (collision.gameObject.GetComponent<enemyHealth>().health <= 0)
			{
				Destroy(collision.gameObject);
			}


		}
	}
}
