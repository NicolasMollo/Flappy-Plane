using System;
using System.Collections;
using System.Collections.Generic;
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

        public Action OnCollideWithMe = null;


        #region API

        public void SetUp(/*Vector3 _position*/)
        {
        
            _collider.isTrigger = true;
            _rigidbody.bodyType = RigidbodyType2D.Kinematic;
            //_rigidbody.position = _position;
        
        }

        #endregion


        #region Collision events


        private void OnTriggerEnter2D(Collider2D collision)
        {

            //if (collision.CompareTag("Ground"))
            //{
            //    OnCollideWithMe?.Invoke();
            //    // aggiungere un collider all'oggetto e gestire la collisione con quello.
            //    //collision.gameObject.GetComponent<GroundPiecesContainerController>().DeactivateMe();
            //    //// collision.gameObject.transform.parent.gameObject.transform.parent.GetComponent<GroundController>().SetGroundObjectPosition();
            //    //environmentRootController.GroundController.SetGroundObjectPosition();
            //    //Debug.Log($"== ENVIRONMENT COLLISION OBJECT == collided with ground object");
            //}

        }


        #endregion

    }

}