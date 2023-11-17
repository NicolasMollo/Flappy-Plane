using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Animations;
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

        [SerializeField]
        [Tooltip("Trigger collider")]
        private Collider2D _collider = null;
        public Collider2D Collider
        {
            get => _collider;
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

        //private bool isInFirstPlace = false;


        #region API

        /// <summary>
        /// Method that deactivates the object.
        /// </summary>
        public void DeactivateMe()
        {

            gameObject.SetActive(false);
            //isInFirstPlace = false;
        
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