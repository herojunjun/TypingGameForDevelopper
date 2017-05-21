using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TypingGame {

    public class TypingSceneManager {
        private static TypingSceneManager _instance;
        private TypingSceneManager() {
        }

        public static TypingSceneManager Instance {
            get {
                if (_instance == null) {
                    _instance = new TypingSceneManager();
                }
                return _instance;
            }
        }

        public static int TitleSceneId = 0;
        public static int GameSceneId = 1;

        private AsyncOperation _loadScene;

        public bool LoadScene(int sceneId) {
            if (_loadScene != null) {
                if (!_loadScene.isDone) {
                    return false;
                }
            }
            _loadScene = SceneManager.LoadSceneAsync (sceneId, LoadSceneMode.Single);
            return true;
        }
    }

}
