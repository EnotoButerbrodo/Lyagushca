using Lyaguska.Actors;
using UnityEngine;
using Random = EnotoButebrodo.Random;

namespace Lyaguska.Handlers
{
    public class ActorSoundHanler : MonoBehaviour
    {
        [SerializeField] private Actor _actor;
        [SerializeField] private AudioSource _audioSource;
        
        [SerializeField] private AudioClip _jumpSound;
        [SerializeField] private AudioClip _groundSound;
        [SerializeField] private AudioClip _dieSound;


        private void OnEnable()
        {
            _actor.Jumped += OnJump;
            _actor.Dead += OnDead;
        }


        private void OnDisable()
        {
            
            _actor.Jumped -= OnJump;
            _actor.Dead -= OnDead;
        }

        private void OnDead()
        {
            Play(_dieSound);
        }

        private void OnJump()
        {
            Play(_jumpSound);
        }

        private void OnGrounded()
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