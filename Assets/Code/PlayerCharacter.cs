using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    private int _health;

    // Use this for initialization
    void Start ()
    {
        _health = 5;
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void Hurt(int damage) // Уменьшение здоровья игрока.
    {
        _health -= damage; 
        Debug.Log("Health: " + _health);
    }
}
