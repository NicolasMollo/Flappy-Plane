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
            //    SceneManager.LoadSceneAsync("SampleScene", LoadSceneMode.Single);
            //}
            //else if (Input.GetKeyDown(KeyCode.A))
            //{
            //    SceneManager.LoadSceneAsync("TestScene", LoadSceneMode.Single);
            //}
            #endregion
        }

    }

}