using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


namespace Managers
{

    [DisallowMultipleComponent]
    public class AudioManager : MonoBehaviour
    {

        public enum SfxType : byte
        {
            MedalBronze,
            MedalSilver,
            MedalGold,
            Last
        }

        [SerializeField]
        [Tooltip("List of sfx audio clips")]
        private List<AudioClip> sfxAudioClips = null;

        private List<AudioSource> sfxAudioSources = null;



        #region Lifecycle

        private void Start()
        {

            SetUp();

        }

        private void SetUp()
        {

            CreateSfxAudioSources();
        
        }

        private void CreateSfxAudioSources()
        {

            sfxAudioSources = new List<AudioSource>();

            for (int i = 0; i < (int)SfxType.Last; i++)
            {
                AudioSource source = this.gameObject.AddComponent<AudioSource>();
                source.playOnAwake = false;
                sfxAudioSources.Add(source);
            }
        
        }

        #endregion


        #region API

        public void PlaySfx(AudioClip _audioClip, SfxType _sfxType, bool _waitIfSourceIsPlaying = false)
        {

            AudioSource audioSource = sfxAudioSources[(int)_sfxType];

            if (_waitIfSourceIsPlaying)
            {
                if (!audioSource.isPlaying)
                {
                    audioSource.PlayOneShot(_audioClip);
                }
            }
            else
            {
                sfxAudioSources[(int)_sfxType].PlayOneShot(_audioClip);
            }

        }

        public void PlaySfx(SfxType _sfxType, bool _waitIfSourceIsPlaying = false)
        {

            AudioSource audioSource = sfxAudioSources[(int)_sfxType];

            if (_waitIfSourceIsPlaying)
            {
                if (!audioSource.isPlaying)
                {
                    audioSource.PlayOneShot(sfxAudioClips[(int)_sfxType]);
                }
            }
            else
            {
                sfxAudioSources[(int)_sfxType].PlayOneShot(sfxAudioClips[(int)_sfxType]);
            }

        }

        #endregion

    }

}