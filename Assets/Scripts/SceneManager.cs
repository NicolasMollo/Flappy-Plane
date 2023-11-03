using System;
using System.Collections.Generic;
using UnityEngine;
using Database;


namespace Managers
{

    [DisallowMultipleComponent]
    public class SceneManager : MonoBehaviour
    {
        [SerializeField]
        [Tooltip("List of game scenes")]
        private List<DatabaseScene> scenes = null;

        private DatabaseScene currentScene = null;
        public DatabaseScene CurrentScene
        {
            get => currentScene;
        }

        public Action<DatabaseScene> OnChangeScene = null;



        private void Start()
        {

            SetCurrentScene(SceneType.TestScene);

        }
        private void SetCurrentScene(SceneType _sceneType) {

            foreach (DatabaseScene scene in scenes)
            {
                if (scene.SceneType == _sceneType)
                {
                    currentScene = scene;
                    break;
                }
            }

        }


        #region API

        /// <summary>
        /// Method used to change the scene.
        /// It accepts a "SceneType" parameter which is an enumeration enclosing all the scenes present within the application.
        /// </summary>
        /// <param name="_scene"></param>
        public void ChangeScene(SceneType _scene)
        {

            UnityEngine.SceneManagement.SceneManager.LoadSceneAsync((int)_scene, UnityEngine.SceneManagement.LoadSceneMode.Single);
            SetCurrentScene(_scene);
            OnChangeScene?.Invoke(currentScene);

        }

        #endregion

    }

}