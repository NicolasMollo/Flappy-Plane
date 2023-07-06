using Controllers;
using Database;
using Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;


/*
 (Tutti i test all'interno di questa lista sono quelli che hanno dato esito positivo)
 TEST ESEGUITI:
 - Spawn del GameManager
 - Duplicazione del GameManager al cambio di scena
 - Valore di currentScene al cambio di scena che viene riempito correttamente
 - Action "OnChangeScene" dello sceneManager funzionante
 - Riferimento ai dati (Data) del player

 */

namespace Test {

    public class TestScript : MonoBehaviour
    {

        void Start()
        {

            #region Spawn GameManager
            //if (Managers.GameManager.Instance != null)
            //{
            //    Debug.Log("L'Istanza di GameManager è viva");
            //}
            //else
            //{
            //    Debug.Log("L'Istanza di GameManager non c'è");
            //} 
            #endregion

        }

        void Update()
        {
            #region Duplicazione GameManager al cambio di scena
            //if (Input.GetKeyDown(KeyCode.Space))
            //{
            //    GameManager.Instance.sceneManager.ChangeScene(SceneType.SampleScene);
            //}
            //else if (Input.GetKeyDown(KeyCode.A))
            //{
            //    GameManager.Instance.sceneManager.ChangeScene(SceneType.TestScene);
            //}
            #endregion

            #region Valore di "currentScene" al cambio di scena
            //Debug.Log($"currentScene index: {GameManager.Instance.sceneManager.CurrentScene.SceneIndex}");
            //Debug.Log($"currentScene name: {GameManager.Instance.sceneManager.CurrentScene.name}");
            //Debug.Log($"currentScene tyoe: {GameManager.Instance.sceneManager.CurrentScene.SceneType.ToString()}");
            #endregion

            #region Valore dei valori di "Data" di player controller
            //Debug.Log($"Player name: {playerController.Data.P_name}");
            //Debug.Log($"Player jump speed: {playerController.Data.JumpSpeed}");
            #endregion
        }

        #region Test sul funzionamento della Action "OnChangeScene" dello sceneManager
        //private void OnEnable()
        //{

        //    AddListeners();

        //}


        //private void AddListeners()
        //{

        //    GameManager.Instance.sceneManager.OnChangeScene += PrintString;

        //}

        //private void OnDisable()
        //{

        //    RemoveListeners();

        //}
        //private void RemoveListeners()
        //{

        //    GameManager.Instance.sceneManager.OnChangeScene -= PrintString;

        //}


        //private void PrintString(DatabaseScene _scene)
        //{

        //    if (_scene.SceneType == SceneType.TestScene)
        //    {
        //        Debug.Log("This is a TestScene");
        //    }
        //    else
        //    {
        //        Debug.Log("This is a SampleScene");
        //    }

        //}
        #endregion

    }

}