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
	
	// Update is called once per frame
	void Update ()
    {
        if (_enemy_number < set_enemy_number)
        {
            _enemy = Instantiate(enemyPrefab) as GameObject; //Метод, копирующий объект-шаблон.
            _enemy.transform.position = new Vector3(0, 2, 0);
            float angle = Random.Range(0, 360);
            _enemy.transform.Rotate(0, angle, 0);
            _enemy_number++;
        }
        if (_enemy == null)
            _enemy_number -= 1;

    }
}
