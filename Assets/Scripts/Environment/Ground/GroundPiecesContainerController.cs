using System;
using UnityEngine;


namespace Environment
{

    [DisallowMultipleComponent]
    public class GroundPiecesContainerController : MonoBehaviour
    {

        #region Ground pieces container's objects and them properties

        [SerializeField]
        [Tooltip("Graphic objects inside the container (ordered from left to right)")]
        private GroundPieceController[] groundPieceControllers = null;
        public GroundPieceController[] GroundPieceControllers
        {
            get => groundPieceControllers;
        }

        [SerializeField]
        [Tooltip("Trigger collider")]
        private Collider2D triggerCollider = null;
        public Collider2D TriggerCollider
        {
            get => triggerCollider;
        }


        public float SizeX
        {
            get => groundPieceControllers[0].SizeX * groundPieceControllers.Length;
        }

        public float HalfSizeX
        {
            get => SizeX * 0.5f;
        }

        public float SizeY
        {
            get => groundPieceControllers[0].SizeY;
        }

        public float HalfSizeY
        {
            get => SizeY * 0.5f;
        }

        #endregion

        public Action OnCollideWithTriggerCollider = null;
        private const string ENVIRONMENTCOLLISIONOBJECT_TAG = "EnvironmentCollisionObject";



        #region API

        /// <summary>
        /// Method that sets the ground pieces container controller.
        /// </summary>
        public void SetUp()
        {

            triggerCollider.isTrigger = true;
        
        }

        /// <summary>
        /// Method that deactivates the object.
        /// </summary>
        public void DeactivateMe()
        {

            gameObject.SetActive(false);

        }

        #endregion


        #region Collision events

        private void OnTriggerEnter2D(Collider2D collision)
        {

            if (collision.CompareTag(ENVIRONMENTCOLLISIONOBJECT_TAG))
            {
                DeactivateMe();
                OnCollideWithTriggerCollider?.Invoke();
            }

        }

        #endregion

    }

}