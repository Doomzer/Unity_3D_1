using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;

    private GameObject _enemy;
    private int _enemy_number = 0;

    public int set_enemy_number = 1;

    // Use this for initialization
    void Start ()
    {
		
	}

    void Awake()
    {
        Messenger.AddListener(GameEvent.ENEMY_HIT, OnEnemyHit); //Объявляем, какой метод отвечает на событие ENEMY_HIT.
    }

    void OnDestroy()
    {
        Messenger.RemoveListener(GameEvent.ENEMY_HIT, OnEnemyHit); //При разрушении объекта удаляйте подписчика, чтобы избежать ошибок.
    }

    private void OnEnemyHit()
    {
        _enemy_number -= 1;
    }

    // Update is called once per frame
    void Update ()
    {
        if (_enemy_number < set_enemy_number)
        {
            _enemy = Instantiate(enemyPrefab) as GameObject; //Метод, копирующий объект-шаблон.

            switch (Random.Range(0, 8))
            {
                case 1:
                    _enemy.transform.position = new Vector3(0, 2, -20);
                    break;

                case 2:
                    _enemy.transform.position = new Vector3(20, 2, 20);
                    break;

                case 3:
                    _enemy.transform.position = new Vector3(20, 2, -10);
                    break;

                case 4:
                    _enemy.transform.position = new Vector3(-20, 2, -15);
                    break;

                case 5:
                    _enemy.transform.position = new Vector3(-20, 2, -15);
                    break;

                case 6:
                    _enemy.transform.position = new Vector3(20, 2, 5);
                    break;

                case 7:
                    _enemy.transform.position = new Vector3(20, 2, -5);
                    break;

                default:
                    _enemy.transform.position = new Vector3(0, 2, 0);
                    break;
            }            
            float angle = Random.Range(0, 360);
            _enemy.transform.Rotate(0, angle, 0);
            _enemy_number++;
        }            
    }
}
