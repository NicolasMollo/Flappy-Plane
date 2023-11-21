using UnityEngine;


namespace Environment
{

    [DisallowMultipleComponent]
    public class BackgroundController : MonoBehaviour
    {

        #region Prefabs

        [Header("BACKGROUND PREFABS")]

        [SerializeField]
        [Tooltip("Prefab of the grassy background")]
        private GameObject prefabGrassyBackground = null;

        [SerializeField]
        [Tooltip("Prefab of the dirty background")]
        private GameObject prefabDirtyBackground = null;

        [SerializeField]
        [Tooltip("Prefab of the snowy background")]
        private GameObject prefabSnowyBackground = null;

        [SerializeField]
        [Tooltip("Prefab of the rocky background")]
        private GameObject prefabRockyBackground = null;

        [SerializeField]
        [Tooltip("Prefab of the frozen background")]
        private GameObject prefabFrozenBackground = null;

        #endregion

        #region Background controller data

        [Header("BACKGROUND DATA")]

        [SerializeField]
        [Tooltip("Speed of movement of sky objects")]
        private float skyMovementSpeed = 0f;

        [SerializeField]
        [Tooltip("Speed of movement of cloud objects")]
        private float cloudsMovementSpeed = 0.5f;

        [SerializeField]
        [Tooltip("Speed of movement of mountain objects")]
        private float mountainsMovementSpeed = 1.0f;

        #endregion

        private BackgroundPiecesContainerController[] backgroundPiecesContainerControllers = null;
        public BackgroundPiecesContainerController[] BackgroundPiecesContainerControllers
        {
            get => backgroundPiecesContainerControllers;
        }
        private BackgroundPieceController[] skyControllers = null;
        private BackgroundPieceController[] cloudsControllers = null;
        private BackgroundPieceController[] mountainsControllers = null;

        private const int NUMBER_OF_BACKGROUNDPIECESCONTAINERCONTROLLER = 2;
        private Vector3 backgroundPosition = Vector3.zero;



        #region Lifecycle

        private void AddListeners()
        {

            for (int i = 0; i < BackgroundPiecesContainerControllers.Length; i++)
            {
                backgroundPiecesContainerControllers[i].SkyController.TriggerCollider.OnCollideWithEnvironmentCollisionObject += SetSkyObjectsPositions;
                backgroundPiecesContainerControllers[i].CloudsController.TriggerCollider.OnCollideWithEnvironmentCollisionObject += SetCloudObjectsPositions;
                backgroundPiecesContainerControllers[i].MountainsController.TriggerCollider.OnCollideWithEnvironmentCollisionObject += SetMountainsPositions;
            }

        }


        private void OnDestroy()
        {

            RemoveListeners();

        }

        private void RemoveListeners()
        {

            for (int i = 0; i < BackgroundPiecesContainerControllers.Length; i++)
            {
                backgroundPiecesContainerControllers[i].SkyController.TriggerCollider.OnCollideWithEnvironmentCollisionObject -= SetSkyObjectsPositions;
                backgroundPiecesContainerControllers[i].CloudsController.TriggerCollider.OnCollideWithEnvironmentCollisionObject -= SetCloudObjectsPositions;
                backgroundPiecesContainerControllers[i].MountainsController.TriggerCollider.OnCollideWithEnvironmentCollisionObject -= SetMountainsPositions;
            }

        }

        #endregion


        #region API

        /// <summary>
        /// Method that sets the background controller.
        /// </summary>
        public void SetUp(EnvironmentType _environmentType)
        {

            backgroundPiecesContainerControllers = new BackgroundPiecesContainerController[NUMBER_OF_BACKGROUNDPIECESCONTAINERCONTROLLER];
            skyControllers = new BackgroundPieceController[backgroundPiecesContainerControllers.Length];
            cloudsControllers = new BackgroundPieceController[skyControllers.Length];
            mountainsControllers = new BackgroundPieceController[cloudsControllers.Length];

            SetBackgroundObjects(_environmentType);
            AddListeners();

        }

        /// <summary>
        /// Method that moves the background piece objects.
        /// </summary>
        public void UpdatePositions()
        {

            for (int i = 0; i < backgroundPiecesContainerControllers.Length; i++)
            {
                backgroundPiecesContainerControllers[i].UpdateBackgroundPiecesPositions(skyMovementSpeed, cloudsMovementSpeed, mountainsMovementSpeed);
            }

        }

        #endregion


        #region Private methods

