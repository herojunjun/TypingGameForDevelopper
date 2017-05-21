using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TypingGame {

    public class TitleScene : MonoBehaviour {
        private string _targetString;
        private int _userIndex;
        private TargetStringGenerator _generator = new TargetStringGenerator();

        void Start () {
            _targetString = _generator.GetNext();
        }

        void Update() {
            if (Input.GetKeyDown (KeyCode.Space)) {
                TypingSceneManager.Instance.LoadScene (TypingSceneManager.GameSceneId);
            }
        }

        const float boxWidth = 200.0f;
        const float boxHeight = 100.0f;
        void OnGUI () {
            var center = new Rect (Screen.width / 2 - boxWidth / 2, Screen.height / 2 - boxHeight / 2, boxWidth, boxHeight);
            GUI.Box(center,
                    string.Format("ゲームスタートなら Push Space!"));

        }
    }
}
