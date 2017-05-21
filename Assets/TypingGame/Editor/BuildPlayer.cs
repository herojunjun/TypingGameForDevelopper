using UnityEditor;

namespace TypingGame {
    public class BuildPlayer {
        [MenuItem ("Build/Build WebGL Player")]
        public static void BuildWebGlPlayer() {
            var levels = new string[] {
                "Assets/TypingGame/Scenes/GameScene.unity",
            };
            BuildPipeline.BuildPlayer(levels, "build_web",
                                      BuildTarget.WebGL, BuildOptions.None);
        }
    }
}
