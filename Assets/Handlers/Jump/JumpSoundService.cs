using System.Collections.Generic;
using UnityEngine;

namespace Lyaguska.Core
{
    public class JumpSoundService : MonoBehaviour, IResetable
    {
        [SerializeField] private JumpHandler _jumpHandler;
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private List<AudioClip> _sounds;

        private void OnJump()
        {
            _audioSource.pitch = Random.Range(0.8f, 1.2f);
            _audioSource.PlayOneShot(_sounds[Random.Range(0, _sounds.Count)]);
        }

        private void OnEnable()
        {
            _jumpHandler.Jumped += OnJump;
        }

        private void OnDisable()
        {
            _jumpHandler.Jumped -= OnJump;
        }

        public void Reset()
        {
            _audioSource.Stop();
        }
    }
}