using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LevelChange
{
    public class LevelWebManager : NetworkManager
    {
        public static new LevelWebManager singleton { get; private set; }

        /// <summary>
        /// Runs on both Server and Client
        /// Networking is NOT initialized when this fires
        /// </summary>
        public override void Awake()
        {
            base.Awake();
            singleton = this;
        }

        // Called by UI element NetworkAddressInput.OnValueChanged
        public void SetHostname(string hostname)
        {
            networkAddress = hostname;
        }

        public override void OnServerDisconnect(NetworkConnectionToClient conn)
        {
            // remove player name from the HashSet
            if (conn.authenticationData != null)
                LevelWebAuthenticator.playerNames.Remove((string)conn.authenticationData);

            // remove connection from Dictionary of conn > names
            ChatUI.connNames.Remove(conn);

            base.OnServerDisconnect(conn);
        }

        public override void OnClientDisconnect()
        {
            base.OnClientDisconnect();
            LoginUI.instance.gameObject.SetActive(true);
            LoginUI.instance.usernameInput.text = "";
            LoginUI.instance.usernameInput.ActivateInputField();
        }
    }
}