using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.CompilerServices;

public class TargetParam : MonoBehaviour {

	private int hp = 1;
	private float timer = 0;
	private bool isCount = true;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (isCount) {
			timer += Time.deltaTime;
		}
		if (timer > 3) {
			transform.GetChild(0).GetComponent<Shot>().ShotShell(GameObject.FindGameObjectWithTag("Player").transform);
			timer = 0;
		}
	}

	public void SetHp(int hp){
		this.hp = hp;
	}

	public int GetHp(){
		return hp;
	}

	public void Damage(int damage){
		hp -= damage;
	}

	void OnCollisionEnter(Collision col){
		isCount = true;
	}

	void OnCollisionExit(Collision col){
		isCount = false;
	}
}
