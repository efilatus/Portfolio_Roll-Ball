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

    void FixedUpdate()
    {
        MovementLogic();
        JumpLogic();
    }

    private void MovementLogic()
    {
        //Система контроля игрока
        float hor = Input.GetAxisRaw("Horizontal");
        float ver = Input.GetAxisRaw("Vertical");
        Vector3 movement = new Vector3(hor, 0, ver);
        movement = Camera.main.transform.TransformDirection(movement);
        movement.y = 0.0f;
        _charRB.AddForce(movement * _speed * Time.fixedDeltaTime);
    }

    private void JumpLogic()
    {
        if (Input.GetAxis("Jump") > 0)
        {
            if (isGround())
            {
                FindObjectOfType<AudioManager>().Play("Jump");
                _charRB.AddForce(Vector3.up * _jumpForce);
            }
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
