using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//スタート地点のバリアに適用するスクリプト
public class GameStarter : MonoBehaviour {

	private Material material;
	private bool isHit = false;

	// Use this for initialization
	void Start () {
		material = GetComponent<MeshRenderer> ().material;
	}
	
	// Update is called once per frame
	void Update () {
		if (isHit) {
			material.color *= new Color (1, 1, 1, 0.5f);
		}
	}

	void OnTreggerEnter(Collider col){
		if (col.tag == "Player") {
			isHit = true;
		}
	}
}
