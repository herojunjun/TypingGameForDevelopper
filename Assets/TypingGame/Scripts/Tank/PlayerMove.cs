using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMove : MonoBehaviour {
	

	private NavMeshAgent navMeshAgent;
	private bool movable = true;

	// Use this for initialization
	void Start () {
		navMeshAgent = GetComponent<NavMeshAgent> ();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SetTarget(Transform nextTarget){
		navMeshAgent.SetDestination (nextTarget.position);
		movable = true;
	}
		
	void OnTriggerEnter(Collider col){
		if (col.gameObject.transform.Find ("EnemyTank") != null) {
			navMeshAgent.SetDestination (transform.position);
			movable = false;
		}
	}
}
