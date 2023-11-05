using Database;
using Environment;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


namespace Managers
{

    [DisallowMultipleComponent]
    public class GameManager : MonoBehaviour
    {

        #region Managers and macro controllers with them properties

        private Managers.SceneManager sceneManager = null;
        private AudioManager audioManager = null;
        private EnvironmentRootController environmentRootController = null;
        private const string ENVIRONMENTROOTCONTROLLER_NAME = "EnvironmentRootController";

        public Managers.SceneManager SceneManager
        {
            get => sceneManager;
        }
        public AudioManager AudioManager
        {
            get => audioManager;
        }
        public EnvironmentRootController EnvironmentRootController
        {
            get => environmentRootController;
        }

        #endregion

        public static GameManager Instance
        {
            get;
            private set;
        } = null;



        #region Lifecycle

        private void Awake()
        {

            SetSingleton();
            SetUp();

        }

        private void SetSingleton()
        {

            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(this.gameObject);
            }

        }

        private void SetUp()
        {

            DontDestroyOnLoad(this.gameObject);

        }



        private void OnEnable()
        {

            AddListeners();

        }

        private void AddListeners()
        {

            sceneManager.OnChangeScene += FillEnvironmentRootControllerReference;
        
        }

        private void OnDisable()
        {

            RemoveListeners();

        }

        private void RemoveListeners()
        {

            sceneManager.OnChangeScene -= FillEnvironmentRootControllerReference;

        }

        private void FillEnvironmentRootControllerReference(DatabaseScene _currentScene)
        {

            if (_currentScene.SceneType == SceneType.GameScene)
            {
                environmentRootController = GameObject.Find(ENVIRONMENTROOTCONTROLLER_NAME).GetComponent<EnvironmentRootController>();
            }

        }

        #endregion

    }


}