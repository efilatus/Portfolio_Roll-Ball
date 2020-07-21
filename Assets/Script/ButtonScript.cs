using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    //Платформа которая появляется
    [SerializeField]
    GameObject _platform;

    //Эффект нажатия на кнопку и активация платформы
    public void OnTriggerEnter(Collider other)
    {
        FindObjectOfType<AudioManager>().Play("Button");
        transform.position = new Vector3(transform.position.x, -0.15f, transform.position.z);
        _platform.SetActive(true);
    }
}
