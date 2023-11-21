using Managers;
using UnityEngine;


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
        private EnvironmentCollisionObjectController groundCollisionObjectController = null;
        [SerializeField]
        private EnvironmentCollisionObjectController backgroundCollisionObjectController = null;

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
        public EnvironmentCollisionObjectController GroundCollisionObjectController
        {
            get => groundCollisionObjectController;
        }
        public EnvironmentCollisionObjectController BackgroundCollisionObjectController
        {
            get => backgroundCollisionObjectController;
        }

        #endregion


        #region Lifecycle

        private void Start()
        {

            environmentType = GameManager.Instance.EnvironmentType;

            // Ground
            groundController.SetUp(environmentType);
            groundCollisionObjectController.SetUp(groundController.GroundPiecesContainerControllers[0].SizeX +
                groundController.GroundPiecesContainerControllers[0].GroundPieceControllers[0].HalfSizeX * 0.5f);

            // Background
            backgroundController.SetUp(environmentType);
            backgroundCollisionObjectController.SetUp(backgroundController.BackgroundPiecesContainerControllers[0].SkySize.x +
                backgroundController.BackgroundPiecesContainerControllers[0].SkyController.TriggerCollider.Size.x);

            // Obstacles

        }


        private void Update()
        {

            groundController.UpdatePosition();
            backgroundController.UpdatePositions();

        }

        #endregion

    }


}