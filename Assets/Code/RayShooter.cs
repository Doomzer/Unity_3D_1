﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems; // Подключение библиотеки для UI-системы.

public class RayShooter : MonoBehaviour
{
    private Camera _camera;

    public bool Lock = false;
    public bool Cursor_visible = false;

    // Use this for initialization
    void Start ()
    {
        _camera = GetComponent<Camera>();
        if (Lock == true)
          Cursor.lockState = CursorLockMode.Locked; // Скрываем указатель мыши
        Cursor.visible = Cursor_visible;
    }

    void OnGUI()
    {
        int size = 12;
        float posX = _camera.pixelWidth / 2 - size / 4;
        float posY = _camera.pixelHeight / 2 - size / 2;
        GUI.Label(new Rect(posX, posY, size, size), "+"); //Команда GUI.Label() отображает на экране символ.
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject()/*Проверяем, что GUI не используется*/)
        {
            Vector3 point = new Vector3(_camera.pixelWidth / 2, _camera.pixelHeight / 2, 0);
            Ray ray = _camera.ScreenPointToRay(point);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                GameObject hitObject = hit.transform.gameObject; //Получаем объект, в который попал луч.
                ReactiveTarget target = hitObject.GetComponent<ReactiveTarget>();
                if (target != null) //Проверяем наличие у этого объекта компонента ReactiveTarget.
                {
                    target.ReactToHit();
                    Messenger.Broadcast(GameEvent.ENEMY_HIT); //К реакции на попадания добавлена рассылка сообщения.
                }
                else
                    StartCoroutine(SphereIndicator(hit.point));
            }
        }
    }

    private IEnumerator SphereIndicator(Vector3 pos)
    {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = pos;
        yield return new WaitForSeconds(1); // Ключевое слово yield указывает сопрограмме, когда следует остановиться.
        Destroy(sphere);
    }
}
