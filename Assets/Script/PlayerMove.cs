using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    //Скорость и сила прыжка
    [SerializeField]
    float _speed;
    [SerializeField]
    float _jumpForce;

    //Rigidbody и коллайдер игрока
    [SerializeField]
    Rigidbody _charRB;
    [SerializeField]
    Collider _collider;

    private void Update()
    {
        //Если игрок но земле он может совершить прыжок
        if (isGround()) 
        {
            if (Input.GetKeyDown("space"))
            {
                FindObjectOfType<AudioManager>().Play("Jump");
                _charRB.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
            }
        }
    }

    void FixedUpdate()
    {
        //Система контроля игрока
        if (Input.GetKey(KeyCode.W))
        {
            _charRB.AddForce(Camera.main.transform.forward * _speed * Time.fixedDeltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            _charRB.AddForce(Camera.main.transform.forward * -_speed * Time.fixedDeltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            _charRB.AddForce(Camera.main.transform.right * _speed * Time.fixedDeltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            _charRB.AddForce(Camera.main.transform.right * -_speed * Time.fixedDeltaTime);
        }

    }

    //Проигрывает звук удара при ударе о поверхность любого объекта
    private void OnCollisionEnter(Collision collision)
    {
        FindObjectOfType<AudioManager>().Play("Hit");
    }

    /// <summary>
    /// Проверка что игрок находится на земле
    /// </summary>
    /// <returns>Под игроком находится земля</returns>
    private bool isGround()
    {
        float exrtaHeightText = .01f;
        bool raycastHit = Physics.Raycast(_collider.bounds.center, Vector3.down, _collider.bounds.extents.y + exrtaHeightText);
        return raycastHit;
    }

}
