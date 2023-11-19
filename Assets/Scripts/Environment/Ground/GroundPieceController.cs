using System;
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

        private const string PLAYER_TAG = "Player";
        public Action<EnvironmentType> OnCollideWithMe = null;

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

            if (collision.collider.CompareTag(PLAYER_TAG))
            {

                // do something


                OnCollideWithMe?.Invoke(groundPieceType);

            }

        }


    }

}