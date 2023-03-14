using DG.Tweening;
using UnityEngine;

namespace Lyaguska.Services
{
    public class BackgroundSound : MonoBehaviour
    {
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private float _maxVolume = 0.25f; 
        [SerializeField] private float _playFadeDuration = 1f;
        [SerializeField] private float _stopFadeDuration = 1f;
        
        private Tween _currentTween;
        
        public void Play()
        {
            _currentTween?.Kill();
            _audioSource.Play();   
            _currentTween = _audioSource.DOFade(_maxVolume, _playFadeDuration);
        }
        
        public void Stop()
        {
            _currentTween?.Kill();
            _currentTween = _audioSource.DOFade(0, _stopFadeDuration)
                .OnComplete(() => _audioSource.Stop());
        }


    }
}