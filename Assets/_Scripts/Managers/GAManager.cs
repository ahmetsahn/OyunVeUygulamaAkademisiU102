using UnityEngine;
using GameAnalyticsSDK;
using UnityEngine.UI;
using System.Collections.Generic;

public class GAManager : MonoBehaviour
{
    [SerializeField] private InputField inputField;

    void Start()
    {
        GameAnalytics.Initialize();
        // Di�er ba�latma ayarlar� veya oyun ayarlar�
    }

    public void SendTextToGameAnalytics()
    {
        string text = inputField.text;

        Dictionary<string, object> eventData = new Dictionary<string, object>();
        eventData.Add("InputFieldText", text);

        GameAnalytics.NewDesignEvent("InputFieldEvent", eventData);
    }



}
