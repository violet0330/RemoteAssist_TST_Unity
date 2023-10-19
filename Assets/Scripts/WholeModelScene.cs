using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using static GlobalVariables;
public class WholeModelScene : MonoBehaviour
{
    [Tooltip("Speed of rotation, when the presentation model spins.")]
    public float spinSpeed = 0.3f;

    public GameObject Model;
    public GameObject ModelSplit;

    Quaternion initialRotation;
    bool isMerge;

    // Start is called before the first frame update
    void Start()
    {
        //if (SceneManager.GetSceneByName("WholeModelScene").isLoaded)
          //  SceneManager.UnloadSceneAsync(gameObject.scene);
            
        gestureEvent = gestureType.empty;
        currentGesture = gestureType.empty;
        initialRotation = Model.transform.localRotation;
        if (GameObject.Find("ARGuideTimer") != null)
        {
            Timer timer = GameObject.Find("ARGuideTimer").GetComponent<Timer>();

            if (timer.isActiveAndEnabled == true)
            {
                timer.pauseTimer();
            }
        }

    }

    gestureType currentGesture;

    // Update is called once per frame
    void Update()
    {
        if (gestureEvent != currentGesture)
        {
            currentGesture = gestureEvent;
            GestureDetect();
        }

    }

    void GestureDetect()
    {
        if (gestureEvent == gestureType.wheel)
        {
            if(isMerge == false)
                Merge();
            Turning();

        }
        else if (gestureEvent == gestureType.raiseHandLeft)
            Restart();
        else if (gestureEvent == gestureType.raiseHandRight)
            Detail();
        else if (gestureEvent == gestureType.swipeLeft)
            Split();
        else if (gestureEvent == gestureType.swipeRight)
            Merge();
             
    }

    //geasture control 
    public void Detail()
    {
        if(kinectOn)
            kinectState = 0;
        SceneManager.LoadSceneAsync("WholeModelDetailScene", LoadSceneMode.Additive);
        SceneManager.UnloadSceneAsync("WholeModelScene");
    }

    public void Restart()
    {
        Model.transform.localRotation = initialRotation;
    }

    public void Split()
    {
        Restart();
        isMerge = false;
        GameObject.Find("wholeProject").GetComponentInChildren<Split>().SplitObject();
    }

    public void Merge()
    {
        Restart();
        isMerge = true;
        GameObject.Find("wholeProject").GetComponentInChildren<Split>().MergeObject();
    }

    internal void StopTurning()
    {
        Quaternion currentRotation = Model.transform.localRotation;
        Model.transform.localRotation = currentRotation;
    }


    public void Turning()
    {
        float updateAngle = Mathf.Lerp(0, turnAngle, spinSpeed * Time.deltaTime);
        Model.transform.Rotate(Vector3.up * turnAngle, Space.World);
    }

}



