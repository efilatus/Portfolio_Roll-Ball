using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformScript : MonoBehaviour
{
    //Платформа которая будет совршать движение
    [SerializeField]
    Transform _movingPlatform;
    //Позиции от и до которых движется платформа
    [SerializeField]
    Transform _position1;
    [SerializeField]
    Transform _position2;
    Vector3 _newPosition;
    //Плавность пермещения
    [SerializeField]
    float _smooth;

    AudioSource _sound;

    private void Start()
    {
        //Проигрывание звука для платформы
        _sound = GetComponent<AudioSource>();
        _sound.Play();
    }

    //Перемещение платформы между точек
    void FixedUpdate()
    {
        if (_movingPlatform.position.z >= _position1.position.z)
        {
            _newPosition = _position2.position - _movingPlatform.position;
        }
        else if (_movingPlatform.position.z <= _position2.position.z)
        {
            _newPosition = _position1.position - _movingPlatform.position;
        }

        _movingPlatform.position += _newPosition * _smooth * Time.deltaTime;
    }
}
