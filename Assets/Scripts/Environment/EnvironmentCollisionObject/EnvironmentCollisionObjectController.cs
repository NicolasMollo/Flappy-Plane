using Sirenix.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


namespace Environment
{

    [DisallowMultipleComponent]
    public class EnvironmentCollisionObjectController : MonoBehaviour
    {

        [Header("ENVIRONMENT COLLISION OBJECT DATA")]

        [SerializeField]
        [Tooltip("Environment collision object's collider")]
        private Collider2D _collider = null;
        public Collider2D Collider
        {
            get => _collider;
        }

        [SerializeField]
        [Tooltip("Environment collision object's rigidbody")]
        private Rigidbody2D _rigidbody = null;
        public Rigidbody2D Rigidbody
        {
            get => _rigidbody;
        }

        #region Size properties

        public float SizeX
        {
            get => _collider.bounds.size.x;
        }

        public float HalfSizeX
        {
            get => SizeX * 0.5f;
        }

        public float SizeY
        {
            get => _collider.bounds.size.y;
        }

        public float HalfSizeY
        {
            get => SizeY * 0.5f;
        }

        #endregion



        #region API

        /// <summary>
        /// Method that sets the environment collision object controller.
        /// The method accepts as an argument a float which represents how far away you want the collision object
        /// from the leftmost point of the window (starting point of the collision object)
        /// (distance which will be towards the left (Vector3.left))
        /// </summary>
        /// <param name="_offsetX"></param>
        public void SetUp(float _offsetX)
        {

            _collider.isTrigger = true;
            _rigidbody.bodyType = RigidbodyType2D.Kinematic;
            SetPosition(_offsetX);
        
        }

        #endregion


        #region Private methods

        private void SetPosition(float _offsetX)
        {

            float positionXRelativeToTheWindow = Utilities.Screen.ScreenPositionX -
                Utilities.Screen.ConvertPixelToUnits(Utilities.Screen.ScreenWidthInPixels * 0.5f) -
                HalfSizeX;

            Vector3 newPostion = new Vector3(positionXRelativeToTheWindow - _offsetX, 0, 0);


            _rigidbody.position = newPostion;

        }

        #endregion

    }

}