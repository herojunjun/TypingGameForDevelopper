﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditorInternal;

namespace TypingGame {
    public class MainGameManager {
        private static MainGameManager _instance;
        private MainGameManager() {
        }

        public static MainGameManager Instance {
            get {
                if (_instance == null) {
                    _instance = new MainGameManager();
                }
                return _instance;
            }
        }

        private TypingManager _typingManager;
        private int _damageCount;
        private int _killCount;
		private bool _isPlaying;

		private GameObject playerTank;
		private PlayerMove playerMove;
		private Transform[] Targets;
		private int _nowTarget = 0;

        /// <summary>
        /// ゲームを初期化する。
        /// </summary>
        public void Initialize() {
            _typingManager = GameObject.Find ("GameObject").GetComponent<TypingManager> ();
			GameObject targetSets = GameObject.Find ("TargetSets");
			Targets = new Transform[targetSets.transform.childCount];
			for (int i = 0; i < targetSets.transform.childCount; i++) {
				Targets [i] = targetSets.transform.GetChild (i);
			}
        }

        /// <summary>
        /// ゲームを開始する。
        /// </summary>
		public void GameStart() {
			playerTank = GameObject.FindGameObjectWithTag ("Player");
			playerMove = playerTank.GetComponent<PlayerMove> ();
			Debug.Log (Targets);
			playerTank.GetComponent<TankDirection> ().SetTarget (Targets [_nowTarget]);
            _isPlaying = true;
        }

        /// <summary>
        /// プレイ中のゲームをポーズする。
        /// ポーズ中のゲームをプレイする。
        /// </summary>
        public void GamePause() {
            if (_isPlaying) {
                _typingManager.Pause ();
            } else {
                _typingManager.Play ();
            }

            _isPlaying = !_isPlaying;
        }

        /// <summary>
        /// プレイヤーからステータスの変更を受け取る。
        /// </summary>
        public void SendPlayerStatus() {
            _damageCount++;

            if (false) {
                // 倒されたとき
                GameOver ();
            }
        }

        /// <summary>
        /// 敵からステータスの変更を受け取る。
        /// </summary>
        public void SendEnemyStatus() {
            if (false) {
                // 敵が生きているとき
                _typingManager.NextQuestion ();
            } else {
                // 敵を倒したとき
                _killCount++;
				playerMove.SetTarget (Targets [++_nowTarget]);
				playerTank.GetComponent<TankDirection> ().SetTarget (Targets [_nowTarget]);
            }
        }

        /// <summary>
        /// GameOverしたときに呼ばれる。
        /// </summary>
        public void GameOver() {
            _typingManager.Pause ();
            int score = CalcScore ();
        }

		public Transform GetNowTarget(){
			return Targets [_nowTarget];
		}

        private int CalcScore () {
            int successCount = _typingManager.SuccessCount;
            int missCount = _typingManager.MissCount;
            var score = ((float)successCount / (successCount + missCount)) * (_killCount * 10) - (_damageCount * 5);
            return Mathf.CeilToInt(score);
        }

    }
}
