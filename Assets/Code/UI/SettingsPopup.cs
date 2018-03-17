using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsPopup : MonoBehaviour
{
    [SerializeField] private Slider speedSlider;

    public void Open()
    {
        gameObject.SetActive(true); // Активируйте этот объект, чтобы открыть окно.
    }

    public void Close()
    {
        gameObject.SetActive(false); // Деактивируйте объект, чтобы закрыть окно.
    }

    public void OnSubmitName(string name) //Этот метод срабатывает в момент начала ввода данных в текстовое поле.
    {
        Debug.Log(name);
    }
    public void OnSpeedValue(float speed) //Этот метод срабатывает при изменении положения ползунка.
    {
        PlayerPrefs.SetFloat("speed", speed);
        Debug.Log("Speed: " + speed);
    }

    void Start()
    {
        speedSlider.value = PlayerPrefs.GetFloat("speed", 1); //получить параметр speed
    }
}
