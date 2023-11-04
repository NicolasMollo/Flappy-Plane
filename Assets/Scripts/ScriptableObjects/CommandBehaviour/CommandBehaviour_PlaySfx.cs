using UnityEngine;


namespace Commands
{

    [CreateAssetMenu(menuName = "Create Command/Play sfx")]
    public class CommandBehaviour_PlaySfx : CommandBehaviour
    {

        [Header("DATA")]

        [SerializeField]
        [Tooltip("Audio clip to play")]
        private AudioClip clip = null;

        [SerializeField]
        [Tooltip("Checks whether the audio source it is hooking to is already playing an audio clip or not")]
        private bool waitIfSourceIsPlaying = false;

        [SerializeField]
        [Tooltip("Type of sfx/object that will be used to determine which audio source will play the audio clip")]
        private Managers.AudioManager.SfxType audioSourceType = Managers.AudioManager.SfxType.Last;



        public override void DoCommand(GameObject _self)
        {

            base.DoCommand(_self);

            Managers.GameManager.Instance.audioManager.PlaySfx(clip, audioSourceType, waitIfSourceIsPlaying);

            CurrentState = CBState.Completed;

        }

    }

}