using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

namespace TypingGame {
    public class TankDirection : MonoBehaviour {
        private GameObject _tankTurret;
        private GameObject _enemy;

        void Start () {
            _tankTurret = gameObject.transform.Find("TankRenderers").Find ("TankTurret").gameObject;
        }

        void Update () {
            if (_enemy == null) {
                Debug.Log ("_enemy is Not found");
                return;
            }
			Quaternion targetAngle = Quaternion.LookRotation (_enemy.transform.position - _tankTurret.transform.position);
			_tankTurret.transform.rotation = Quaternion.Slerp (_tankTurret.transform.rotation, targetAngle, 0.1f);
        }

		public void SetTarget(Transform nextTarget){
			_enemy = nextTarget.gameObject;
		}
    }
}
