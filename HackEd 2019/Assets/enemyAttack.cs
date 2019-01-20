using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAttack : MonoBehaviour {
	public Animator animator;

	// Use this for initialization
	void Start () {
		animator = this.transform.parent.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	private void OnTriggerEnter(Collider other)
	{
		if (other.transform.tag == "player")
		{
			animator.SetTrigger("attack");
			other.GetComponent<characterController>().health -= 10;
		}


	}
}

