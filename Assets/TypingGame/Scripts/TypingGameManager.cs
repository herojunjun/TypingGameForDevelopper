using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TypingGame {

    public class TypingGameManager : MonoBehaviour {

        private string _targetString;
        private string[] _targetChars;
        private int _userIndex;

        // Use this for initialization
        void Start () {
            _targetString = "社長";
            _targetChars = new string[] {
                "syatyou",
                "syachou",
                "shatyou",
                "shachou",
            };
        }

        // Update is called once per frame
        void OnGUI () {
            GUI.Label (new Rect (0, 0, 100, 100),
                       string.Format("「{0}」\n{1}\nと入力しよう", _targetString, _targetChars[0]));
        }

        void Update() {
            if (Input.GetKeyDown (_targetChars[0][_userIndex].ToString())) {
                Debug.Log (_targetChars[0][_userIndex]);
                _userIndex++;
            }
        }
    }

}