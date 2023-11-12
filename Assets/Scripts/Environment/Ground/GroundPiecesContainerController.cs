using System.Collections;
using System.Collections.Generic;
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
        [Tooltip("Object representing the starting point of the object (far left)")]
        private GameObject startPositionObject = null;

        [SerializeField]
        [Tooltip("Object representing the end point of the object (far right)")]
        private GameObject endPositionObject = null;



        public float GroundPieceSizeX
        {
            get => groundPieceControllers[0].Collider.bounds.size.x;
        }

        public float HalfGroundPieceSizeX
        {
            get => GroundPieceSizeX * 0.5f;
        }

        public float GroundPieceSizeY
        {
            get => groundPieceControllers[0].Collider.bounds.size.y;
        }

        public float GroundPiecesSizeX
        {
            get => groundPieceControllers[0].Collider.bounds.size.x * groundPieceControllers.Length;
        }

        public float HalfGroundPiecesSizeX
        {
            get => GroundPiecesSizeX * 0.5f;
        }

        public GameObject StartPositionObject
        {
            get => startPositionObject;
        }

        public GameObject EndPositionObject
        {
            get => endPositionObject;
        }

        #endregion

    }

}