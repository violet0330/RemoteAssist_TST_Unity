using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using Mirror;
using System.Linq.Expressions;
using Unity.VisualScripting;
using UnityEngine.EventSystems;

public class WebCanvas : MonoBehaviour
{
    NetworkManager manager;
    public TextMeshProUGUI webStatus;


    [Header("UI Elements")]
    internal TextMeshProUGUI msgText;
    void Awake()
    {
        manager = GetComponent<NetworkManager>();
        /*
        EventSystem eventSystem = FindObjectOfType<EventSystem>();

        // ���EventSystem�����ڣ�����һ���µ�EventSystem
        if (eventSystem == null)
        {
            GameObject eventSystemObject = new GameObject("EventSystem");
            eventSystem = eventSystemObject.AddComponent<EventSystem>();
            eventSystemObject.AddComponent<StandaloneInputModule>();
        }
        //*/
    }

    private void Start()
    {

       

    }


}
