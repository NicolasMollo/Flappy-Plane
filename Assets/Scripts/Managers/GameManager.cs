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

        [SerializeField]
        private Managers.SceneManager sceneManager = null;
        [SerializeField]
        private AudioManager audioManager = null;


        public Managers.SceneManager SceneManager
        {
            get => sceneManager;
        }
        public AudioManager AudioManager
        {
            get => audioManager;
        }

        #endregion

        public static GameManager Instance
        {
            get;
            private set;
        } = null;


        private EnvironmentType environmentType = EnvironmentType.Grassy;
        public EnvironmentType EnvironmentType
        {
            get => environmentType;
        }


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

        #endregion

    }


}