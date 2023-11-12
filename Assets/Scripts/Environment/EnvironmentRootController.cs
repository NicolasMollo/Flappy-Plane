using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace Environment
{

    public enum EnvironmentType : byte
    {
        Grassy,
        Dirty,
        Snowy,
        Rocky,
        Frozen
    }

    [DisallowMultipleComponent]
    public class EnvironmentRootController : MonoBehaviour
    {

        #region Environment type

        private EnvironmentType environmentType = EnvironmentType.Grassy;
        public EnvironmentType _EnvironmentType
        {
            get => environmentType;
        }

        #endregion


        // Environment controllers references
        #region Environment controllers and them properties

        [SerializeField]
        private GroundController groundController = null;
        [SerializeField]
        private ObstaclesController obstaclesController = null;
        [SerializeField]
        private ParallaxController parallaxController = null;
        [SerializeField]
        private InteractablesController interactablesController = null;

        public GroundController GroundController
        {
            get => groundController;
        }
        public ObstaclesController ObstaclesController
        {
            get => obstaclesController;
        }
        public ParallaxController ParallaxController
        {
            get => parallaxController;
        }
        public InteractablesController InteractablesController
        {
            get => interactablesController;
        }

        #endregion

    }


}