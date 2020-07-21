using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Скрип для отработки общих для игры методов
public class FieldScript : MonoBehaviour
{
    //Префаб игрока
    [SerializeField]
    GameObject _playerBall;
    //Checkpoint для восстановления игрока
    GameObject _checkPoint;
    //Последняя монетка для завершения уровня
    [SerializeField]
    GameObject _lastCoin;

    //Жизни
    int _life = 3;

    //Сцена
    Scene _currentScene;

    private void Start()
    {
        //Сделать курсор невидимым
        Cursor.visible = false;
        //Проверка сцены для проигрывания правильной музыки
        _currentScene = SceneManager.GetActiveScene();
        if (_currentScene.name == "Level3")
            FindObjectOfType<AudioManager>().Play("MusicLevel3");
        else
            FindObjectOfType<AudioManager>().Play("Music");
        
    }

    private void Update()
    {
        //Провека что игрок коснулся последней монетки
        if (_lastCoin == null)
        {
            LoadNextLevel();
        }
    }

    //Проверка если игрок упал за границы уровня, смерть и восстановление
    private void OnTriggerExit(Collider other)
    {
        _checkPoint = GameObject.FindWithTag("Respawn");
        if (other.tag == "Player" && _life != 0)
        {
            StartCoroutine(ExampleCoroutine(other));
            _life -= 1;
        }
        if (other.tag == "Player" && _life == 0)
            SceneManager.LoadScene(_currentScene.name);
    }

    /// <summary>
    /// Загрузка следующего уровня
    /// </summary>
    private void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    //Проигрывание музыки смерти, удаление и восстановление игрока
    IEnumerator ExampleCoroutine(Collider other)
    {
        FindObjectOfType<AudioManager>().Play("GameOver");
        yield return new WaitForSeconds(1);
        Destroy(other.gameObject);
        Instantiate(_playerBall, _checkPoint.transform.position, Quaternion.identity);
    }
}