        private void SetBackgroundObjects(EnvironmentType _environmentType)
        {

            switch (_environmentType)
            {
                case EnvironmentType.Grassy:
                    CreateBackgroundObjects(prefabGrassyBackground);
                    break;
                case EnvironmentType.Dirty:
                    CreateBackgroundObjects(prefabDirtyBackground);
                    break;
                case EnvironmentType.Snowy:
                    CreateBackgroundObjects(prefabSnowyBackground);
                    break;
                case EnvironmentType.Rocky:
                    CreateBackgroundObjects(prefabRockyBackground);
                    break;
                case EnvironmentType.Frozen:
                    CreateBackgroundObjects(prefabFrozenBackground);
                    break;
            }

        }


        private void CreateBackgroundObjects(GameObject _prefab)
        {

            for (int i = 0; i < backgroundPiecesContainerControllers.Length; i++)
            {

                GameObject backgroundObject = Instantiate(_prefab, this.gameObject.transform);
                BackgroundPiecesContainerController backgroundPiecesContainerController = backgroundObject.GetComponent<BackgroundPiecesContainerController>();
                backgroundPiecesContainerControllers[i] = backgroundPiecesContainerController;

                if (i == 0)
                {
                    backgroundPosition = Utilities.Screen.Position;
                }
                else
                {
                    backgroundPosition = new Vector3(backgroundPiecesContainerControllers[0].transform.position.x + backgroundPiecesContainerControllers[0].SkySize.x,
                        backgroundPosition.y, 0);
                }

                backgroundPiecesContainerControllers[i].transform.SetPositionAndRotation(backgroundPosition, backgroundPiecesContainerControllers[i].transform.rotation);
                backgroundPiecesContainerControllers[i].SetUp();

                skyControllers[i] = backgroundPiecesContainerControllers[i].SkyController;
                cloudsControllers[i] = backgroundPiecesContainerControllers[i].CloudsController;
                mountainsControllers[i] = backgroundPiecesContainerControllers[i].MountainsController;

            }

        }

        #region Event methods

        private void SetSkyObjectsPositions()
        {

            BackgroundPieceController activatedSkyBackgroundPiece = null;
            BackgroundPieceController deactivatedSkyBackgroundPiece = null;

            for (int i = 0; i < skyControllers.Length; i++)
            {
                if (!skyControllers[i].gameObject.activeSelf)
                {
                    deactivatedSkyBackgroundPiece = skyControllers[i];
                }
                else
                {
                    activatedSkyBackgroundPiece = skyControllers[i];
                }
            }

            deactivatedSkyBackgroundPiece.transform.position = new Vector3(activatedSkyBackgroundPiece.transform.position.x +
                        activatedSkyBackgroundPiece.Size.x,
                        backgroundPosition.y, 0);


            deactivatedSkyBackgroundPiece.gameObject.SetActive(true);

        }

        private void SetCloudObjectsPositions()
        {

            BackgroundPieceController activatedCloudsBackgroundPiece = null;
            BackgroundPieceController deactivatedCloudsBackgroundPiece = null;

            for (int i = 0; i < cloudsControllers.Length; i++)
            {
                if (!cloudsControllers[i].gameObject.activeSelf)
                {
                    deactivatedCloudsBackgroundPiece = cloudsControllers[i];
                }
                else
                {
                    activatedCloudsBackgroundPiece = cloudsControllers[i];
                }
            }

            deactivatedCloudsBackgroundPiece.transform.position = new Vector3(activatedCloudsBackgroundPiece.transform.position.x +
                        activatedCloudsBackgroundPiece.Size.x,
                        backgroundPosition.y, 0);


            deactivatedCloudsBackgroundPiece.gameObject.SetActive(true);

        }

        private void SetMountainsPositions()
        {

            BackgroundPieceController activatedMountainsBackgroundPiece = null;
            BackgroundPieceController deactivatedMountainsBackgroundPiece = null;

            for (int i = 0; i < mountainsControllers.Length; i++)
            {
                if (!mountainsControllers[i].gameObject.activeSelf)
                {
                    deactivatedMountainsBackgroundPiece = mountainsControllers[i];
                }
                else
                {
                    activatedMountainsBackgroundPiece = mountainsControllers[i];
                }
            }

            deactivatedMountainsBackgroundPiece.transform.position = new Vector3(activatedMountainsBackgroundPiece.transform.position.x +
                        activatedMountainsBackgroundPiece.Size.x,
                        backgroundPosition.y, 0);


            deactivatedMountainsBackgroundPiece.gameObject.SetActive(true);

        }

        #endregion

        #endregion

    }

}