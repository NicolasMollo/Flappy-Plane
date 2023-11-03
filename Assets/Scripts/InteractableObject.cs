using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Commands;
using UnityEngine.Rendering.Universal;


namespace Environment
{

    [DisallowMultipleComponent]
    public class InteractableObject : MonoBehaviour
    {

        [SerializeField]
        [Tooltip("Interactable object's sprite renderer")]
        private SpriteRenderer spriteRenderer = null;
        public SpriteRenderer SpriteRenderer
        {
            get => spriteRenderer;
        }

        [SerializeField]
        [Tooltip("Interactable object's collider")]
        private Collider2D _collider = null;
        public Collider2D Collider
        {
            get => _collider;
        }

        [SerializeField]
        [Tooltip("Interactable object's animator")]
        private Animator animator = null;
        public Animator Animator
        {
            get => animator;
        }

        [SerializeField]
        [Tooltip("List of commands to be executed by the interactable object when is its set up")]
        private List<CommandBehaviour> setUpCommands = null;

        [SerializeField]
        [Tooltip("List of commands to be executed by the interactable object when the collision occurs")]
        private List<CommandBehaviour> collisionCommands = null;

        private const string OTHER_TAG = "Player";



        private void Start()
        {

            SetUp();

        }
        private void SetUp()
        {

            // Collider set up
            _collider.isTrigger = true;

            // Commands set up
            ExecuteSetUpCommands();

        }
        private void ExecuteSetUpCommands()
        {
        
            foreach (CommandBehaviour command in setUpCommands)
            {
                command.DoCommand(this.gameObject);
            }
        
        }


        private void OnTriggerEnter2D(Collider2D collision)
        {

            if (collision.CompareTag(OTHER_TAG))
            {
                ExecuteCollisionCommands();
            }

        }

        private void ExecuteCollisionCommands()
        {

            foreach (CommandBehaviour command in collisionCommands)
            {
                command.DoCommand(this.gameObject);
            }

        }


    }

}