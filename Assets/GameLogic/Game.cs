using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private GameActor _player;
    

    private void OnEnable()
    {
        _player.Die += OnDied;    
    }

    private void OnDisable()
    {
        _player.Die -= OnDied;
    }

    private void OnDied()
    {

    }
}
