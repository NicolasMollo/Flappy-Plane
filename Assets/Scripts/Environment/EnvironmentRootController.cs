using Managers;
using Sirenix.Utilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Device;
using UnityEngine.Rendering;


namespace Environment
{

    public enum EnvironmentType : byte
    {
        Grassy,
        Dirty,
        Snowy,
        Rocky,
        Frozen
    }

    [DisallowMultipleComponent]
    public class EnvironmentRootController : MonoBehaviour
    {

        #region Environment type

        private EnvironmentType environmentType /*= EnvironmentType.Rocky*/;
        public EnvironmentType _EnvironmentType
        {
            get => environmentType;
        }

        #endregion

        // Environment controllers references
        #region Environment controllers and them properties

        [SerializeField]
        private GroundController groundController = null;
        [SerializeField]
        private ObstaclesController obstaclesController = null;
        [SerializeField]
        private BackgroundController backgroundController = null;
        [SerializeField]
        private InteractablesController interactablesController = null;
        [SerializeField]
        private EnvironmentCollisionObjectController environmentCollisionObjectController = null;

        public GroundController GroundController
        {
            get => groundController;
        }
        public ObstaclesController ObstaclesController
        {
            get => obstaclesController;
        }
        public BackgroundController BackgroundController
        {
            get => backgroundController;
        }
        public InteractablesController InteractablesController
        {
            get => interactablesController;
        }
        public EnvironmentCollisionObjectController EnvironmentCollisionObjectController
        {
            get => environmentCollisionObjectController;
        }

        #endregion


        #region Lifecycle

        private void Start()
        {

            environmentType = GameManager.Instance.EnvironmentType;

            groundController.SetUp(environmentType);
            backgroundController.SetUp(environmentType);
            environmentCollisionObjectController.SetUp(groundController.GroundPiecesContainerControllers[0].SizeX +
                groundController.GroundPiecesContainerControllers[0].GroundPieceControllers[0].HalfSizeX * 0.5f);


        }


        private void Update()
        {

            groundController.UpdatePosition();
            backgroundController.UpdatePositions();

        }

        #endregion

    }


}