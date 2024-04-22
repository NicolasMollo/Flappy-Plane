using Sirenix.Serialization;
using System;
using UnityEngine;


namespace Environment
{

    [DisallowMultipleComponent]
    public class ObstaclePieceController : MonoBehaviour
    {

        [Header("OBSTACLE PIECE CONTROLLER DATA")]

        [SerializeField]
        [Tooltip("Obstacle piece controller collider")]
        private Collider2D _collider = null;
        [SerializeField]
        [Tooltip("Obstacle piece controller sprite renderer")]
        private SpriteRenderer spriteRenderer = null;

        #region Obstacle piece controller type

        private enum ObstaclePieceType : byte
        {
            Up,
            Down
        }

        [SerializeField]
        [Tooltip("Obstacle piece controller tyoe")]
        private ObstaclePieceType obstaclePieceType = 0x00;

        #endregion

        private BackgroundTriggerColliderController triggerCollider = null;
        public BackgroundTriggerColliderController TriggerCollider
        {
            get => triggerCollider;
        }

        #region Constants

        private const string PLAYER_TAG = "Player";
        private const string SORTINGLAYER_NAME = "Obstacles";
        private const int SORTINGORDER = 0;

        #endregion
        #region Actions

        public Action OnCollideWithPlayer = null;

        #endregion
        #region Size properties

        public Vector2 Size
        {
            get => _collider.bounds.size;
        }

        public Vector2 HalfSize
        {
            get => Size * 0.5f;
        }

        #endregion


        #region API

        /// <summary>
        /// Method that sets the obstacle piece controller.
        /// </summary>
        public void SetUp(Vector3 _position)
        {

            // SpriteRenderer
            spriteRenderer.sortingLayerName = SORTINGLAYER_NAME;
            spriteRenderer.sortingOrder = SORTINGORDER;
            spriteRenderer.drawMode = SpriteDrawMode.Sliced;

            // Trigger collider
            if (obstaclePieceType == ObstaclePieceType.Up)
            {
                SetTriggerCollider(out triggerCollider);
            }

            // Transform
            transform.position = _position;

        }

        #endregion

        #region Private methods

        private void SetTriggerCollider(out BackgroundTriggerColliderController _triggerCollider)
        {

            _triggerCollider = GetComponentInChildren<BackgroundTriggerColliderController>();
            triggerCollider.SetUp();

        }

        #endregion

        #region Collision events

        private void OnCollisionEnter2D(Collision2D collision)
        {

            if (collision.collider.CompareTag(PLAYER_TAG))
            {
                OnCollideWithPlayer?.Invoke();
            }

        }

        #endregion

    }

}