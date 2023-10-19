using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Mirror;

namespace LevelChange
{
    public class ChatUI : NetworkBehaviour
    {
        [Header("UI Elements")]
        [SerializeField] Text chatHistory;
        [SerializeField] Scrollbar scrollbar;
        [SerializeField] InputField chatMessage;
        [SerializeField] Button sendButton;
        public GameObject counselorUI;
        public GameObject operatorGO;

        internal static string localPlayerName;
        internal static readonly Dictionary<NetworkConnectionToClient, string> connNames = new Dictionary<NetworkConnectionToClient, string>();

        public override void OnStartServer()
        {
            connNames.Clear();
            counselorUI.SetActive(true);
        }

        public override void OnStartClient()
        {
            if (isClientOnly)
            {
                operatorGO.SetActive(true);   
            }
            chatHistory.text = "";
        }

        public void SendMessage()
        {
            if (!string.IsNullOrWhiteSpace(chatMessage.text))
            {
                SendMsg(chatMessage.text.Trim());
                chatMessage.text = string.Empty;
                chatMessage.ActivateInputField();
            }
        }

        // Start is called before the first frame update
        void Start()
        {
            //Scene scene = SceneManager.GetSceneByName("WebManager");
            //List<GameObject> rootGameObjects = new List<GameObject>();
            //scene.GetRootGameObjects(rootGameObjects);
            //Instructor = rootGameObjects.Find(o => o.name == "Instructor(Clone)");
            //chatHistory = Instructor.GetComponentInChildren<Text>();
            //scrollbar = Instructor.GetComponentInChildren<Scrollbar>();
            //Debug.Log(scrollbar.value);
        }

        // Update is called once per frame
        void Update()
        {

        }

        [ClientRpc]
        void SendMsg(string message)
        {
            string msg = $"<color=blue>{"Guide"}:</color> {message}";
            StartCoroutine(AppendAndScroll(msg));
        }

        IEnumerator AppendAndScroll(string message)
        {

            //Scene scene = SceneManager.GetSceneByName("WebManager");
            //Debug.Log("scene");
            //List<GameObject> rootGameObjects = new List<GameObject>();
            //scene.GetRootGameObjects(rootGameObjects);
            //Instructor = rootGameObjects.Find(o => o.name == "Instructor(Clone)");

            //Debug.Log(Instructor + "2");
            //chatHistory = Instructor.GetComponentInChildren<Text>();
            //scrollbar = Instructor.GetComponentInChildren<Scrollbar>();

            chatHistory.text += message + "\n";

            // it takes 2 frames for the UI to update ?!?!
            yield return null;
            yield return null;

            //Debug.Log(scrollbar.value);
            // slam the scrollbar down
            scrollbar.value = 0;
        }

    }
}
