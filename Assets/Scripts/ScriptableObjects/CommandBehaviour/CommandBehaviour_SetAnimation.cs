using System.Collections;
using System.Collections.Generic;
using System.Security;
using UnityEngine;
using Sirenix;
using Sirenix.Serialization;
using Sirenix.OdinInspector;


namespace Commands
{

    [CreateAssetMenu(menuName = "Create Command/Set animation")]
    public class CommandBehaviour_SetAnimation : CommandBehaviour
    {

        [Header("DATA")]

        [SerializeField]
        [Tooltip("Animator's speed")]
        [Range(0f, 1f)]
        private float animatorSpeed = 1f;

        [SerializeField]
        [Tooltip("Animator parameter's name")]
        private string parameterName = string.Empty;

        [SerializeField]
        [Tooltip("Animator parameter's type")]
        private AnimatorControllerParameterType parameterType = AnimatorControllerParameterType.Trigger;

        [SerializeField]
        [Tooltip("Animator parameter's value to set")]
        [ShowIf("parameterType", AnimatorControllerParameterType.Float)]
        private float f_value = 0f;

        [SerializeField]
        [Tooltip("Animator parameter's value to set")]
        [ShowIf("parameterType", AnimatorControllerParameterType.Int)]
        private int i_value = 0;

        [SerializeField]
        [Tooltip("Animator parameter's value to set")]
        [ShowIf("parameterType", AnimatorControllerParameterType.Bool)]
        private bool b_value = false;



        public override void DoCommand(GameObject _self)
        {

            base.DoCommand(_self);

            Animator animator = _self.GetComponent<Animator>();
            animator.speed = animatorSpeed;
            SetAnimatorParameter(animator);

            CurrentState = CBState.Completed;

        }

        private void SetAnimatorParameter(Animator _animator)
        {

            switch (parameterType)
            {
                case AnimatorControllerParameterType.Float:
                    _animator.SetFloat(parameterName, f_value);
                    break;
                case AnimatorControllerParameterType.Int:
                    _animator.SetInteger(parameterName, i_value);
                    break;
                case AnimatorControllerParameterType.Bool:
                    _animator.SetBool(parameterName, b_value);
                    break;
                case AnimatorControllerParameterType.Trigger:
                    _animator.SetTrigger(parameterName);
                    break;
            }

        }


    }


}