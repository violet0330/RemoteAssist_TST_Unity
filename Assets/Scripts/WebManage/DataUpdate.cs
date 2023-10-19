using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DataUpdate : MonoBehaviour
{
    GameObject communicateUI;
    // Start is called before the first frame update
    void Start()
    {
        communicateUI = GameObject.Find("Communicate");
        //findOperator = false;
        //Scene scene = SceneManager.GetSceneByName("PCScene");
        //List<GameObject> rootGameObjects = new List<GameObject>();
        //scene.GetRootGameObjects(rootGameObjects);
        //Operator = rootGameObjects.Find(o => o.name == "Operator(Clone)");
        //Debug.Log(Operator);
    }

    internal void UpdateText(int textMesh, string text)
    {
        //if (!findOperator || Operator == null)
        //{
        //    findOperator = false;
        //    Scene scene = SceneManager.GetSceneByName("PCScene");
        //    List<GameObject> rootGameObjects = new List<GameObject>();
        //    scene.GetRootGameObjects(rootGameObjects);
        //    Operator = rootGameObjects.Find(o => o.name == "Operator(Clone)");
        //    findOperator = true;
        //    Debug.Log(Operator);
        //}
        communicateUI.GetComponent<DataUI>().CmdDataUpdate(textMesh, text);
    }

    internal void UpdateModel(string name)
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
