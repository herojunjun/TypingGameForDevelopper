using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using TypingGame;

public class PlayerMove : MonoBehaviour {
	

	private NavMeshAgent navMeshAgent;
	private bool movable = true;

	// Use this for initialization
	void Start () {
		navMeshAgent = GetComponent<NavMeshAgent> ();

	}
	
	// Update is called once per frame
	void Update () {
		Camera.main.transform.Translate (new Vector3 (0, Mathf.Sin (Time.frameCount) * 0.005f, 0));
	}

	public void SetTarget(Transform nextTarget){
		navMeshAgent.SetDestination (nextTarget.position);
		movable = true;
	}
		
	void OnTriggerEnter(Collider col){
		if (col.gameObject.transform.Find ("EnemyTank") != null) {
			navMeshAgent.SetDestination (transform.position);
			MainGameManager.Instance.NextQuestion ();
			movable = false;
		}
	}
}
