using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using static GlobalVariables;

public class JFGuidePart : MonoBehaviour
{
    internal int taskNumber;

    internal int currentTask;
    internal int assembleTask;
    internal bool assembleOn;
    string currentModel;

    [Header("Tips")]
    public GameObject next;
    public GameObject congratulations;
    public GameObject timeOut;
    public GameObject wrongObject;
    public GameObject great;
    public GameObject focusTips;

    [Header("Instructions")]
    public TextMeshProUGUI taskText;
    public GameObject ModelShow;
    public GameObject DetailsB;
    public GameObject wholeModelButton;

    [Header("Materials")]
    public Material red;
    public Material white;


    bool details = false;
    internal Vector3 MsPos;
    internal Vector3 MsScale;


    void TaskObserver()
    {
        FocusCheck();
        if (SequenceCheck())
        {
            MusicClickPlay();

            if (details)
                DetailButton();

            taskNumber++;
            taskNum = taskNumber;
            //if (taskNumber <= 4)
            great.SetActive(true);
            Timer nowtimer = Timer.createTimer("nowTimer");
            nowtimer.startTiming(1, false, OnComplete, OnProcess, true, false, true);
            // assembleOn = true;
            assembleTask++;
            assembleNum = assembleTask;

            Task(taskNumber);
            //AssembleTask();
            //assembleTask++;
        }
        else
        {
            MusicErAlPlay();
            errorSelect++;
            GlobalVariables.ErrorJudge();
            GameObject.Find("errorSelect").GetComponent<TextMeshProUGUI>().text = "select: " + errorSelect;
            wrongObject.SetActive(true);
            Timer nowtimer = Timer.createTimer("nowTimer");
            nowtimer.startTiming(2, false, OnComplete, OnProcess, true, false, true);
        }
        Debug.Log(currentTask + "//" + taskNumber);
    }


    public void SkipButton()
    {
        Debug.Log("skip:" + taskNumber + "//" + assembleTask);

        MusicClickPlay();

        if (details == true)
            DetailButton();
        //GameObject.Find("GlobalVariables").GetComponent<GlobalVariables>().errorSelect++;
        //GameObject.Find("errorSelect").GetComponent<TextMeshProUGUI>().text = "select: " + GameObject.Find("GlobalVariables").GetComponent<GlobalVariables>().errorSelect;

        taskNumber++;
        taskNum = taskNumber;
        wrongObject.SetActive(true);
        errorSelect++;
        ErrorJudge();
        Timer nowtimer = Timer.createTimer("nowTimer");
        nowtimer.startTiming(1, false, OnComplete, OnProcess, true, false, true);
        assembleTask++;
        assembleNum = assembleTask;

        Task(taskNumber);
        //AssembleTask();
        //assembleTask++;

    }


    public void SettlementButton()
    {
        Destroy(GameObject.Find("ARGuideTimer"));

        SceneManager.LoadScene("SettlementScene");
    }

