using UnityEngine;
using System.Collections;
public class WeatherController : MonoBehaviour
{
    [SerializeField] private Material sky; //Ссылаться можно не только на объекты сцены, но и на материал на вкладке Project.
    [SerializeField] private Light sun;
    private float _fullIntensity;
    private float _cloudValue = 0f;
    private bool loop = false;

    void Start()
    {
        _fullIntensity = sun.intensity; //Исходная интенсивность света считается «полной».
    }

    void Update()
    {
        SetOvercast(_cloudValue);

        if (loop == false)
          _cloudValue += .005f; // Для непрерывности перехода увеличивайте значение в каждом кадре.
        else
            _cloudValue -= .005f;

        if (_cloudValue > 1)
            loop = true;

        if (_cloudValue < 0)
            loop = false;
    }

    private void SetOvercast(float value) //Корректируем как значение Blend материала, так и интенсивность света.
    {
        sky.SetFloat("_Blend", value);
        sun.intensity = _fullIntensity - (_fullIntensity * value);
    }
}
