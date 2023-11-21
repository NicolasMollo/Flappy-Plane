using System;
using UnityEngine;


namespace Environment
{

    [DisallowMultipleComponent]
    public class BackgroundPieceController : MonoBehaviour
    {

        [SerializeField]
        [Tooltip("Background piece controller's sprite renderer")]
        private SpriteRenderer spriteRenderer = null;

        [SerializeField]
        [Tooltip("Trigger collider")]
        private BackgroundTriggerColliderController triggerCollider = null;
        public BackgroundTriggerColliderController TriggerCollider
        {
            get => triggerCollider;
        }

        #region Constants

        private const string SORTINGLAYER_NAME = "Background";

        #endregion

        #region Size properties

        public Vector2 Size
        {
            get => spriteRenderer.size;
        }

        #endregion


        #region Lifecycle

        private void AddListeners()
        {

            triggerCollider.OnCollideWithEnvironmentCollisionObject += DeactivateMe;

        }


        private void OnDestroy()
        {
            RemoveListeners();
        }

        private void RemoveListeners()
        {
        
            triggerCollider.OnCollideWithEnvironmentCollisionObject -= DeactivateMe;

        }

        private void DeactivateMe()
        {

            gameObject.SetActive(false);

        }

        #endregion


        #region API

        /// <summary>
        /// Method that sets the background piece controller.
        /// The method takes as an argument an integer representing the sorting order of the background piece controller's sprite renderer.
        /// </summary>
        /// <param name="_sortingOrder"></param>
        public void SetUp(int _sortingOrder)
        {

            // SpriteRenderer
            spriteRenderer.sortingLayerName = SORTINGLAYER_NAME;
            spriteRenderer.sortingOrder = _sortingOrder;
            spriteRenderer.drawMode = SpriteDrawMode.Sliced;
            spriteRenderer.size = new Vector3(Utilities.MeasurementUnitConversion.ConvertPixelsToUnitsOnXAxis(Utilities.Screen.WidthInPixels),
                                               Utilities.Screen.HeightInUnits,
                                               transform.localScale.z);

            // Trigger collider
            triggerCollider.SetUp(spriteRenderer);

            // Event subscription
            AddListeners();

        }

        /// <summary>
        /// Method that moves the background piece object.
        /// The method accepts as an argument a float which represents the scalar which, 
        /// multiplied by the direction unit vector, returns the velocity vector.
        /// </summary>
        /// <param name="_movementSpeed"></param>
        public void UpdatePosition(float _movementSpeed)
        {

            Vector3 direction = Vector2.left.normalized;
            float calculatedMovementSpeed = _movementSpeed * Time.deltaTime;
            Vector3 velocity = direction * calculatedMovementSpeed;

            transform.position += velocity;

        }

        #endregion

    }

}