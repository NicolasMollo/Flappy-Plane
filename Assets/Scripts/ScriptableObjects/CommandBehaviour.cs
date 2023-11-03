using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Database
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

        [SerializeField]
        protected bool waitCompletionToProceed = false;



        public virtual void DoCommand(GameObject _self)
        {

            CurrentState = CBState.Executing;

        }

    }

}