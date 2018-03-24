using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Импорт инфраструктуры для работы с кодом UI.

public class UIController : MonoBehaviour
{
    [SerializeField] private Text scoreLabel; //Объект сцены Reference Text, предназначенный для задания свойства text.
    [SerializeField] private SettingsPopup settingsPopup;

    private int _score;

    void Awake()
    {
        Messenger.AddListener(GameEvent.ENEMY_HIT, OnEnemyHit); //Объявляем, какой метод отвечает на событие ENEMY_HIT.
    }

    void OnDestroy()
    {
        Messenger.RemoveListener(GameEvent.ENEMY_HIT, OnEnemyHit); //При разрушении объекта удаляйте подписчика, чтобы избежать ошибок.
    }

    void Start()
    {
        _score = 0;
        scoreLabel.text = _score.ToString(); //Присвоение переменной score начального значения 0.
        settingsPopup.Close(); // Закрываем всплывающее окно в момент начала игры.
    }

    public void OnOpenSettings() //Метод, вызываемый кнопкой настроек.
    {
        settingsPopup.Open();
    }

    public void OnPointerDown()
    {
        Debug.Log("pointer down");
    }

    private void OnEnemyHit()
    {
        _score += 1; //Увеличение переменной score на 1 в ответ на данное событие.
        scoreLabel.text = _score.ToString();
    }
}
