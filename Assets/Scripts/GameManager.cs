using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Managers
{

    [DisallowMultipleComponent]
    public class GameManager : MonoBehaviour
    {

        // References to application managers
        public Managers.SceneManager sceneManager = null;



        public static GameManager Instance
        {
            get;
            private set;
        } = null;


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

    }


}