using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    //Скорость поворота
    [SerializeField]
    float _turnSpeed = 4.0f;
    //Расположение игрока
    [SerializeField]
    Transform _player;

    //Расстояние от игрока
    Vector3 _offset;

    void Awake()
    {
        _offset = new Vector3(0, 10.0f, 10.0f);
    }

    //Дает возможность крутить камерой с помощью мыши
    void LateUpdate()
    {
        _offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * _turnSpeed, Vector3.up) * _offset;
        transform.position = _player.position + _offset;
        transform.LookAt(_player.position);
    }
}