    /// <summary>
    /// task list
    /// </summary>
    void Task(int task)
    {
        //DelayOpenAR();
        Debug.Log("Task:" + taskNumber + "//" + assembleTask);
        HideModel("components");
        if (task == 0)
        {
            taskText.text = "task: find the Base";
            GameObject.Find("taskcount").GetComponent<TextMeshProUGUI>().text = "task number:  0/18";
            currentModel = "Base";
            DisplayModel("Base");
        }
        else if (task == 1)
        {
            taskText.text = "task: find Crank-Axle Gear(small one)";
            GameObject.Find("taskcount").GetComponent<TextMeshProUGUI>().text = "task number:  1/18";
            currentModel = "CrankAxleGear";
            DisplayModel("CrankAxleGear");
        }
        else if (task == 2)
        {
            taskText.text = "task: find Crank Axle";
            GameObject.Find("taskcount").GetComponent<TextMeshProUGUI>().text = "task number:  3/18";
            currentModel = "CrankAxle";
            DisplayModel("CrankAxle");
        }
        else if (task == 3)
        {
            taskText.text = "task: find Axle Base Gear ";
            GameObject.Find("taskcount").GetComponent<TextMeshProUGUI>().text = "task number:  4/18";
            currentModel = "AxleBaseGear";
            DisplayModel("AxleBaseGear");
        }
        else if (task == 4)
        {
            taskText.text = "task: find Base Lid ";
            GameObject.Find("taskcount").GetComponent<TextMeshProUGUI>().text = "task number:  6/18";
            currentModel = "BaseLid";
            DisplayModel("BaseLid");
        }
        else if (task == 5)
        {
            taskText.text = "task: find Axle ";
            GameObject.Find("taskcount").GetComponent<TextMeshProUGUI>().text = "task number:  8/18";
            currentModel = "Axle";
            DisplayModel("Axle");
        }
        else if (task == 6)
        {
            taskText.text = "task: find Center Gear ";
            GameObject.Find("taskcount").GetComponent<TextMeshProUGUI>().text = "task number:  9/18";
            currentModel = "CenterGear";
            DisplayModel("CenterGear");
        }
        else if (task == 7)
        {
            taskText.text = "task: find Dome Under ";
            GameObject.Find("taskcount").GetComponent<TextMeshProUGUI>().text = "task number:  10/18";
            currentModel = "DomeUnder";
            DisplayModel("DomeUnder");
        }
        else if (task == 8)
        {
            taskText.text = "task: find internal and external tentacle ";
            GameObject.Find("taskcount").GetComponent<TextMeshProUGUI>().text = "task number:  12/18";
            currentModel = "Tentacle";
            DisplayModel("Tentacle");
        }
        else if (task == 9)
        {
            taskText.text = "task: find both tentacle gear ";
            GameObject.Find("taskcount").GetComponent<TextMeshProUGUI>().text = "task number:  13/18";
            currentModel = "TentacleGear";
            DisplayModel("TentacleGear");
        }
        else if (task == 10)
        {
            taskText.text = "task: find Gear Base ";
            GameObject.Find("taskcount").GetComponent<TextMeshProUGUI>().text = "task number:  15/18";
            currentModel = "GearsBase2";
            DisplayModel("GearsBase2");
        }
        else if (task == 11)
        {
            taskText.text = "task: find Dome ";
            GameObject.Find("taskcount").GetComponent<TextMeshProUGUI>().text = "task number:  16/18";
            currentModel = "Dome";
            DisplayModel("Dome");
        }
        else
        {
            taskText.text = "task finish! ";
            GameObject.Find("taskcount").GetComponent<TextMeshProUGUI>().text = "task number:  18/18";
            congratulations.SetActive(true);
            next.SetActive(true);
        }
            gameObject.GetComponent<DataUpdate>().UpdateText(1, GameObject.Find("taskcount").GetComponent<TextMeshProUGUI>().text);
            gameObject.GetComponent<DataUpdate>().UpdateText(2, taskText.text);
            gameObject.GetComponent<DataUpdate>().UpdateText(3, currentModel);

        
    }

    /// <summary>
    /// AssembleTaskList
    /// </summary>
    /// <param name="assembletask"></param>
    /// <param name="assembleTesk"></param>
    void AssembleTask()
    {
        // DelayOpenAR();
        int i = assembleTask - 1;
        // GameObject.Find("GlobalVariables").GetComponent<GlobalVariables>().assembletask = i;

        if (i == 1 || i == 3 || i == 4 || i == 7 || i == 9 || i == 11)
        {

            SceneManager.LoadScene("ComplexScene2");
        }
        else
        {
            Task(taskNumber);
        }
    }



