using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GlobalVariables;
using DG.Tweening;
using TMPro;
using System;
using System.Threading;
using UnityEngine.UI;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class LevelChangeUI : MonoBehaviour
{
    public TextMeshProUGUI LevelChangeTips;
    public Button LevelChangeSwitch;

    [Header("Level Change")]
    ///level 1
    public GameObject DetailButton;
    public GameObject ModelImgShow;
    ///Level 2
    public GameObject TaskDetail;

    [Header("Remote Coach")]
    public GameObject askRemote;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(level);
        askRemote.SetActive(false);
        //focusTimer = GameObject.Find("FocusTimer").GetComponent<Timer>();
        //timer = GameObject.Find("ARGuideTimer").GetComponent<Timer>();
        levelSwitch(level);
        LevelChangeSwitch.GetComponentInChildren<TextMeshProUGUI>().text = String.Format("Level {0}", level + 1);

    }

    Timer timer;
    Timer focusTimer;

    /// <summary>
    /// Switch basic level setting
    /// </summary>
    /// <param name="newLevel">0easy,1moderate,2hard,3expert,4test</param>
    internal void levelSwitch(int newLevel)
    {
        LevelChangeTips.text = String.Format("Level Change to L{0}", newLevel + 1);
        ModelImgShow.SetActive(false);
        DetailButton.SetActive(false);
        TaskDetail.SetActive(false);
        remoteOn = false;

        if (newLevel == 0)
        {
            ModelImgShow.SetActive(true);
            DetailButton.SetActive(true);
            TaskDetail.SetActive(true);
            //askRemote.SetActive(true);
            //timer.pauseTimer();
            //focusTimer.pauseTimer();
        }
        else if (newLevel == 1)
        {
            ModelImgShow.SetActive(true);
            DetailButton.SetActive(true);
            TaskDetail.SetActive(true);
            timeSetShort = 120;
            timeSetLong = 1200;

        }
        else if (newLevel == 2)
        {
            TaskDetail.SetActive(true);
            timeSetShort = 90;
            timeSetLong = 900;

        }
        else if (newLevel == 3)
        {
            timeSetShort = 60;
            timeSetLong = 600;
        }
        LevelChangeSwitch.GetComponentInChildren<TextMeshProUGUI>().text = String.Format("Level {0}", level + 1);

        Timer nTimer = Timer.createTimer("nTimer");
        nTimer.startTiming(1, false, OnComplete, OnProcess, true, false, true);
    }

    public void levelSwitchButton()
    {
        level = (level == 0) ? 3 : (level - 1);
        //focusTimer.reStartTimer();
        Debug.Log(level);
        LevelChangeSwitch.GetComponentInChildren<TextMeshProUGUI>().text = String.Format("Level {0}", level + 1);
        levelSwitch(level);
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void RemoteAgree()
    {
        askRemote.SetActive(false);
        remoteOn = true;
        SceneManager.LoadScene("WebManager", LoadSceneMode.Additive);
        gameObject.AddComponent<DataUpdate>();

    }

    public void RemoteCancel()
    {
        askRemote.SetActive(false);
        //timer = GameObject.Find("ARGuideTimer").GetComponent<Timer>();
        //timer.connitueTimer();
        //focusTimer.connitueTimer();
    }



    void OnComplete()
    {
        LevelChangeTips.text = "";
        // GameObject.Find("popOut").SetActive(false);
    }
    void OnProcess(float p)
    {

        //UnityEngine.Debug.Log("on process " + p);
    }
}
