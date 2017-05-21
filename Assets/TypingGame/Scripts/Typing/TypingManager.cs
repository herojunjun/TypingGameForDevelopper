using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

namespace TypingGame {

    public class TypingManager : MonoBehaviour {
        private string _targetString;
        private int _userIndex;
        private TargetStringGenerator _generator = new TargetStringGenerator();
        private string _missMessage;

        public int SuccessCount {
            get;
            private set;
        }
        public int MissCount {
            get;
            private set;
        }

        public void NextQuestion() {
            _userIndex = 0;
            _targetString = _generator.GetNext ();
        }

        void Update() {
            if (string.IsNullOrEmpty (_targetString)) {
                // 暫定処理
                NextQuestion ();
                return;
            }

            if (Input.GetKeyDown (_targetString[_userIndex].ToString())) {
                _missMessage = null;
                if (_userIndex < _targetString.Length - 1) {
                    _userIndex++;
                    SuccessCount++;
                } else {
                    // TODO: 成功をプレイヤーに伝える
                    // 暫定処理
                    NextQuestion ();
                }
            } else {
                for (var c = 'a'; c < 'z'; c++) {
                    if (Input.GetKeyDown (c.ToString ())) {
                        MissCount++;
                        _missMessage = string.Format ("Miss: {0}", c);
                    }
                }
            }

            // TODO: 移動
            if (Input.GetKeyDown (KeyCode.Escape)) {
                TypingSceneManager.Instance.LoadScene (TypingSceneManager.TitleSceneId);
            }
        }

        const float boxWidth = 200.0f;
        const float boxHeight = 100.0f;
        void OnGUI () {
            if (string.IsNullOrEmpty (_targetString)) {
                return;
            }

            var center = new Rect (Screen.width / 2 - boxWidth / 2, Screen.height / 2 - boxHeight / 2, boxWidth, boxHeight);
            GUI.Box(center,
                    string.Format("{0}\n{1}\n{2}", _targetString, _targetString.Substring(0, _userIndex), _missMessage));
        }

    }

    public class TargetStringGenerator {
        public readonly static List<string> DefineSymbols = new List<string> {
            "include",
            "define",
            "int",
            "float",
            "double",
            "bool",
        };

        private Random _random = new Random();
        private int _currentId;

        public string GetNext() {
            int prevId = _currentId;
            while (prevId == _currentId) {
                _currentId = _random.Next (DefineSymbols.Count);
            }
            return DefineSymbols[_currentId];
        }
    }
}