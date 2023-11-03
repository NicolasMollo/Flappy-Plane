using UnityEngine;

namespace Database
{

    [CreateAssetMenu(menuName = "Create Database/Player")]
    public class DatabasePlayer : ScriptableObject
    {

        [SerializeField]
        [Tooltip("Player's name")]
        private string p_name = string.Empty;
        public string P_name
        {
            get => name;
        }


        [SerializeField]
        [Tooltip("Speed with which the player will \"jump\" upwards\n(Value that will be multiplied by the \"Time.fixedDeltaTime\")")]
        private float jumpSpeed = 200f;
        public float JumpSpeed
        {
            get => jumpSpeed;
        }


        [SerializeField]
        [Tooltip("Animator's speed")]
        private float animatorSpeed = 1f;
        public float AnimatorSpeed
        {
            get => animatorSpeed;
        }


        [SerializeField]
        [Tooltip("Animator parameter's name")]
        private string animatorParameterName = "IsFlying";
        public string AnimatorParameterName
        {
            get => animatorParameterName;
        }

    }

}