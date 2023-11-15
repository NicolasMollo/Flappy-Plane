using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;


namespace Environment
{

    [DisallowMultipleComponent]
    public class GroundPieceController : MonoBehaviour
    {

        [SerializeField]
        [Tooltip("Ground piece's collider")]
        private Collider2D _collider = null;
        public Collider2D Collider
        {
            get => _collider;
        }

        [SerializeField]
        [Tooltip("Ground piece's sprite renderer")]
        private SpriteRenderer _spriteRenderer = null;
        public SpriteRenderer SpriteRenderer
        {
            get => _spriteRenderer;
        }

        [SerializeField]
        [Tooltip("Type of ground piece")]
        private EnvironmentType groundPieceType = EnvironmentType.Grassy;

        private const string OTHER_TAG = "Player";
        public Action<EnvironmentType> OnCollideWithMe = null;

        //[SerializeField]
        //[Tooltip("Allows you to activate the effects of the collision also on the parent object")]
        //private bool actCollisionEffectsOnParent = true;

        #region Size properties

        public float SizeX
        {
            get => _collider.bounds.size.x;
        }

        public float HalfSizeX
        {
            get => _collider.bounds.size.x * 0.5f;
        }

        public float SizeY
        {
            get => _collider.bounds.size.y;
        }

        public float HalfSizeY
        {
            get => _collider.bounds.size.y * 0.5f;
        }

        #endregion



        private void OnCollisionEnter2D(Collision2D collision)
        {

            if (collision.collider.CompareTag(OTHER_TAG))
            {
                // do something


                OnCollideWithMe?.Invoke(groundPieceType);

            }
            //else if (collision.collider.CompareTag("EnvironmentCollisionObject"))
            //{
            
            //    gameObject.transform.parent.gameObject.SetActive(false);
            
            //}

        }


    }

}