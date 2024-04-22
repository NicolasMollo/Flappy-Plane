using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Environment
{

    [DisallowMultipleComponent]
    public class ObstaclesController : MonoBehaviour
    {

        [SerializeField]
        private ObstaclePiecesContainerController containerController = null;


        private void Start()
        {

            containerController.SetUp();

        }

    }

}