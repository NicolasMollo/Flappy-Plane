using UnityEngine;


public enum SceneType : byte
{
    TestScene,
    SampleScene,
    GameScene,
    MenuScene,
    Last
}

namespace Database
{

    [CreateAssetMenu(menuName = "Create Database/Scene")]
    public class DatabaseScene : ScriptableObject
    {

        [SerializeField]
        [Tooltip("Scene name (CASE SENSITIVE)")]
        private string sceneName = string.Empty;
        public string SceneName
        {
            get => sceneName;
        }


        [SerializeField]
        [Tooltip("Scene index")]
        private int sceneIndex = 0;
        public int SceneIndex
        {
            get => sceneIndex;
        }


        [SerializeField]
        [Tooltip("Scene type")]
        private SceneType sceneType = SceneType.Last;
        public SceneType SceneType
        {
            get => sceneType;
        }

    }

}