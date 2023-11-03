using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Commands
{

    [CreateAssetMenu(menuName = "Create Command/Play Audio Clip")]
    public class CommandBehaviour_PlaySfx : CommandBehaviour
    {

        [Header("DATA")]

        [SerializeField]
        [Tooltip("Audio clip to play")]
        private AudioClip clip = null;

        [SerializeField]
        [Tooltip("Checks whether the audio source it is hooking to is already playing an audio clip or not")]
        private bool waitIfSourceIsPlaying = false;



        public override void DoCommand(GameObject _self)
        {

            base.DoCommand(_self);

            Managers.GameManager.Instance.audioManager.PlaySfx(clip, Managers.AudioManager.SfxType.MedalSilver, waitIfSourceIsPlaying);

            CurrentState = CBState.Completed;

        }

    }

}