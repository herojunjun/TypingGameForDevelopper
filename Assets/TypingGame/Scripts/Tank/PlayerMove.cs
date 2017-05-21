using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMove : MonoBehaviour {

	public Transform[] Targets;

	private NavMeshAgent navMeshAgent;
	private int nowTarget = 0;
	private bool movable = true;

	// Use this for initialization
	void Start () {
		navMeshAgent = GetComponent<NavMeshAgent> ();

	}
	
	// Update is called once per frame
	void Update () {
		if (movable) {
			navMeshAgent.SetDestination (Targets [nowTarget].position);
		} else {
			navMeshAgent.SetDestination (transform.position);
		}
		if (Input.GetKeyDown (KeyCode.X)) {
			movable = true;
		}
	}

	public void SetMovable(bool isMove){
		movable = isMove;
	}

	void OnTriggerEnter(Collider col){
		if (col.gameObject.transform.Find ("EnemyTank") != null) {
			movable = false;
			nowTarget++;
			if (nowTarget > Targets.Length) {
				nowTarget = 0;
			}
		}
	}
}
