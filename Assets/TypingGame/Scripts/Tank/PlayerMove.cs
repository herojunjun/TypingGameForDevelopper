using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMove : MonoBehaviour {

	public Transform[] Targets;

	private NavMeshAgent navMeshAgent;
	private int nowTarget = 0;

	// Use this for initialization
	void Start () {
		navMeshAgent = GetComponent<NavMeshAgent> ();
		navMeshAgent.SetDestination (Targets [0].position);

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider col){
		if (col.gameObject.transform.Find ("EnemyTank") != null) {
			Debug.Break ();
		}
	}
}
