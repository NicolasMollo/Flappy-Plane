using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Environment
{

    [DisallowMultipleComponent]
    public class GroundPieceController : MonoBehaviour
    {

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