using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using System.Globalization;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using static GlobalVariables;
using TMPro;

public class ServerPlayerScript : NetworkBehaviour
{
    public GameObject instructorPrefab;
    public override void OnStartLocalPlayer()
    {
        // Camera.main.transform.SetParent(transform);
        // Camera.main.transform.localPosition = new Vector3(0, 0, 0);

    }

    void Start()
    {
        if (isServer)
        {
            GameObject server = Instantiate(instructorPrefab);
            NetworkServer.Spawn(server);
        }
    }

}
