using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Xml;

public class WeatherManager : MonoBehaviour, IGameManager
{
    public ManagerStatus status { get; private set; }
    public float cloudValue { get; private set; } //Облачность редактируется внутренне, в остальных местах это свойство предназначено только для чтения.
    private NetworkService _network;

    public void OnXMLDataLoaded(string data)
    {
        XmlDocument doc = new XmlDocument();
        doc.LoadXml(data); // Разбиваем XML-код на структуру с возможностью поиска.
        XmlNode root = doc.DocumentElement;
        XmlNode node = root.SelectSingleNode("clouds"); // Извлекаем из данных один узел.
        string value = node.Attributes["value"].Value;
        cloudValue = Convert.ToInt32(value) / 100f; // Преобразуем значение в число типа float в диапазоне от 0 до 1.
        Debug.Log("Value: " + cloudValue);
        //Messenger.Broadcast(GameEvent.WEATHER_UPDATED);
        status = ManagerStatus.Started;
    }

    public void Startup(NetworkService service)
    {
        Debug.Log("Weather manager starting...");
        _network = service; //Сохранение вставленного объекта NetworkService.
        status = ManagerStatus.Started;
    }
}
