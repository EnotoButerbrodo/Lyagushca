﻿using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.HID;

public class BackgroundRepeater : MonoBehaviour
{
    [SerializeField] private List<SpriteRenderer> _backgrounds;
    private List<BackgroundBuffer> _buffers;

    private Camera _camera;
    private Vector3 _lastPosition;
    private class BackgroundBuffer
    {
        private SpriteRenderer[] _buffer;
        public BackgroundBuffer(SpriteRenderer background)
        {
            _buffer = new SpriteRenderer[2];
            for(int i = 0; i< _buffer.Length; i++)
            {
                _buffer[i] = GameObject.Instantiate(background);
                if (i == 0) continue;

                var position = _buffer[i].transform.position;
                position.x += _buffer[i - 1].bounds.size.x;
                _buffer[i].transform.position = position;
            }
        }

        public void Check(Plane[] cameraPlanes)
        {
            if(!GeometryUtility.TestPlanesAABB(cameraPlanes, _buffer[0].bounds))
            {
                Move();
                SwapFirstAndLast();
            }
        }

        private void Move()
        {
            var hiden = _buffer[0];
            var transform = hiden.transform.position;
            transform.x = _buffer[1].transform.position.x + hiden.bounds.size.x;
            hiden.transform.position = transform;
        }

        private void SwapFirstAndLast()
        {
            var temp = _buffer[0];
            _buffer[0] = _buffer[1];
            _buffer[1] = temp;
        }
    }

    private void Awake()
    {
        _camera = Camera.main;
        CreateBackgroundBuffers();
    }

    private void FixedUpdate()
    {
        if(_lastPosition == _camera.transform.position)
        {
            return;
        }
        _lastPosition = _camera.transform.position;
         
        var planes = GeometryUtility.CalculateFrustumPlanes(_camera);
        foreach (var buffer in _buffers)
        {
            buffer.Check(planes);
        }
    }



    private void CreateBackgroundBuffers()
    {
        _buffers = new List<BackgroundBuffer>();
        foreach(var background in _backgrounds)
        {
            _buffers.Add(new BackgroundBuffer(background));
        }
    }
    private void Repeat()
    {
        //Есть 2 копии. Когда первая копия остается вне камеры, она перемещается вперед.
    }

    private void OnImageNotOnScreen()
    {
        //Переместить первый фрагмент назад
        //Получить ссылку на его трасфортм
        //Получить ссылку на трасформ второго фрагмента
        //Поставить первый фрагмент позади первого
    }
}

