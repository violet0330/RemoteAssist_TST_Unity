using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Mirror;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class DataUI : NetworkBehaviour
{
    [SerializeField]TextMeshProUGUI productNameWeb;
    [SerializeField] TextMeshProUGUI stepWeb;
    [SerializeField] TextMeshProUGUI taskcountWeb;
    [SerializeField] TextMeshProUGUI taskWeb;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="TextMesh">0 step,1 taskCount, 2 taskContent</param>
    /// <param name="text"></param>
    [Command(requiresAuthority = false)]
    internal void CmdDataUpdate(int TextMesh, string text)
    {
        if (TextMesh == 0)
            stepWeb.text = text;        
        else if (TextMesh == 1)
            taskcountWeb.text = text;
        else if (TextMesh == 2)
            taskWeb.text = text;
        else if (TextMesh == 3)
            DisplayModel(text);
    }

    // Start is called before the first frame update
    void Start()
    {
        if (isServer)
        {
            HideModel("wholeProject");
        }
    }

    internal void HideModel(string modelname)
    {
        GameObject modelShow = GameObject.Find(modelname);
        MeshRenderer[] modelMesh = modelShow.GetComponentsInChildren<MeshRenderer>();

        foreach (MeshRenderer child in modelMesh)
        {
            //Debug.Log(child.name);
         child.enabled = false;
        }
    }
    internal void DisplayModel(string modelname)
    {
        GameObject modelShow;
            modelShow = GameObject.Find(modelname);
        

        MeshRenderer[] modelMesh = modelShow.GetComponentsInChildren<MeshRenderer>();

        foreach (MeshRenderer child in modelMesh)
        {
            child.enabled = true;
            //Debug.Log(child.enabled);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
