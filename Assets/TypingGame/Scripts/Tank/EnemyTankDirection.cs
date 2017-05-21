using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TypingGame {
    public class EnemyTankDirection : MonoBehaviour {
        private GameObject _tankTurret;
        private GameObject _player;

        void Start () {
            _tankTurret = gameObject.transform.Find("TankRenderers").Find ("TankTurret").gameObject;
			_player = GameObject.Find ("PlayerTank");
        }

        void Update () {
            if (_tankTurret == null) {
                Debug.Log ("_tankTurret is Not found");
                return;
            }

			if (_player == null) {
				Debug.Log ("_player is Not found");
                return;
            }

			_tankTurret.transform.LookAt (_player.transform);
        }
    }
}
