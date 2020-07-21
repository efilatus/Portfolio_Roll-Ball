using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    //Префаб checkpoint
    [SerializeField]
    GameObject _checkPoint;
    GameObject _oldCheckPoint;

    void Update()
    {
        //Монетка крутиться вокруг своей оси
        transform.Rotate(0, 100 * Time.deltaTime, 0);
    }

    //Удаление монетки и создание на её месте checkpoint
    public void OnTriggerEnter(Collider other)
    {
        FindObjectOfType<AudioManager>().Play("Coin");
        _oldCheckPoint = GameObject.FindWithTag("Respawn");
        if (_oldCheckPoint != null)
        {
            Destroy(_oldCheckPoint);
        }   
        Instantiate(_checkPoint, this.transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
