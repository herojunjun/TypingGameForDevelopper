using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using System;
using TypingGame;

public class Shot : MonoBehaviour {

    private Transform tankTurret;
    public GameObject shell;

    // Use this for initialization
    void Start () {
        tankTurret = transform.Find("TankRenderers").Find("TankTurret");
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown (KeyCode.Z)) {
			ShotShell (MainGameManager.Instance.GetNowTarget());
        }
    }

    public void ShotShell(Transform target) {
        GameObject newShell = Instantiate (shell, tankTurret.position + Vector3.up * 0.3f, tankTurret.rotation);
        newShell.AddComponent<Rigidbody> ().useGravity = false;
		Transform enemyTurret = target.Find("EnemyTank").Find ("TankRenderers").Find ("TankTurret");
        newShell.GetComponent<Rigidbody> ().AddForce ((enemyTurret.position - newShell.transform.localPosition).normalized * 1000);
    }
}
