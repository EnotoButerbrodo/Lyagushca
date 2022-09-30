using System.Collections.Generic;
using UnityEngine;

public class JumpSound : MonoBehaviour
{
    [SerializeField] private JumpHandler _jumpHandler;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private List<AudioClip> _sounds;

    private void OnJump()
    {
        _audioSource.pitch = Random.Range(0.9f, 1.1f);
        _audioSource.PlayOneShot(_sounds[Random.Range(0, _sounds.Count)]);
    }

    private void OnEnable()
    {
        _jumpHandler.Jump += OnJump;
    }

    private void OnDisable()
    {
        _jumpHandler.Jump -= OnJump;
    }
}