    // Start is called before the first frame update
    void Start()
    {

        if (GameObject.Find("ARGuideTimer") != null)
        {
            Timer timer = GameObject.Find("ARGuideTimer").GetComponent<Timer>();

            if (timer.isPaused == true)
            {
                timer.connitueTimer();
            }
        }


        if (isTiming == false)
        {
            ARGuideTimer();
        }
        Debug.Log("start" + taskNumber + "//" + assembleTask);


        next.SetActive(false);
        congratulations.SetActive(false);
        timeOut.SetActive(false);
        wrongObject.SetActive(false);
        great.SetActive(false);
        focusTips.SetActive(false);

        wholeModelButton.transform.DOScale(Vector3.zero, 0.1f);

        taskNumber = taskNum;
        assembleTask = assembleNum;
        Debug.Log("start" + taskNumber + "//" + assembleTask);
        GameObject.Find("errorSelect").GetComponent<TextMeshProUGUI>().text = "select: " + errorSelect;
        focusTimer = Timer.createTimer("FocusTimer");
        focusTimer.startTiming(focusTime, false, FocusComplete, OnProcess, true, false, false);

        //*/
        HideModel("modelShow");
        Task(taskNumber);
        MsPos = ModelShow.transform.localPosition;
        MsScale = ModelShow.transform.localScale;
        details = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    Timer focusTimer;

    void FocusCheck()
    {
        focusTimer.reStartTimer();
    }

    void FocusComplete()
    {
        focusTips.SetActive(true);
    }

    public void FocusAgree()
    {
        focusTips.SetActive(false);
        ModelShow.SetActive(true);
        DetailsB.SetActive(true);
        DetailButton();
    }
    public void FocusCancel()
    {
        focusTips.SetActive(false);
        focusTimer.reStartTimer();
    }

    GameObject currentCompo;
    Vector3 currentPos;

    public void DetailButton()
    {

        Debug.Log("detail button click");
        RectTransform MsTrans = ModelShow.GetComponent<RectTransform>();
        if (!currentModel.StartsWith("wholeProject"))
            currentCompo = GameObject.Find("wholeProject/" + currentModel);

        //Vector3(0.83099997,0.768999994,-0.0106104277)
        //modelname
        if (details == false)
        {
            if (!focusTimer.isPaused)
                focusTimer.pauseTimer();
            details = true;
            currentPos = currentCompo.transform.localPosition;
            HideModel("components");
            DisplayModel("wholeProject");
            MaterialChange(currentCompo, red);
            currentCompo.transform.DOLocalMove(new Vector3(1, 0.8f, 0), 1);
            wholeModelButton.transform.DOScale(Vector3.one, 0.1f);
            MsTrans.DOLocalMove(new Vector3(-30, -50, 0), 1f);
            MsTrans.DOScale(new Vector3(2.5f, 2.5f, 2.5f), 1f);

        }
        else
        {
            if (focusTimer.isPaused)
                focusTimer.connitueTimer();
            details = false;
            HideModel("wholeProject");
            DisplayModel(currentModel);
            MaterialChange(currentCompo, white);
            currentCompo.transform.DOLocalMove(currentPos, 0.2f);
            wholeModelButton.transform.DOScale(Vector3.zero, 0.1f);
            MsTrans.DOLocalMove(MsPos, 1f);
            MsTrans.DOScale(MsScale, 1f);

            if (level > 1)
            {
                DetailsB.SetActive(false);
                ModelShow.SetActive(false);
            }
        }


    }


    internal void MaterialChange(GameObject modelname, Material color)
    {
        Debug.Log(modelname);
        MeshRenderer[] modelMesh = modelname.GetComponentsInChildren<MeshRenderer>();

        foreach (MeshRenderer child in modelMesh)
        {
            child.material = color;
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

    public void WModelGuideB()
    {
        Debug.Log("WHBclick");
        Scene scene = SceneManager.GetActiveScene();
        currentScene = scene.name;
        Debug.Log(scene.name);
        string nowModel = model;
        if (kinectOn)
            kinectState = 1;
        else
            kinectState = 2;
        if (nowModel == "demo")
        {
        }
        else if (nowModel == "complex")
        {
            if (!SceneManager.GetSceneByName("WholeModelScene").isLoaded)
                SceneManager.LoadSceneAsync("WholeModelScene", LoadSceneMode.Additive);
            SceneManager.UnloadSceneAsync("ComplexScene");

        }
        else
        {

        }

    }

    /// <summary>
    /// check if the model tracked is the right one
    /// </summary>
    bool SequenceCheck()
    {
        if (taskNumber == currentTask)
        {
            return true;
        }
        else
            return false;
    }

    #region TaskList
    public void BaseTrack()
    {
        Debug.Log(currentTask + "Tracked");
        currentTask = 0;
        TaskObserver();
    }
    public void CAGearTrack()
    {
        Debug.Log(currentTask + "Tracked");
        currentTask = 1;
        TaskObserver();
    }
    public void ABGearTrack()
    {
        Debug.Log(currentTask + "Tracked");
        currentTask = 3;
        TaskObserver();
    }
    public void CrankAxleTrack()
    {
        Debug.Log(currentTask + "Tracked");
        currentTask = 2;
        TaskObserver();
    }
    public void BaseLidTrack()
    {
        Debug.Log(currentTask + "Tracked");
        currentTask = 4;
        TaskObserver();
    }
    public void AxleTrack()
    {
        Debug.Log(currentTask + "Tracked");
        currentTask = 5;
        TaskObserver();
    }
    public void CenterGearTrack()
    {
        Debug.Log(currentTask + "Tracked");
        currentTask = 6;
        TaskObserver();
    }
    public void DomeUnderTrack()
    {
        Debug.Log(currentTask + "Tracked");
        currentTask = 7;
        TaskObserver();
    }
    public void ITentacleTrack()
    {
        Debug.Log(currentTask + "Tracked");
        currentTask = 8;
        TaskObserver();
    }
    public void ETentacleTrack()
    {
        Debug.Log(currentTask + "Tracked");
        currentTask = 9;
        TaskObserver();
    }
    public void IGearTrack()
    {
        Debug.Log(currentTask + "Tracked");
        currentTask = 10;
        TaskObserver();
    }
    public void EGearTrack()
    {
        Debug.Log(currentTask + "Tracked");
        currentTask = 11;
        TaskObserver();
    }
    public void GearsBaseTrack()
    {
        Debug.Log(currentTask + "Tracked");
        currentTask = 12;
        TaskObserver();
    }
    public void DomeTrack()
    {
        Debug.Log(currentTask + "Tracked");
        currentTask = 13;
        TaskObserver();
    }

    #endregion

    void OnComplete()
    {
        timeOut.SetActive(false);
        wrongObject.SetActive(false);
        great.SetActive(false);
        // GameObject.Find("popOut").SetActive(false);
    }
    void OnProcess(float p)
    {

        //UnityEngine.Debug.Log("on process " + p);
    }
    public void BackButton()
    {

        SceneManager.LoadScene("HomeScene");
    }
}
