using UnityEngine;


namespace Environment
{

    [DisallowMultipleComponent]
    public class BackgroundPiecesContainerController : MonoBehaviour
    {

        #region Pieces of background pieces container controller and them properties

        [SerializeField]
        [Tooltip("Sky piece")]
        private BackgroundPieceController skyController = null;
        [SerializeField]
        [Tooltip("Clouds piece")]
        private BackgroundPieceController cloudsController = null;
        [SerializeField]
        [Tooltip("Mountains piece")]
        private BackgroundPieceController mountainsController = null;


        public BackgroundPieceController SkyController
        {
            get => skyController;
        }
        public BackgroundPieceController CloudsController
        {
            get => cloudsController;
        }
        public BackgroundPieceController MountainsController
        {
            get => mountainsController;
        }

        #endregion

        #region Constants

        private const int SORTINGORDER_SKY = -2;
        private const int SORTINGORDER_CLOUDS = -1;
        private const int SORTINGORDER_MOUNTAINS = 0;

        #endregion

        #region Size properties

        public Vector2 SkySize
        {
            get => skyController.Size;
        }

        public Vector2 CloudsSize
        {
            get => cloudsController.Size;
        }

        public Vector2 MountainsSize
        {
            get => mountainsController.Size;
        }

        #endregion



        #region API


        public void SetUp()
        {

            skyController.SetUp(SORTINGORDER_SKY);
            cloudsController.SetUp(SORTINGORDER_CLOUDS);
            mountainsController.SetUp(SORTINGORDER_MOUNTAINS);
        
        }

        public void UpdateBackgroundPiecesPositions(float _skyMovementSpeed, float _cloudsMovementSpeed, float _mountainsMovementSpeed)
        {

            skyController.UpdatePosition(_skyMovementSpeed);
            cloudsController.UpdatePosition(_cloudsMovementSpeed);
            mountainsController.UpdatePosition(_mountainsMovementSpeed);
        
        }

        #endregion

    }

}