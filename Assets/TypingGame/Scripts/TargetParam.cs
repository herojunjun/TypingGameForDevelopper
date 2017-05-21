using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetParam : MonoBehaviour {

	private int hp = 1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
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
}
