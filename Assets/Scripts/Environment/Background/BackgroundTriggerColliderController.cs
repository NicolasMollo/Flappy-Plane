using UnityEngine;
using System;


namespace Environment
{

    [DisallowMultipleComponent]
    [RequireComponent(typeof(Collider2D))]
    public class BackgroundTriggerColliderController : MonoBehaviour
    {

        [SerializeField]
        [Tooltip("Background trigger collider controller's collider")]
        private Collider2D _collider = null;
        private const string ENVIRONMENTCOLLISIONOBJECT_TAG = "EnvironmentCollisionObject";
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

        public Action OnCollideWithEnvironmentCollisionObject = null;



        #region API

        public void SetUp(SpriteRenderer _spriteRenderer/*, Vector3 _position*/)
        {

            _collider.isTrigger = true;
            transform.position = new Vector3(
                _spriteRenderer.gameObject.transform.position.x - (_spriteRenderer.size.x * 0.5f + HalfSize.x),
                _spriteRenderer.gameObject.transform.position.y,
                _spriteRenderer.gameObject.transform.position.z);

            //_position

        }

        #endregion


        #region Collision events

        private void OnTriggerEnter2D(Collider2D collision)
        {

            if (collision.CompareTag(ENVIRONMENTCOLLISIONOBJECT_TAG))
            {
                OnCollideWithEnvironmentCollisionObject?.Invoke();
            }

        }

        #endregion

    }

}