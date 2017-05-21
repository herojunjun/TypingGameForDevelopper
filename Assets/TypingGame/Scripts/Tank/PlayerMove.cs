using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMove : MonoBehaviour {

	public Transform[] targets;

	// Use this for initialization
	void Start () {
		GetComponent<NavMeshAgent> ().SetDestination (targets [0].position);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
