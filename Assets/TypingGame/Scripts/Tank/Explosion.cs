using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TypingGame;

public class Explosion : MonoBehaviour {

    public GameObject prefab;

    // Use this for initialization
    void Start () {

    }

    // Update is called once per frame
    void Update () {

    }

	void OnTriggerEnter(Collider col) {
		if (col.gameObject.tag == "Player" && gameObject.tag == "Enemy") {
			Instantiate (prefab, transform.position,Quaternion.identity);
			Destroy (col.gameObject);
			MainGameManager.Instance.SendEnemyStatus ();
		}
		if (col.gameObject.tag == "Enemy" && gameObject.tag == "Player") {
			Instantiate (prefab, transform.position,Quaternion.identity);
			Destroy (col.gameObject);
			MainGameManager.Instance.SendPlayerStatus ();
		}
    }
}
