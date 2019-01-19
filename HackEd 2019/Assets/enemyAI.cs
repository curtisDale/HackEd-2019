using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyAI : MonoBehaviour {
	public Transform player;
	public float farSpeed;
	public float closeSpeed;
	public float cutOffDistance;
	public float lowTrunSpeed;
	public float highTurnSpeed;
    [Range(1,2)]
	public float randomizedSpeedFactor;
	float randomizedTurnSpeed;
	public float stumbleFrequency;
	public float stumbleDuration;
	public float stumbleSpeed;
	bool stumbling;
	float stumbleTimer;


	// Use this for initialization
	void Start () {
		float stumbleTimer = stumbleFrequency * Random.Range(-1.5f, 1.5f);
		randomizedTurnSpeed = Random.Range(lowTrunSpeed, highTurnSpeed);
		this.GetComponent<NavMeshAgent>().angularSpeed = randomizedTurnSpeed;
	}
	
	// Update is called once per frame
	void Update () {
		stumbleTimer -= Time.deltaTime;
		if (stumbleTimer<= 0 )
		{
			StartCoroutine(Stumble());
			stumbleTimer = (stumbleFrequency * Random.Range(-1.5f, 1.5f));
		}

		if (!stumbling)
		{
			float dist = Vector3.Distance(player.position, transform.position);
            this.GetComponent<NavMeshAgent>().destination = player.position;

            if (dist > cutOffDistance)
            {
                this.GetComponent<NavMeshAgent>().speed = closeSpeed;
            }
            else if (dist <= cutOffDistance)
            {
                this.GetComponent<NavMeshAgent>().speed = farSpeed;
            }

		}
		else if (stumbling)
		{
			this.GetComponent<NavMeshAgent>().speed = stumbleSpeed;
		}

	}
	IEnumerator Stumble ()
	{
		stumbling = true;
		yield return new WaitForSeconds(stumbleDuration);
		stumbling = false;
	}
}
