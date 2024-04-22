using System;
using UnityEngine;


namespace Environment
{

    [DisallowMultipleComponent]
    [RequireComponent(typeof(Collider2D))]
    public class ObstacleSuccessfulPassageColliderController : MonoBehaviour
    {

        [Header("OBSTACLE SUCCESSFUL PASSAGE COLLIDER CONTROLLER DATA")]

        [SerializeField]
        [Tooltip("Obstacle successful passage collider")]
        private Collider2D _collider = null;
        public Collider2D Collider
        {
            get => _collider;
        }

        #region Constants

        private const string PLAYER_TAG = "Player";

        #endregion
        #region Actions

        public Action OnCollideWithPlayer = null;

        #endregion



        #region API

        /// <summary>
        /// Method that sets the obstacle successful passage collider controller.
        /// The method accepts a float as an argument which determines the distance that must be between
        /// the collider and the graphic objects (always part of obstacles).
        /// </summary>
        public void SetUp(float _colliderOffsetX = 1f)
        {

            // Collider
            bool colliderIsTrigger = true;
            _collider.isTrigger = colliderIsTrigger;
            _collider.offset = new Vector2(_colliderOffsetX, _collider.offset.y);

            BoxCollider2D boxCollider = _collider as BoxCollider2D;
            if (boxCollider != null)
            {
                boxCollider.size = new Vector3(boxCollider.bounds.size.x, Utilities.Screen.HeightInUnits);
            }

        }

        #endregion


        #region Event collisions

        private void OnTriggerEnter2D(Collider2D collision)
        {

            if (collision.CompareTag(PLAYER_TAG))
            {
                OnCollideWithPlayer?.Invoke();
            }

        }

        #endregion

    }

}