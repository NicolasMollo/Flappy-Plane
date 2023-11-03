using Database;
using UnityEngine;


namespace Controllers
{

    [DisallowMultipleComponent]
    public class PlayerController : MonoBehaviour
    {

        [SerializeField]
        [Tooltip("Player's rigidbody")]
        private Rigidbody2D rigidBody = null;

        [SerializeField]
        [Tooltip("Player's animator")]
        private Animator animator = null;

        [SerializeField]
        [Tooltip("Player's data")]
        private DatabasePlayer data = null;
        public DatabasePlayer Data
        {
            get => data;
        }

        [SerializeField]
        [Tooltip("Player \"jump\" button")]
        private KeyCode jumpButton = KeyCode.Space;

        private bool jumpButtonIsPressed = false;
        private Vector3 startPosition = Vector3.zero;
        private const string TAG = "Player";



        #region Lifecycle

        private void Start()
        {

            SetUp();

        }
        private void SetUp()
        {

            gameObject.tag = TAG;
            gameObject.transform.GetChild(0).tag = gameObject.tag;
            animator.speed = data.AnimatorSpeed;
            startPosition = (-Vector3.right) * 3;
            rigidBody.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
            rigidBody.position = startPosition;

        }


        private void Update()
        {

            GetInput();

        }
        private void GetInput()
        {

            if (Input.GetKeyDown(jumpButton) ||
                Input.GetMouseButtonDown(0))
            {
                jumpButtonIsPressed = true;
            }

        }


        private void FixedUpdate()
        {

            if (jumpButtonIsPressed)
            {
                jumpButtonIsPressed = false;
                Movement();
                AnimatePlayer();
            }

        }
        private void Movement()
        {

            Vector2 direction = (Vector2.up).normalized;
            Vector2 velocity = direction * (data.JumpSpeed * Time.fixedDeltaTime);

            rigidBody.velocity = velocity;

        }
        private void AnimatePlayer()
        {

            animator.SetTrigger(data.AnimatorParameterName);

        }

        #endregion

    }

}