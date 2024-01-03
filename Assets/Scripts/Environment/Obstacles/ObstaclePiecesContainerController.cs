using UnityEngine;


namespace Environment
{

    [DisallowMultipleComponent]
    public class ObstaclePiecesContainerController : MonoBehaviour
    {

        #region Obstacle pieces with them properties

        [Header("OBSTACLE PIECES")]

        [SerializeField]
        [Tooltip("Graphic obstacle piece placed at the top of the object")]
        private ObstaclePieceController upObstaclePieceController = null;
        [SerializeField]
        [Tooltip("Graphic obstacle piece placed at the bottom of the object")]
        private ObstaclePieceController downObstaclePieceController = null;
        [SerializeField]
        [Tooltip("Collider of successful obstacle passage")]
        private ObstacleSuccessfulPassageColliderController successfulPassageColliderController = null;


        public ObstaclePieceController UpObstaclePieceController
        {
            get => upObstaclePieceController;
        }
        public ObstaclePieceController DownObstaclePieceController
        {
            get => downObstaclePieceController;
        }
        public ObstacleSuccessfulPassageColliderController ObstacleSuccessfulPassageColliderController
        {
            get => successfulPassageColliderController;
        }

        #endregion



        #region API

        /// <summary>
        /// Method that sets the obstacle pieces container controller.
        /// </summary>
        public void SetUp()
        {
        

        
        }

        /// <summary>
        /// Method that moves the obstacles pieces container object.
        /// The method accepts as an argument a float which represents the scalar which, 
        /// multiplied by the direction unit vector, returns the velocity vector.
        /// </summary>
        /// <param name="_movementSpeed"></param>
        public void UpdatePosition(float _movementSpeed)
        {

            Vector3 direction = Vector3.left.normalized;
            float calculatedMovementSpeed = _movementSpeed * Time.deltaTime;
            Vector3 velocity = direction * calculatedMovementSpeed;

            transform.position += velocity;

        }

        #endregion

    }


}