using UnityEngine;

namespace TestTaskManeraiInc
{
    [RequireComponent(typeof(AudioSource))]
    public class PlayAudio : MonoBehaviour
    {
        private AudioSource _audioSource;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        public void PlayAudioClip()
        {
            _audioSource.Play();
        }
    }
}