using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportScipt : MonoBehaviour
{
    //Место куда будет телепортировать игрока
    [SerializeField]
    Transform _destination;

    //Перемещает игрока на определенное место на карте
    public void OnTriggerEnter(Collider other)
    {
        FindObjectOfType<AudioManager>().Play("Teleport");
        other.transform.position = _destination.transform.position;
        other.transform.rotation = _destination.transform.rotation;
    }
}
