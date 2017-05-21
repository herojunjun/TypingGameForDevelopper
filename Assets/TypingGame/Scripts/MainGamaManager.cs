using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

		/// <summary>
		/// ゲームを初期化する。
		/// </summary>
		public void Initialize() {
		}

		/// <summary>
		/// ゲームを開始する。
		/// </summary>
		public void GameStart() {
		}

		/// <summary>
		/// プレイ中のゲームをポーズする。
		/// ポーズ中のゲームをプレイする。
		/// </summary>
		public void GamePause() {
		}

		/// <summary>
		/// GameOverしたときに呼ばれる。
		/// </summary>
		public void GameOver() {
		}
	}
}
