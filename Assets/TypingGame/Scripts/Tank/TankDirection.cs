using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TypingGame {
    public class TankDirection : MonoBehaviour {
        private GameObject _tankTurret;
        private GameObject _enemy;

        void Start () {
            _tankTurret = gameObject.transform.Find("TankRenderers").Find ("TankTurret").gameObject;
			_enemy = GameObject.FindGameObjectWithTag ("Enemy");
        }

        void Update () {
            if (_tankTurret == null) {
                Debug.Log ("_tankTurret is Not found");
                return;
            }

            if (_enemy == null) {
                Debug.Log ("_enemy is Not found");
                return;
            }

            _tankTurret.transform.LookAt (_enemy.transform);
        }
    }
}
