using UnityEngine;


namespace Commands
{

    public abstract class CommandBehaviour : ScriptableObject
    {

        public enum CBState : byte
        {
            Idle,
            Executing,
            Completed
        }

        private CBState currentState = CBState.Idle;
        public CBState CurrentState
        {
            get { return currentState; }
            set { currentState = value; }
        }

        [Header("BASE CLASS DATA")]

        [SerializeField]
        [Tooltip("If you have to wait for its completion to proceed")]
        protected bool waitCompletionToProceed = false;



        public virtual void DoCommand(GameObject _self)
        {

            CurrentState = CBState.Executing;

        }

    }

}