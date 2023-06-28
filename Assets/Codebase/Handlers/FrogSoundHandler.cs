using Lyaguska.Actors;
using UnityEngine;
using Random = EnotoButebrodo.Random;

namespace Lyaguska.Handlers
{
    public class FrogSoundHandler : MonoBehaviour
    {
        [SerializeField] private AudioSource _audioSource;
        
        [SerializeField] private AudioClip _jumpSound;
        [SerializeField] private AudioClip _groundSound;
        [SerializeField] private AudioClip _dieSound;

        public void PlayDead()
        {
            Play(_dieSound);
        }

        public void PlayJump()
        {
            Play(_jumpSound);
        }

        public void PlayLand()
        {
            Play(_groundSound);
        }
        
        private void Play(AudioClip clip)
        {
            _audioSource.pitch = Random.Range(0.8f, 1.2f);
            _audioSource.PlayOneShot(clip);
        }
    }
}