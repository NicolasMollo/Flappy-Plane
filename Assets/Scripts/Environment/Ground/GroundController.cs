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

        private Vector2 groundPosition = Vector2.zero;


        // creare 2 oggetti ground tramite i prefab e riutilizzare quelli
        // tramite object pooling


        #region Lifecycle

        private void Start()
        {

            SetUp();

        }

        private void SetUp()
        {
        
        
        
        }

        #endregion


        #region API



        #endregion

    }

}