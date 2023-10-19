using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using System.Globalization;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using static GlobalVariables;
using TMPro;

public class PlayerScript : NetworkBehaviour
{
    public GameObject operatorPrefab;
    public GameObject instructorPrefab;
    //public TextMeshProUGUI webStatus;


    public override void OnStartLocalPlayer()
    {
        // Camera.main.transform.SetParent(transform);
        // Camera.main.transform.localPosition = new Vector3(0, 0, 0);

    }

    void Start()
    {
        if (!NetworkClient.isConnected && !NetworkServer.active)
        {


//#if UNITY_WSA
//            try
//            {
//            SceneManager.LoadSceneAsync("PCScene", LoadSceneMode.Additive);
//                //webStatus.text = "ClientStart";
//            }
//            catch (System.Exception e)
//            {

//                //webStatus.text = e.Message; ;
//            }


//            //SceneManager.LoadSceneAsync("VuforiaScene", LoadSceneMode.Additive);
//#else
//            Debug.Log(1);
//            try
//            {
//                //webStatus.text = "hoststart";
//                SceneManager.LoadSceneAsync("ServerScene", LoadSceneMode.Additive);

//            }
//            catch (System.Exception e)
//            {
//                Debug.Log( e.Message);

//            }
//#endif

        }

        if (isClientOnly)
        {

            //wholeModelB = GameObject.Find("WholeModelB").GetComponent<Button>();
            //CmdStateChange();
        }
        if (isServer)
        {
            Debug.Log(1);
            try
            {
                //webStatus.text = "hoststart";
                //SceneManager.LoadSceneAsync("ServerScene", LoadSceneMode.Additive);

            }
            catch (System.Exception e)
            {
                Debug.Log(e.Message);

            }
            //GameObject server = Instantiate(instructorPrefab);
            //NetworkServer.Spawn(server);
            //GameObject client = Instantiate(operatorPrefab);
            //NetworkServer.Spawn(client);

        }
    }

    void Update()
    {
        /*
        //*/
    }


}
