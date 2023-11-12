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

        private const string OTHER_TAG = "Player";
        public Action OnCollideWithMe = null;



        private void OnCollisionEnter2D(Collision2D collision)
        {

            if (collision.collider.CompareTag(OTHER_TAG))
            {
                // do something


                OnCollideWithMe?.Invoke();

            }

        }

    }

}