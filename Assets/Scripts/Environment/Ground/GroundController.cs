using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;


namespace Environment
{

    [DisallowMultipleComponent]
    public class GroundController : MonoBehaviour
    {

        #region Prefabs

        [Header("GROUND PREFABS")]

        [SerializeField]
        [Tooltip("Prefab of the grassy ground")]
        private GameObject prefabGrassyGround = null;

        [SerializeField]
        [Tooltip("Prefab of the dirty ground")]
        private GameObject prefabDirtyGround = null;

        [SerializeField]
        [Tooltip("Prefab of the snowy ground")]
        private GameObject prefabSnowyGround = null;

        [SerializeField]
        [Tooltip("Prefab of the rocky ground")]
        private GameObject prefabRockyGround = null;

        [SerializeField]
        [Tooltip("Prefab of the frozen ground")]
        private GameObject prefabFrozenGround = null;

        #endregion

        [Header("GROUND DATA")]

        [SerializeField]
        [Tooltip("Speed of movement of ground objects")]
        private float movementSpeed = 10f;


        private GroundPiecesContainerController[] groundPiecesContainerControllers = null;
        public GroundPiecesContainerController[] GroundPiecesContainerControllers
        {
            get => groundPiecesContainerControllers;
        }

        private Vector2 groundPosition = Vector2.zero;

        private const int NUMBEROF_GROUNDOBJECTS = 2;



        #region Lifecycle

        /// <summary>
        /// Add listeners to actions.
        /// Called in 'SetUp' (inside the 'API' region) which is called in 'Start' inside the root class 'EnvironmentRootController'
        /// </summary>
        private void AddListeners()
        {
            for (int i = 0; i < groundPiecesContainerControllers.Length; i++)
            {
                groundPiecesContainerControllers[i].OnCollideWithTriggerCollider += SetGroundObjectPosition;
            }

        }


        private void OnDestroy()
        {
            RemoveListeners();
        }

        private void RemoveListeners()
        {
            for (int i = 0; i < groundPiecesContainerControllers.Length; i++)
            {
                groundPiecesContainerControllers[i].OnCollideWithTriggerCollider -= SetGroundObjectPosition;
            }

        }

        #endregion


        #region API

        /// <summary>
        /// Method that sets the ground controller.
        /// The method accepts an 'EnvironmentType' argument which represents the type of environment of the game scene
        /// and will be used to create/manage the right type of ground objects.
        /// </summary>
        /// <param name="_environmentType"></param>
        public void SetUp(EnvironmentType _environmentType)
        {

            groundPiecesContainerControllers = new GroundPiecesContainerController[NUMBEROF_GROUNDOBJECTS];
            SetGroundObjects(_environmentType);
            AddListeners();

        }

        /// <summary>
        /// Method that moves ground objects.
        /// </summary>
        public void UpdatePosition()
        {

            Vector3 direction = Vector2.left.normalized;
            float calculatedMovementSpeed = movementSpeed * Time.deltaTime;
            Vector3 velocity = direction * calculatedMovementSpeed;

            transform.position += velocity;

        }

        #endregion


        #region Private methods

        private void SetGroundObjects(EnvironmentType _environmentType)
        {

            switch (_environmentType)
            {
                case EnvironmentType.Grassy:
                    CreateGroundObjects(prefabGrassyGround);
                    break;
                case EnvironmentType.Dirty:
                    CreateGroundObjects(prefabDirtyGround);
                    break;
                case EnvironmentType.Snowy:
                    CreateGroundObjects(prefabSnowyGround);
                    break;
                case EnvironmentType.Rocky:
                    CreateGroundObjects(prefabRockyGround);
                    break;
                case EnvironmentType.Frozen:
                    CreateGroundObjects(prefabFrozenGround);
                    break;
                default:
                    break;
            }

        }

        private void CreateGroundObjects(GameObject _prefabGround)
        {

            for (int i = 0; i < NUMBEROF_GROUNDOBJECTS; i++)
            {

                GameObject groundObject = Instantiate(_prefabGround, this.gameObject.transform);
                GroundPiecesContainerController groundPiecesContainerController = groundObject.GetComponent<GroundPiecesContainerController>();
                groundPiecesContainerControllers[i] = groundPiecesContainerController;

                if (i == 0)
                {
                    groundPosition = new Vector3(Utilities.Screen.ScreenPositionX,
                        Utilities.Screen.ScreenPositionY - Utilities.Screen.HalfScreenHeightInUnits + groundPiecesContainerControllers[i].HalfSizeY,
                        0);
                }
                else
                {
                    groundPosition = new Vector3(groundPiecesContainerControllers[0].transform.position.x +
                        groundPiecesContainerControllers[0].SizeX,
                        groundPosition.y, 0);
                }

                groundPiecesContainerControllers[i].transform.position = groundPosition;
                groundPiecesContainerControllers[i].transform.rotation = _prefabGround.transform.rotation;

            }

        }


        private void SetGroundObjectPosition()
        {

            GroundPiecesContainerController activatedGroundPiecesContainer = null;
            GroundPiecesContainerController deactivatedGroundPiecesContainer = null;

            for (int i = 0; i < groundPiecesContainerControllers.Length; i++)
            {
                if (!groundPiecesContainerControllers[i].gameObject.activeSelf)
                {
                    deactivatedGroundPiecesContainer = groundPiecesContainerControllers[i];
                }
                else
                {
                    activatedGroundPiecesContainer = groundPiecesContainerControllers[i];
                }
            }

            deactivatedGroundPiecesContainer.transform.position = new Vector3(activatedGroundPiecesContainer.transform.position.x +
                        activatedGroundPiecesContainer.SizeX,
                        groundPosition.y, 0);


            deactivatedGroundPiecesContainer.gameObject.SetActive(true);

        }

        #endregion

    }

}