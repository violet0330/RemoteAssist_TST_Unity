using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
/// <summary>
/// ����������Ƿ�չ���ˣ����ű��������������Template��
/// </summary>
public class DropDownExpands : MonoBehaviour
{


    public bool isExpands { get; private set; }
    public GameObject hidden;
    public GameObject wholeMenu;

    void Start()
    {
        if (this.name == "Dropdown List")
        {
            isExpands = true;
            hidden.transform.localScale = Vector3.zero;

        }
    }
    private void OnDestroy()
    {
        if (wholeMenu.activeInHierarchy == true)
            hidden.transform.localScale = Vector3.one;
        isExpands = false;

    }
}
