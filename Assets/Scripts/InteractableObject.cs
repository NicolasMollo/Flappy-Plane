using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Database;
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
        [Tooltip("Interactable object's animator")]
        private Animator animator = null;
        public Animator Animator
        {
            get => animator;
        }

        [SerializeField]
        [Tooltip("Interactable object's audio source")]
        private AudioSource audioSource = null;
        public AudioSource AudioSource
        {
            get => audioSource;
        }

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

        }


        private void OnCollisionEnter2D(Collision2D collision)
        {

            if (collision.collider.CompareTag(OTHER_TAG))
            {
                ExecuteCommands();
            }

        }
        private void ExecuteCommands()
        {

            foreach (CommandBehaviour command in collisionCommands)
            {
                command.DoCommand(this.gameObject);
            }

        }

    }

}