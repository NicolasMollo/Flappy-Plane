using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Environment
{

    [DisallowMultipleComponent]
    public class GroundController : MonoBehaviour
    {

        [Header("GROUND DATA")]

        #region Prefabs

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

        private EnvironmentType environmentType = EnvironmentType.Dirty;

        private Vector2 groundPosition = Vector2.zero;

        private GroundPiecesContainerController[] groundPiecesContainerControllers = null;
        private const int NUMBEROF_GROUNDOBJECTS = 2;
        private Transform groundObjectPiece = null;
        private SpriteRenderer groundObjectPieceSpriteRenderer = null;

        // creare 2 oggetti ground tramite i prefab e riutilizzare quelli
        // tramite object pooling


        #region Lifecycle

        private void Start()
        {

            SetUp();
            SetGroundObjects();

            Debug.Log($"HalfScreenSize {Utilities.Screen.HalfScreenWidthInPixels}");
            Debug.Log($"Screen position X {Utilities.Screen.ScreenPositionX}");
            Debug.Log($"Screen position Y {Utilities.Screen.ScreenPositionY}");
            Debug.Log($"Screen position {Utilities.Screen.ScreenPosition}");

        }

        private void SetUp()
        {

            environmentType = Managers.GameManager.Instance.EnvironmentRootController._EnvironmentType;
            groundPiecesContainerControllers = new GroundPiecesContainerController[NUMBEROF_GROUNDOBJECTS];
            groundObjectPiece = prefabDirtyGround.transform.GetChild(0);
            groundObjectPieceSpriteRenderer = groundObjectPiece.GetComponent<SpriteRenderer>();

        }

        private void SetGroundObjects()
        {

            switch (environmentType)
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

        private const float GROUND_POSITION_Y_OFFSET = 0.3f;

        private void CreateGroundObjects(GameObject _prefabGround)
        {

            for (int i = 0; i < NUMBEROF_GROUNDOBJECTS; i++)
            {

                if (i == 0)
                {
                    groundPosition = new Vector3(Utilities.Screen.ScreenPositionX,
                        Utilities.Screen.ScreenPositionY - Utilities.Screen.HalfScreenHeightInUnits + GROUND_POSITION_Y_OFFSET,
                        0);
                }
                else
                {
                    groundPosition = new Vector3(groundPiecesContainerControllers[0].EndPositionObject.transform.position.x +
                        groundPiecesContainerControllers[0].GroundPieceSizeX + (groundPiecesContainerControllers[0].GroundPieceSizeX * 0.5f),
                        groundPosition.y, 0);
                }

                GameObject groundObject = Instantiate(_prefabGround, groundPosition, _prefabGround.transform.rotation, this.gameObject.transform);
                GroundPiecesContainerController groundPiecesContainerController = groundObject.GetComponent<GroundPiecesContainerController>();
                groundPiecesContainerControllers[i] = groundPiecesContainerController;

            }

            // test
            for (int i = 0; i < groundPiecesContainerControllers.Length; i++)
            {
                Debug.Log($"== GROUNDCONTROLLER LOG == Ground object number {i}");
            }

        }

        #endregion


        #region API



        #endregion

    }

}