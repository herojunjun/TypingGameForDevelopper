using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

namespace TypingGame {

    public class TypingGameManager : MonoBehaviour {

        private string _targetString;
        private int _userIndex;
        private TargetStringGenerator _generator = new TargetStringGenerator();

        void Start () {
            _targetString = _generator.GetNext();
        }

        void Update() {
            if (Input.GetKeyDown (_targetString[_userIndex].ToString())) {
                Debug.Log (_targetString[_userIndex]);
                if (_userIndex < _targetString.Length - 1) {
                    _userIndex++;
                } else {
                    _userIndex = 0;
                    _targetString = _generator.GetNext();
                }
            }
        }

        const float boxWidth = 200.0f;
        const float boxHeight = 100.0f;
        void OnGUI () {
            var center = new Rect (Screen.width / 2 - boxWidth / 2, Screen.height / 2 - boxHeight / 2, boxWidth, boxHeight);
            GUI.Box(center,
                    string.Format("「{0}」と入力しよう\n{1}", _targetString, _targetString.Substring(0, _userIndex)));
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

        public string GetNext() {
            return DefineSymbols[_random.Next (DefineSymbols.Count)];
        }
    }
}